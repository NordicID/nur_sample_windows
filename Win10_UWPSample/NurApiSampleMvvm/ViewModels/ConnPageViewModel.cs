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
using Windows.UI.Popups;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;

namespace Mvvm
{
    internal class ConnPageViewModel : ViewModelBase
    {
        // Global instance of view model
        static ConnPageViewModel _instance;
        internal static ConnPageViewModel Instance()
        {
            if (_instance == null)
                _instance = new ConnPageViewModel();
            return _instance;
        }

        // List of known devices shown in UI listview
        public ObservableCollection<NurDeviceWatcherInfo> KnownDevices = new ObservableCollection<NurDeviceWatcherInfo>();

        // Device watcher
        NurDeviceWatcher mDevWatcher;

        // Connect button text, bound to UI control
        string mConnButtonText = "Connect";
        public string ConnButtonText { get { return mConnButtonText; } set { SetProperty(ref mConnButtonText, value); } }

        // Connect button enable state, bound to UI control
        bool mConnButtonState = true;
        public bool ConnButtonState { get { return mConnButtonState; } set { SetProperty(ref mConnButtonState, value); } }

        // Connection device spec string, bound to UI control
        string mDeviceSpec;
        public string DeviceSpecStr { get { return mDeviceSpec; } set { SetProperty(ref mDeviceSpec, value); } }

        // Connection info text, bound to UI control (shell)
        public string ConnInfo
        {
            get { return App.ConnInfo; }
            set { App.ConnInfo = value; }
        }

        // Settings instance
        Windows.Storage.ApplicationDataContainer mLocalSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        
        public ConnPageViewModel()
        {
            // Start device watcher
            mDevWatcher = new NurDeviceWatcher();
            mDevWatcher.DeviceAdded += DevWatcher_DeviceAdded;
            mDevWatcher.DeviceRemoved += DevWatcher_DeviceRemoved;
            mDevWatcher.DeviceUpdated += DevWatcher_DeviceUpdated;
            mDevWatcher.Start();

            // Load previous connection device spec from settings
            if (mLocalSettings.Values.ContainsKey("devicespec"))
                DeviceSpecStr = mLocalSettings.Values["devicespec"].ToString();

            ConnInfo = "Disconnected";
        }
        
        // This is called for each NurApi instance
        void AttachNurApiEvents(NurApi api)
        {
            System.Diagnostics.Debug.WriteLine("InitNurApi v" + api.GetFileVersion());

            // Enable all logs
            //api.SetLogLevel(NurApi.LOG_ERROR | NurApi.LOG_USER | NurApi.LOG_VERBOSE | NurApi.LOG_DATA);
            //api.SetLogLevel(NurApi.LOG_ERROR | NurApi.LOG_USER | NurApi.LOG_VERBOSE);

            // Attach NurApi events
            api.LogEvent += NurApi_LogEvent;
            api.ConnectedEvent += Api_ConnectedEvent;
            api.DisconnectedEvent += Api_DisconnectedEvent;
            api.TransportConnStateChanged += Api_TransportConnStateChanged;
        }

        // This event gets called by NurApiTransport on connection state change.
        // NOTE: Transport level connection states are not same as NurApi Connected/Disconnected event states.
        private void Api_TransportConnStateChanged(object sender, EventArgs e)
        {
            NurApi api = sender as NurApi;
            System.Diagnostics.Debug.WriteLine("Api_TransportConnStateChanged " + api.Transport.ConnState);

            NurDeviceWatcherInfo info = api.UserData as NurDeviceWatcherInfo;
            // We're only interested about Connecting state
            if (api.Transport.ConnState == NurApiTransport.State.Connecting && info != null)
            {
                // Not awaited in purpose
                CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    // Update listview entry
                    info.ConnState = api.Transport.ConnState;
                    info.UpdateInfo();
                });
            }
        }

        // NurApi logs
        private void NurApi_LogEvent(object sender, NurApi.LogEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.message);
        }

        // This is called when NurApi is fully disconnect (and released resources)
        private async void Api_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            NurApi connApi = sender as NurApi;

            System.Diagnostics.Debug.WriteLine("Api_DisconnectedEvent " + sender);

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                NurDeviceWatcherInfo knownDev = connApi.UserData as NurDeviceWatcherInfo;

                // Update listview entry
                knownDev.ConnState = NurApiTransport.State.Disconnected;
                knownDev.UpdateInfo();

                if (knownDev == SelectedDev)
                {
                    // Set UI text's
                    ConnButtonText = "Connect";
                    ConnInfo = "Disconnected";
                }
            });
        }

        // This is called when NurApi is fully connected to device and ready to communicate
        private async void Api_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Api_ConnectedEvent");

            NurApi connApi = sender as NurApi;
            App.NurApi = connApi;

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                NurDeviceWatcherInfo knownDev = connApi.UserData as NurDeviceWatcherInfo;

                // Save connect spec to settings
                //mLocalSettings.Values["devicespec"] = DeviceSpecStr;
                mLocalSettings.Values["devicespec"] = knownDev.SpecStr;

                // Update listview entry
                knownDev.ConnState = NurApiTransport.State.Connected;
                knownDev.UpdateInfo();

                if (knownDev == SelectedDev)
                {
                    ConnButtonText = "Disconnect";
                }
            });

            // Update reader info
            await Task.Run(async () =>
            {
                try
                {
                    NurApi.ReaderInfo rdrInfo = App.NurApi.GetReaderInfo();
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        ConnInfo = string.Format("Connected {0}  |  Serial {1}  |  FW {2}", rdrInfo.name, rdrInfo.serial, rdrInfo.GetVersionString());
                    });
                }
                catch (Exception ex)
                {
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                    {
                        ConnInfo = "Error";
                        await App.ShowException(ex);
                    });
                }
            });
        }

        private async void DevWatcher_DeviceUpdated(object sender, NurDeviceWatcherInfo e)
        {
            // We must update the item on the UI thread because the item is databound to a UI element.
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                // Update listview item
                e.UpdateInfo();
            });
        }

        private async void DevWatcher_DeviceRemoved(object sender, NurDeviceWatcherInfo e)
        {
            // Free api instance
            NurApi api = e.Tag as NurApi;
            if (api != null) {
                api.Dispose();
                api = null;
            }

            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                KnownDevices.Remove(e);
            });
        }

        private async void DevWatcher_DeviceAdded(object sender, NurDeviceWatcherInfo e)
        {
            // Create new api instance for known device
            NurApi api = new NurApi();
            api.UserData = e;
            e.Tag = api;
            AttachNurApiEvents(api);

            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                // Attempt to find known device with same address
                // This might be true, if known device is added manually
                NurDeviceWatcherInfo devToDelete = null;
                foreach (var dev in KnownDevices)
                {
                    if (dev.Address == e.Address)
                    {
                        devToDelete = dev;
                        break;
                    }
                }
                if (devToDelete != null) {
                    DevWatcher_DeviceRemoved(sender, devToDelete);
                }
                
                KnownDevices.Add(e);
            });
        }

        // Selected device listview item. NOTE: Bound to UI
        NurDeviceWatcherInfo mSelectedDev;
        public NurDeviceWatcherInfo SelectedDev
        {
            get { return mSelectedDev; }
            set
            {
                mSelectedDev = value;
                if (value != null)
                {
                    NurDeviceSpec spec = value.Spec;
                    // Set connect spec. "type" and "addr" are enough for connect
                    DeviceSpecStr = string.Format("type={0};addr={1}", spec.GetTransportType(), spec.GetAddress());

                    NurApi api = value.Tag as NurApi;
                    App.NurApi = api;

                    if (api.IsConnected())
                    {
                        Api_ConnectedEvent(value.Tag, new NurApi.NurEventArgs(0));
                    }
                    else if (value.ConnState == NurApiTransport.State.Connecting)
                    {
                        ConnButtonText = "Cancel connect";
                    }
                    else
                    {
                        ConnButtonText = "Connect";
                    }
                    ConnInfo = value.ConnState.ToString();
                }
            }
        }

        // Command executor for connect button
        public ICommand ConnectCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    NurDeviceWatcherInfo targetDev = null;
                    // Attempt to find listview entry with same address
                    NurDeviceSpec connSpec = new NurDeviceSpec(DeviceSpecStr);
                    foreach (var dev in KnownDevices)
                    {
                        if (dev.Address == connSpec.GetAddress())
                        {
                            targetDev = dev;
                            break;
                        }
                    }

                    NurApi api = null;
                    if (targetDev != null)
                    {
                        // Device found in KnownDevices, get api instance
                        api = targetDev.Tag as NurApi;
                    }
                    else
                    {
                        // Not found in KnownDevices, lets add it there
                        targetDev = new NurDeviceWatcherInfo();
                        targetDev.Spec = connSpec;
                        targetDev.Name = "Device";

                        // Create new api instance
                        api = new NurApi();
                        api.UserData = targetDev;
                        targetDev.Tag = api;
                        AttachNurApiEvents(api);

                        KnownDevices.Add(targetDev);
                    }

                    try
                    {
                        if (targetDev.ConnState == NurApiTransport.State.Disconnected)
                        {
                            if (DeviceSpecStr.Length == 0)
                            {
                                var dialog = new MessageDialog("No device selected");
                                await dialog.ShowAsync();
                                return;
                            }
                            ConnButtonText = "Cancel connect";

                            // Connect with device connection spec
                            await api.ConnectAsync(DeviceSpecStr);
                        }
                        else
                        {
                            // Disable button while disconnecting
                            ConnButtonState = false;
                            ConnButtonText = "Disconnecting...";
                            
                            // Disconnect
                            await api.DisconnectAsync();

                            // Enable button
                            ConnButtonState = true;
                            ConnButtonText = "Connect";

                            // Update UI
                            Api_DisconnectedEvent(api, new NurApi.NurEventArgs(0));
                        }
                    }
                    catch (Exception ex)
                    {
                        // Update listview item
                        targetDev.ConnState = NurApiTransport.State.Disconnected;
                        targetDev.UpdateInfo();

                        // If page is hidden, dont bother to do more..
                        if (!mVisible)
                            return;

                        // Update UI
                        Api_DisconnectedEvent(api, new NurApi.NurEventArgs(0));
                        await App.ShowException(ex);
                    }
                });
            }
        }

        bool mVisible = false;
        protected internal override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Page hidden
            mVisible = false;
        }
        protected internal override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Page shown
            mVisible = true;
        }
    }
}
