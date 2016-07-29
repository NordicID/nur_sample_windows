using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using NurApiDotNet;

namespace MultiClientTest
{
    public partial class Form1 : Form
    {
        const int SIMPLE_INVENTORY = 1;
        const int INVENTORY_STREAM = 2;

        //Information about connected Client
        //tagsFound contains number of tags found after inventory round
        struct ClientInfo
        {           
           public NurApi cApi;  
           public string title;
           public string ip;
           public int tagsFound; 
           public string lastErr;
           public bool StreamerRunning;
           public InventoryStreamer invStreamer;
           public Thread invThread;
        };

        NurApi hNur = null;     //Parent NUR handle

        bool doRead;            //True when tag reading process run
        int readingMode;        //SimpleInventory or InventoryStream
        bool doInvStreaming;    //True when using InventoryStreamer Thread
        int roundCnt;
        
        //List of connected clients.
        //When Client connectes, it is added to list.
        //When Client Disconnects, it is removed from list
        List<ClientInfo> clientList = new List<ClientInfo>();    
        
        public Form1()
        {
            InitializeComponent();
            PrepareListView();

            hNur = new NurApi(this);//Nur Api handle

            doRead = false;
            labelNurApiVer.Text = hNur.GetFileVersion();
            labelDotNetVer.Text = System.Reflection.Assembly.GetAssembly(hNur.GetType()).GetName().Version.ToString();
            readingMode = SIMPLE_INVENTORY;
            radioButton1.Checked = true;
            radioButton2.Checked = false;

            // Add event handler for receiving client connected and disconnected status
            hNur.ClientConnectedEvent += new EventHandler<NurApi.ClientInfoEventArgs>(hNur_ClientConnected);
            hNur.ClientDisconnectedEvent += new EventHandler<NurApi.ClientInfoEventArgs>(hNur_ClientDisonnected);

            hNur.LogEvent += new EventHandler<NurApi.LogEventArgs>(hNur_LogEvent);           
            
        }

       
        /// Client Connected. Add new Client to list.       
        void hNur_ClientConnected(object sender, NurApi.ClientInfoEventArgs e)
        {
            string clientTitle ="No title";
            ClientInfo ci = new ClientInfo();
            
            try
            {
                clientTitle = e.cApi.Title; //Get Title of client device
            }
            catch (Exception ex)
            {
                ci.lastErr = ex.Message; //Propably Title property is not support by client.
            }
            
             AddLog("Client:"+ clientTitle + " " + e.data.ip + " Connected!");
            
            //Save information to ClientInfo struct and save it to the simple list
            ci.cApi = e.cApi;
            ci.title = clientTitle;
            ci.ip = e.data.ip;
            ci.StreamerRunning=false;      
            ci.tagsFound = -1;
           
            clientList.Add(ci); //Add it
            UpdateClientList(); //Show to user
            
        }

        
        /// StartStreamerThread function start theard for specified client reader, which do StreamingInventory continuously...        
        void StartStreamerThread(ref ClientInfo ci)
        {
            ci.invStreamer = new InventoryStreamer(ref ci.cApi);
            ci.invThread = new Thread(ci.invStreamer.Start);
            ci.invThread.Start();
            ci.StreamerRunning = true;            
            
        }

       
        // Client Disconnected.
        // At this point client is not useful to us anymore.
        // We need to remove it from our ClientList and call NurApi.Dispose function for freeing resources.        
        void hNur_ClientDisonnected(object sender, NurApi.ClientInfoEventArgs e)
        {      
            ClientInfo ci = new ClientInfo();

            //Search correct client from list
            for (int i = 0; i < clientList.Count; i++)
            {
                ci = clientList[i];
                if (ci.cApi.GetHandle() == e.cApi.GetHandle()) //Compare handle pointers for making sure we talking about correct client..
                {
                    //Found.
                    AddLog("Disconnect:" + ci.ip );
                    if (ci.StreamerRunning)
                    {
                        //if StramerThread is running we need to drive it down.
                        ci.invStreamer.Stop();                 
                    }
                    clientList.RemoveAt(i); //remove it from our List.
                    e.cApi.Dispose(); //No use anymore. Free resources                                 
                    UpdateClientList(); //View client list to user (one client less than previous view)
                    break; //We're done.
                }
            }            
        }

       
        // Note! We receive Logs from parent NurApi handler who started server        
        void hNur_LogEvent(object sender, NurApi.LogEventArgs e)
        {
            AddLog(e.timestamp.ToString() + ": " + e.message);
        }

       
        // StartServer function starts server and waiting clients for connecting.        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                hNur.StartServer(Convert.ToInt16(textPortEdit.Text), Convert.ToInt16(textMaxClients.Text));
                AddLog("Listening port:" + textPortEdit.Text);
            }
            catch (NurApiException ex)
            {
                AddLog("StartServer Error:" + ex.Message);                
            }
            
        }

        //AddLog line to listBox
        void AddLog(string txt)
        {
            if (logList.Items.Count > 5000) 
                logList.Items.RemoveAt(0);
            
            logList.Items.Add(txt);

            if (logList.SelectedIndex >= logList.Items.Count - 2)         
                logList.SelectedIndex = logList.Items.Count - 1;            
        }

        //Update client list in to the Listview control
        private void UpdateClientList()
        {
            ListViewItem lv;
            ClientInfo ci = new ClientInfo();
            int totalInvRounds = 0;

            listView1.SuspendLayout();
            listView1.Items.Clear();

            //Display Client infos
            for (int i = 0; i < clientList.Count; i++)
            {
                ci = clientList[i];
                lv = listView1.Items.Add(ci.title, 0);
                lv.SubItems.Add(ci.ip);
                if (ci.StreamerRunning)
                {                    
                    //Streamer object created.Get tag count value
                    lv.SubItems.Add(ci.invStreamer.ReadTagCount().ToString());
                    totalInvRounds += ci.invStreamer.GetTotalInventoryRounds();
                }
                else
                {
                    //StreamerInventory not alive. Should it be?
                    if (doInvStreaming)
                    {
                        //Yes. Start thread and give ClientInfo as reference
                        StartStreamerThread(ref ci);
                        clientList[i] = ci;
                    }
                    else
                    {
                        //If InventoryStream threading not used, just view count of tags from ClientInfo struct
                        lv.SubItems.Add(ci.tagsFound.ToString());
                    }
                }
                lv.SubItems.Add(ci.lastErr);                
            }
            if(doInvStreaming)
                labelRounds.Text = totalInvRounds.ToString();

            listView1.ResumeLayout();

        }

        private void buttonStopServer_Click(object sender, EventArgs e)
        {
            //Stopping Server. Note! client connections will remain.
            hNur.StopServer();
        }

        private void PrepareListView()
        {

            ListViewItem item = new ListViewItem();
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.View = View.Details;
            listView1.OwnerDraw = false;
            listView1.GridLines = true;

            listView1.Columns.Add("Name", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("IP", 90, HorizontalAlignment.Left);
            listView1.Columns.Add("Tag count", 70, HorizontalAlignment.Left);            
            listView1.Columns.Add("Last error", 200, HorizontalAlignment.Left);
            
        }

        //Stopping server and disconnecting all currently connected clients.
        private void DisconnectAll()
        {            
            hNur.StopServer();  //Stop Server
                       
            //Disconnect all Nur Clients
            for (int i = 0; i < clientList.Count; i++)
            {                               
                clientList[i].cApi.Disconnect();
            }            
        }

        private void buttonDisconnectAll_Click(object sender, EventArgs e)
        {
            DisconnectAll();            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectAll();
            //Thread.Sleep(1000); //Making sure all closed...
        }
        
        //Start/Stop Toggle button
        //Depending state of checkAllatOnce checkbox, tag inventory oneByOne or all at once is started or stopped.
        private void buttonStart_Click(object sender, EventArgs e)
        {
            ClientInfo ci = new ClientInfo();   
            
            if (doRead)
            {
                //Running. Stop it.
                doRead = false;
                buttonStart.Text = "Start";
                if (doInvStreaming)
                {
                    //Stop all threads
                    for (int i = 0; i < clientList.Count; i++)
                    {
                        ci = clientList[i];
                        if (ci.StreamerRunning)
                        {
                            ci.invStreamer.Stop();
                            ci.StreamerRunning = false;                           
                            clientList[i] = ci;
                        }
                    }

                    doInvStreaming = false;
                }
            }
            else
            {
                //Not running. Do start.
                timer1.Interval = Convert.ToInt16(textBoxWait.Text) + 1;//Used for creating time interval how ofter inventory round performed in OneByOne reading method
                doRead = true;
                roundCnt = 0;
                buttonStart.Text = "Stop";
                timer1.Start();
                if (readingMode == INVENTORY_STREAM)
                {
                    //We start to do inventorystream with all reader at same time.
                    doInvStreaming = true;
                    //Let Timer handle and UpdateClientList func start reading threads
                }
            }          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (doRead)
            {
                if (doInvStreaming)
                {
                    //Show tag count results of InventoryStreamer threads.
                    //Start InventoryStreamer thread if not yet started.
                    UpdateClientList();
                }
                else
                {
                    //Reading count of tags one reader at the time. This is reliable way to read tags because readers doesn't disturb each others.
                    ReadTagsFromAllReadersOneByOne();
                }
                roundCnt++;
                labelRounds.Text = roundCnt.ToString();
            }
            else
            {
                timer1.Stop();
            }
                      

        }
       
        //Go through all the connected readers and perform SimpleInventory one by one.   
        private void ReadTagsFromAllReadersOneByOne()
        {
            NurApi.TagStorage tags; //Fetching tag data to here when available
            ClientInfo ci = new ClientInfo();
            
            //Go through all the connected client readers
            for (int i = 0; i < clientList.Count; i++)
            {
                ci = clientList[i];
                
                //Start inventory for this reader
                try
                {
                    ci.cApi.ClearTags();
                    ci.cApi.SimpleInventory();
                    tags = ci.cApi.FetchTags(false);
                    ci.tagsFound = tags.Count; //Update count value
                }
                catch (Exception ex)
                {
                    //Error happend. Show it in the list
                    ci.lastErr = ex.Message;
                    ci.tagsFound = -1;
                }

                clientList[i]=ci;   //Save results
            }
                       
            //Show to user.
            UpdateClientList();

        }

        private void checkBoxDoParenLogs_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDoParenLogs.Checked)
                hNur.SetLogLevel(NurApi.LOG_ALL);
            else
                hNur.SetLogLevel(0);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            readingMode = SIMPLE_INVENTORY;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            readingMode = INVENTORY_STREAM;
        }
                
       
    }

    //Thread of InventoryStreamer.
    //
    public class InventoryStreamer
    {
        NurApi myNur;
        NurApi.TagStorage tags;
        private int tagCount;
        private int totalInvRounds;

        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.
        private volatile bool _shouldStop;

        public InventoryStreamer(ref NurApi hNur)
        {
            totalInvRounds = 0;

            myNur=hNur; //Copy Nur handler

            //Create InventoryStream event handler. Remeber to remove it when no longer use.
            myNur.InventoryStreamEvent += new EventHandler<NurApi.InventoryStreamEventArgs>(InventoryStreamEventHandler);
        }

        private void InventoryStreamEventHandler(object sender, NurApi.InventoryStreamEventArgs e)
        {
            try
            {
                //Only what we do here is to take count of readed tags.
                //Real app do much more...
                tags = myNur.GetTagStorage();
                tagCount = tags.Count;
                totalInvRounds++;

                myNur.ClearTags();
                if (e.data.stopped)
                {
                    //Start again if stopped.
                    myNur.StartInventoryStream();
                }
            }
            catch
            {
                //Some problems. Stop all and exit from this thread.
                Stop();
            }

        }

         
        // This method will be called when the thread is started.
        public void Start()
        {
            try
            {
                myNur.ClearTags();
                myNur.StartInventoryStream();
            }
            catch
            {
                Stop(); //Exit from thread because of error
            }

            //We stay here until ordered to stop inventory
            while (!_shouldStop)
            {
                Thread.Sleep(200);
            }           
            
        }

        //Command to Stop InventoryStream
        public void Stop()
        {
            try
            {
                myNur.StopInventoryStream();
            }
            catch
            {

            }
            
            //Remove event handler
            myNur.InventoryStreamEvent -= InventoryStreamEventHandler;
            _shouldStop = true;  //Now we are ready to leave
        }

        public int ReadTagCount()
        {
            return tagCount;
        }

        public int GetTotalInventoryRounds()
        {
            return tagCount;
        }
        
        
    }

}
