using System;
using System.Windows.Input;
using Mvvm;
using Mvvm.Services;
using NurApiSampleMvvm;
using System.Collections.ObjectModel;
using NurApiDotNet.UWP;
using NurApiDotNet;
using Windows.ApplicationModel.Core;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

namespace Mvvm
{
    public class InventoriedTag : BindableBase
    {
        public string EPC { get; set; }
        public string Rssi { get; set; }

        public void Update() {
            OnPropertyChanged("Rssi");
        }

        public bool UiAdded;
        public bool UiUpdated;
    }

    internal class InventoryPageViewModel : ViewModelBase
    {
        // Global view model instance
        static InventoryPageViewModel _instance;
        internal static InventoryPageViewModel Instance()
        {
            if (_instance == null)
                _instance = new InventoryPageViewModel();
            return _instance;
        }

        public ObservableCollection<InventoriedTag> InventoriedTags = new ObservableCollection<InventoriedTag>();
        Dictionary<string, InventoriedTag> InventoriedTagsDict = new Dictionary<string, InventoriedTag>();
        
        string _InvButtonText = "Simple Inventory";
        public string InvButtonText { get { return _InvButtonText; } set { SetProperty(ref _InvButtonText, value); } }

        string _InvStreamButtonText = "Start Inventory Stream";
        public string InvStreamButtonText { get { return _InvStreamButtonText; } set { SetProperty(ref _InvStreamButtonText, value); } }

        bool _InvButtonState = false;
        public bool InvButtonState { get { return _InvButtonState; } set { SetProperty(ref _InvButtonState, value); } }

        string _InventoryInfo = "Idle";
        public string InventoryInfo { get { return _InventoryInfo; } set { SetProperty(ref _InventoryInfo, value); } }

        bool mStreamRunning = false;

        DispatcherTimer mUiUpdateTimer;

        public InventoryPageViewModel()
        {
            mUiUpdateTimer = new DispatcherTimer();
            mUiUpdateTimer.Tick += MUiUpdateTimer_Tick;
            mUiUpdateTimer.Interval = TimeSpan.FromMilliseconds(200);
        }

        protected internal override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Page hidden

            if (mStreamRunning && App.NurApi.IsConnected())
            {
                // Stop inventory id running
                Task.Run(() =>
                {
                    mStreamRunning = false;
                    App.NurApi.StopInventoryStream();
                    App.NurApi.EnableInvStreamZeros = false;
                });
            }

            // Detach events
            App.NurApi.ConnectedEvent -= Api_ConnectedEvent;
            App.NurApi.DisconnectedEvent -= Api_DisconnectedEvent;
            App.NurApi.InventoryStreamEvent -= NurApi_InventoryStreamEvent;

            // Stop UI timer
            mUiUpdateTimer.Stop();
        }

        protected internal override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Page shown

            // Update UI
            if (App.NurApi.IsConnected())
                Api_ConnectedEvent(App.NurApi, new NurApi.NurEventArgs(0));
            else
                Api_DisconnectedEvent(App.NurApi, new NurApi.NurEventArgs(0));

            // Attach events
            App.NurApi.ConnectedEvent += Api_ConnectedEvent;
            App.NurApi.DisconnectedEvent += Api_DisconnectedEvent;
            App.NurApi.InventoryStreamEvent += NurApi_InventoryStreamEvent;

            // Start update timer
            mUiUpdateTimer.Start();
        }

        private void MUiUpdateTimer_Tick(object sender, object e)
        {
            // Update UI listview from unique tag dictionary
            foreach(var pair in InventoriedTagsDict)
            {
                if (!pair.Value.UiAdded)
                {
                    //System.Diagnostics.Debug.WriteLine("ADD " + pair.Value.EPC);
                    InventoriedTags.Add(pair.Value);
                    pair.Value.UiAdded = true;
                    pair.Value.UiUpdated = false;
                }
                else if (pair.Value.UiUpdated)
                {
                    //System.Diagnostics.Debug.WriteLine("UPD " + pair.Value.EPC);
                    pair.Value.Update();
                    pair.Value.UiUpdated = false;
                }
            }

            // Update stats to UI
            InventoryInfo = string.Format("Tags: Total {0} Unique {1} In time {5:0.0}  |  Speed: Now {2:0.0} Avg {3:0.0} Peak {4:0.0}  |  Inventory Rounds {6}",
                mTagsReadTotal, InventoriedTagsDict.Count,
                mTagsPerSec, mAvgTagsPerSec, mMaxTagsPerSec,
                mTagsFoundInTime,
                mInventoryRounds);
        }

        // Stats
        static double TAGS_PER_SEC_OVERTIME = 2;
        private AvgBuffer mTagsPerSecBuffer = new AvgBuffer(1000, (int)(TAGS_PER_SEC_OVERTIME * 1000));

        private long mTagsReadTotal = 0;
        private double mTagsPerSec = 0;
        private double mAvgTagsPerSec = 0;
        private double mMaxTagsPerSec = 0;
        private int mInventoryRounds = 0;
        private double mTagsFoundInTime = 0;
        Stopwatch mInventoryStart = new Stopwatch();

        void ClearStats()
        {
            mTagsReadTotal = 0;
            mTagsPerSec = 0;
            mAvgTagsPerSec = 0;
            mMaxTagsPerSec = 0;
            mInventoryRounds = 0;
            mTagsFoundInTime = 0;
            mInventoryStart.Stop();
            mInventoryStart.Reset();
        }

        void UpdateStats(NurApi.InventoryStreamData ev)
        {
            mTagsPerSecBuffer.Add(ev.tagsAdded);
            mTagsReadTotal += ev.tagsAdded;

            mTagsPerSec = mTagsPerSecBuffer.SumValue / TAGS_PER_SEC_OVERTIME;
            if (mInventoryStart.ElapsedMilliseconds > 1000)
                mAvgTagsPerSec = mTagsReadTotal / ((double)mInventoryStart.ElapsedMilliseconds / 1000.0);
            else
                mAvgTagsPerSec = mTagsPerSec;

            if (mTagsPerSec > mMaxTagsPerSec)
                mMaxTagsPerSec = mTagsPerSec;

            mInventoryRounds += ev.roundsDone;
        }

        private void NurApi_InventoryStreamEvent(object sender, NurApi.InventoryStreamEventArgs e)
        {
            // Update stats
            UpdateStats(e.data);

            // Update unique tags
            if (UpdateInventoriedTags())
            {
                // New tag(s) found. set time
                mTagsFoundInTime = ((double)mInventoryStart.ElapsedMilliseconds / 1000.0);
            }

            // Restart stream if needed
            if (mStreamRunning && e.data.stopped)
            {
                App.NurApi.StartInventoryStream();
            }
        }

        private async void Api_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                // Update UI
                mStreamRunning = false;
                InvButtonState = false;
                InvButtonText = "Simple Inventory";
                InvStreamButtonText = "Start Inventory Stream";
            });
        }

        private async void Api_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                // Update UI
                InvButtonState = true;
                InvButtonText = "Simple Inventory";
                InvStreamButtonText = "Start Inventory Stream";
            });
        }
        
        // Update our unique tag storage from NurApi tag storage
        // NOTE: UI is not updated here
        bool UpdateInventoriedTags()
        {
            bool ret = false;
            NurApi.TagStorage ts = App.NurApi.GetTagStorage();
            lock (ts)
            {
                foreach (NurApi.Tag tag in ts)
                {
                    if (InventoriedTagsDict.ContainsKey(tag.GetEpcString()))
                    {
                        // Tag updated
                        InventoriedTag iTag = InventoriedTagsDict[tag.GetEpcString()];
                        iTag.Rssi = tag.rssi.ToString();
                        iTag.UiUpdated = true;
                    }
                    else
                    {
                        // New tag added
                        ret = true;
                        InventoriedTag iTag = new InventoriedTag()
                        {
                            EPC = tag.GetEpcString(),
                            Rssi = tag.rssi.ToString()
                        };

                        InventoriedTagsDict.Add(tag.GetEpcString(), iTag);
                    }
                }
            }
            return ret;
        }
        
        // Command executor for inventory button
        public ICommand InventoryCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        // Set UI state while inventory running
                        InvButtonState = false;
                        InvButtonText = "In progress..";
                        InventoriedTags.Clear();
                        InventoriedTagsDict.Clear();
                        ClearStats();

                        // Execute inventory in own task
                        await Task.Run(() =>
                        {
                            // Clear tag storage
                            App.NurApi.ClearTagsEx();

                            // Perform simple inventory
                            mInventoryStart.Start();
                            NurApi.InventoryResponse resp = App.NurApi.Inventory(0,0,0);
                            mInventoryStart.Stop();

                            // Update stats
                            mTagsFoundInTime = ((double)mInventoryStart.ElapsedMilliseconds / 1000.0);
                            mTagsReadTotal = resp.numTagsFound;
                            mInventoryRounds = resp.roundsDone;

                            // Read tags from device
                            if (resp.numTagsFound > 0) {
                                App.NurApi.FetchTags();
                            }
                        });

                        // Update our tag storage
                        UpdateInventoriedTags();
                    }
                    catch (Exception ex)
                    {
                        await App.ShowException(ex);
                    }
                    finally
                    {
                        // Update UI
                        InvButtonState = App.NurApi.IsConnected();
                        InvButtonText = "Simple Inventory";
                    }
                });
            }
        }

        // Command executor for inventory stream button
        public ICommand InventoryStreamCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        InvButtonState = false;
                        if (!App.NurApi.IsInventoryStreamRunning())
                        {
                            // Set UI state while starting
                            InvStreamButtonText = "Starting..";
                            InventoriedTags.Clear();
                            InventoriedTagsDict.Clear();
                            ClearStats();

                            // Start inventory stream in own task
                            await Task.Run(() =>
                            {
                                // Enable zero readings for stats update
                                App.NurApi.EnableInvStreamZeros = true;
                                // Clear tag storage
                                App.NurApi.ClearTagsEx();
                                // Start stream
                                mInventoryStart.Start();
                                App.NurApi.StartInventoryStream();
                                mStreamRunning = true;
                            });
                        }
                        else
                        {
                            // Set UI while stopping
                            InvStreamButtonText = "Stopping..";

                            // Stop stream in own task
                            await Task.Run(() =>
                            {
                                mStreamRunning = false;
                                // Stop
                                App.NurApi.StopInventoryStream();
                                // Reset zero readings
                                App.NurApi.EnableInvStreamZeros = false;
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        await App.ShowException(ex);
                    }
                    finally
                    {
                        // Update UI
                        InvButtonState = App.NurApi.IsConnected();
                        mStreamRunning = App.NurApi.IsInventoryStreamRunning();
                        if (App.NurApi.IsInventoryStreamRunning())
                            InvStreamButtonText = "Stop Inventory Stream";
                        else
                            InvStreamButtonText = "Start Inventory Stream";
                    }
                });
            }
        }
    }
}
