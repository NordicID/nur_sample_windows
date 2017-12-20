using NurApiDotNet;
using NurApiDotNet.UWP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NurApiMinimalUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // List of known devices shown in UI listview
        public ObservableCollection<NurDeviceWatcherInfo> KnownDevices = new ObservableCollection<NurDeviceWatcherInfo>();

        // Device watcher
        NurDeviceWatcher mDevWatcher;

        NurApi mApi = new NurApi();

        NurDeviceWatcherInfo mConnectedDev = null;

        public MainPage()
        {
            this.InitializeComponent();

            // Start device watcher
            mDevWatcher = new NurDeviceWatcher();
            mDevWatcher.DeviceAdded += DevWatcher_DeviceAddedAsync;
            mDevWatcher.DeviceRemoved += DevWatcher_DeviceRemovedAsync;
            mDevWatcher.DeviceUpdated += DevWatcher_DeviceUpdatedAsync;
            mDevWatcher.Start();

            mApi.ConnectedEvent += MApi_ConnectedEvent;
            mApi.DisconnectedEvent += MApi_DisconnectedEvent;
            mApi.TransportConnStateChanged += MApi_TransportConnStateChanged;
            mApi.LogEvent += MApi_LogEvent;

            // Enable all logs for debugging purposes
            //mApi.SetLogLevel(NurApi.LOG_ERROR | NurApi.LOG_USER | NurApi.LOG_VERBOSE | NurApi.LOG_DATA);
            //mApi.SetLogLevel(NurApi.LOG_ERROR | NurApi.LOG_USER | NurApi.LOG_VERBOSE);

            InventoryButton.IsEnabled = false;
            ConnInfo.Text = "Please select connection. NurApi v" + mApi.GetFileVersion();
        }

        // NurApi logs
        private void MApi_LogEvent(object sender, NurApi.LogEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.message);
        }

        // This event gets called by NurApiTransport on connection state change.
        // NOTE: Transport level connection states are not same as NurApi Connected/Disconnected event states.
        private async void MApi_TransportConnStateChanged(object sender, EventArgs e)
        {
            // We're only interested about Connecting state
            if (mApi.Transport.ConnState == NurApiTransport.State.Connecting && mConnectedDev != null)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    // Update listview entry
                    mConnectedDev.ConnState = mApi.Transport.ConnState;
                    mConnectedDev.UpdateInfo();
                });
            }
        }

        // This is called when NurApi is fully disconnect (and released resources)
        private async void MApi_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            // Update UI in UI thread
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                // Update listview item
                if (mConnectedDev != null)
                {
                    mConnectedDev.ConnState = NurApiTransport.State.Disconnected;
                    mConnectedDev.UpdateInfo();
                    mConnectedDev = null;
                }

                // Update UI
                InventoryButton.IsEnabled = false;
                ConnInfo.Text = "Disconnected";
                ConnButton.Content = "Connect";
            });
        }

        // This is called when NurApi is fully connected to device and ready to communicate
        private async void MApi_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            // Update reader info, run in task because NurApi calls may block
            await Task.Run(async () =>
            {
                try
                {
                    NurApi.ReaderInfo rdrInfo = mApi.GetReaderInfo();

                    // Update UI in UI thread
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        // Update listview item
                        if (mConnectedDev != null)
                        {
                            mConnectedDev.ConnState = NurApiTransport.State.Connected;
                            mConnectedDev.UpdateInfo();
                        }

                        // Update UI
                        ConnInfo.Text = string.Format("Connected {0}  |  Serial {1}  |  FW {2}", rdrInfo.name, rdrInfo.serial, rdrInfo.GetVersionString());
                        InventoryButton.IsEnabled = true;
                        ConnButton.Content = "Disconnect";
                    });
                }
                catch (Exception ex)
                {
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        ConnInfo.Text = "Error " + ex.ToString();
                    });
                }
            });
        }

        private async void DevWatcher_DeviceUpdatedAsync(object sender, NurDeviceWatcherInfo e)
        {
            // We must update the item on the UI thread because the item is databound to a UI element.
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                // Update listview item
                e.UpdateInfo();
            });
        }

        private async void DevWatcher_DeviceRemovedAsync(object sender, NurDeviceWatcherInfo e)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                KnownDevices.Remove(e);
            });
        }

        private async void DevWatcher_DeviceAddedAsync(object sender, NurDeviceWatcherInfo e)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                KnownDevices.Add(e);
            });
        }

        private async void ConnButton_Click(object sender, RoutedEventArgs e)
        {
            // Disable buttons while (dis)connecting
            ConnButton.IsEnabled = false;
            InventoryButton.IsEnabled = false;

            try
            {
                if (mApi.IsConnected())
                {
                    // Disconnect
                    ConnButton.Content = "Disconneting..";
                    await mApi.DisconnectAsync();
                }
                else
                {
                    // Connect
                    NurDeviceWatcherInfo dev = null;
                    try
                    {
                        dev = KnownDevices[ConnList.SelectedIndex];
                    }
                    catch { }

                    if (dev == null)
                    {
                        var dialog = new MessageDialog("Please select device to connect");
                        await dialog.ShowAsync();
                        return;
                    }

                    // Connect with device connection spec
                    ConnButton.Content = "Conneting..";
                    mConnectedDev = dev;
                    await mApi.ConnectAsync(dev.Spec);                    
                }
            }
            catch (Exception ex)
            {
                // Update UI
                MApi_DisconnectedEvent(mApi, new NurApi.NurEventArgs(0));

                var dialog = new MessageDialog(ex.Message, "Connection Error");
                await dialog.ShowAsync();
            }
            
            ConnButton.IsEnabled = true;
        }

        private async void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            InventoryButton.IsEnabled = false;

            // Perform inventory, run in task because NurApi calls may block
            await Task.Run(async () =>
            {
                try
                {
                    // Clear nur tag stroage first
                    mApi.ClearTagsEx();

                    // Perform simple inventory
                    NurApi.InventoryResponse rsp = mApi.Inventory();

                    // Fetch all tags from reader
                    NurApi.TagStorage storage = mApi.FetchTags();

                    // Print some info
                    string txt = string.Format("{0} tags found\n", rsp.numTagsMem);
                    lock (storage)
                    {
                        foreach (NurApi.Tag tag in storage)
                        {
                            txt += tag.GetEpcString() + "\n";
                        }
                    }

                    // Show dialog in UI thread
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                    {
                        var dialog = new MessageDialog(txt, "Inventory Results");
                        await dialog.ShowAsync();
                    });
                }
                catch (Exception ex)
                {
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                    {
                        var dialog = new MessageDialog(ex.Message, "Inventory Error");
                        await dialog.ShowAsync();
                    });
                }
            });

            InventoryButton.IsEnabled = true;
        }
    }
}
