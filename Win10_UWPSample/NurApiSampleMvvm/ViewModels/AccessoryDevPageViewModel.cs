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
using Windows.UI.Popups;

namespace Mvvm
{
    public class ListViewStringItem : BindableBase
    {
        public ListViewStringItem(string t) { mText = t; }

        string mText = "";
        public string Text { get { return mText; } set { SetProperty(ref mText, value); } }
    }

    internal class AccessoryDevPageViewModel : ViewModelBase
    {
        // Global instance of view model
        static AccessoryDevPageViewModel _instance;
        internal static AccessoryDevPageViewModel Instance()
        {
            if (_instance == null)
                _instance = new AccessoryDevPageViewModel();
            return _instance;
        }

        static ushort BARCODE_TIMEOUT = 5000;

        bool mBarcodeReading = false;
        bool mIgnoreNextTrigger = false;
        bool mCancelRequested = false;
        int mBarcodeStartTime = 0;

        // Event listview entries
        public ObservableCollection<ListViewStringItem> ListViewEntries = new ObservableCollection<ListViewStringItem>();

        // Accessory info string, bound to UI control
        string mAccInfo = "";
        public string AccInfo { get { return mAccInfo; } set { SetProperty(ref mAccInfo, value); } }

        // Buttons enable state, bound to UI control
        bool mButtonState = false;
        public bool ButtonState { get { return mButtonState; } set { SetProperty(ref mButtonState, value); } }

        public AccessoryDevPageViewModel()
        {
            AddListViewEntry("Events are shown in this list");
        }

        // Add entry on top of listview
        void AddListViewEntry(string txt)
        {
            ListViewEntries.Insert(0, new ListViewStringItem(txt));
        }

        protected internal override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Page hidden

            // Detach events
            App.NurApi.ConnectedEvent -= Api_ConnectedEvent;
            App.NurApi.DisconnectedEvent -= Api_DisconnectedEvent;
            App.NurApi.AccessoryEvent -= NurApi_AccessoryEvent;
            App.NurApi.IOChangeEvent -= NurApi_IOChangeEvent;
        }

        protected internal override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Page shown
            ButtonState = false;

            // Update UI
            if (App.NurApi.IsConnected())
                Api_ConnectedEvent(App.NurApi, new NurApi.NurEventArgs(0));
            else
                Api_DisconnectedEvent(App.NurApi, new NurApi.NurEventArgs(0));

            // Attache events
            App.NurApi.ConnectedEvent += Api_ConnectedEvent;
            App.NurApi.DisconnectedEvent += Api_DisconnectedEvent;
            App.NurApi.AccessoryEvent += NurApi_AccessoryEvent;
            App.NurApi.IOChangeEvent += NurApi_IOChangeEvent;
        }

        private void NurApi_IOChangeEvent(object sender, NurApi.IOChangeEventArgs e)
        {
            if (e.data.source == 100) // 100 == Accessory device trigger
            {
                if (e.data.dir == 1)
                {
                    // Trigger pressed
                } else {
                    // Trigger released

                    // Ignore if cancelled by device
                    if (!mIgnoreNextTrigger) {
                        BarcodeCommand.Execute(null);
                    }
                    mIgnoreNextTrigger = false;
                }
            }
        }

        private async void NurApi_AccessoryEvent(object sender, NurApi.AccessoryEventArgs e)
        {
            if (e.type == NurApi.AccessoryEventType.Barcode)
            {
                // Fix bug in EXA FW <2.2.1
                // EXA sends incorrectly NUR_ERROR_NO_TAG when cancelled barcode reading by pressing trigger button
                if (e.status == NurApiErrors.NUR_ERROR_NO_TAG && (Environment.TickCount - mBarcodeStartTime) < BARCODE_TIMEOUT) {
                    e.status = NurApiErrors.NUR_ERROR_NOT_READY;                    
                }

                // Detect if barcode reading cancelled by device. In that case we ignore next trigger handling, thus not starting reading again
                if (e.status == NurApiErrors.NUR_ERROR_NOT_READY && !mCancelRequested) {
                    mIgnoreNextTrigger = true;
                }

                // Reset vars
                mCancelRequested = false;
                mBarcodeReading = false;

                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    string barcode = "";
                    if (e.status == 0)
                    {
                        // OK
                        barcode = App.NurApi.AccBarcodeRead(e.data);

                        Task.Run(() =>
                        {
                            try { App.NurApi.AccBeep(100); } catch { }
                        });
                    }
                    else if (e.status == NurApiErrors.NUR_ERROR_NO_TAG)
                    {
                        // Timeout
                        barcode = "No barcode found";
                    }
                    else if (e.status == NurApiErrors.NUR_ERROR_NOT_READY)
                    {
                        // Cancelled
                        barcode = "Cancelled";                        
                    }
                    else if (e.status == NurApiErrors.NUR_ERROR_HW_MISMATCH)
                    {
                        // Barcode HW not available in device
                        barcode = "HW not present";
                    }
                    else
                    {
                        // Unknown error
                        barcode = "ERROR " + e.status;
                    }

                    AddListViewEntry("Barcode: " + barcode);
                });
            }
        }

        private async void Api_DisconnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                // Update UI
                ButtonState = false;
                AccInfo = "Disconnected";
            });
        }

        private async void Api_ConnectedEvent(object sender, NurApi.NurEventArgs e)
        {
            NurApi.AccessoryFWInfo? accFwInfo = null;
            string connInfo = "";

            try
            {
                // Get accessory device info
                await Task.Run(() =>
                {
                    accFwInfo = App.NurApi.AccGetFwInfo();
                    connInfo = App.NurApi.AccGetConnectionInfo();
                });
            }
            catch (Exception ex)
            {
                if (ex is NurApiException && (ex as NurApiException).error == NurApiErrors.NUR_ERROR_INVALID_COMMAND)
                {
                    // This is not accessory device
                    accFwInfo = null;
                }
                else
                {
                    await App.ShowException(ex);
                    return;
                }
            }

            // Update UI
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                ButtonState = true;

                if (accFwInfo != null)
                {
                    AccInfo = string.Format("Accessory FW version: {0}; Connection info: {1}", accFwInfo?.FullAppVersion, connInfo);
                }
                else
                {
                    AccInfo = "Connected device does not support accessory device commands";
                }
            });
        }
        
        // Command executor for barcode button
        public ICommand BarcodeCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        // Exec nurapi command in own task
                        await Task.Run(() =>
                        {
                            if (mBarcodeReading)
                            {
                                // Cancel
                                mCancelRequested = true;
                                mBarcodeReading = false;
                                App.NurApi.AccBarcodeCancel();
                            }
                            else
                            {
                                // Start barcode reading
                                mBarcodeStartTime = Environment.TickCount;
                                App.NurApi.AccBarcodeStart(BARCODE_TIMEOUT);
                                mBarcodeReading = true;
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        mBarcodeReading = false;
                        await App.ShowException(ex);                        
                    }
                });
            }
        }

        // Command executor for battery info button
        public ICommand BatteryInfoCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        NurApi.AccessoryBatteryInfo? binfo = null;

                        // Exec nurapi command in own task
                        await Task.Run(() =>
                        {
                            binfo = App.NurApi.AccGetBatteryInfo();
                        });
                        //var dialog = new MessageDialog(string.Format("Battery:\nPercent {0}\nVoltage {1}", binfo?.Percentage, binfo?.Voltage));
                        //await dialog.ShowAsync();
                        AddListViewEntry(string.Format("Battery: {0}% {1}v Charging={2}", binfo?.Percentage, binfo?.Voltage, binfo?.Charging));
                    }
                    catch (Exception ex)
                    {
                        await App.ShowException(ex);
                    }
                });
            }
        }

        // Command executor for beep button
        public ICommand BeepCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        AddListViewEntry("Beep 1000ms");

                        // Exec nurapi command in own task
                        await Task.Run(() =>
                        {
                            App.NurApi.AccBeep(1000);
                        });
                    }
                    catch (Exception ex)
                    {
                        if (ex is NurApiException && (ex as NurApiException).error == NurApiErrors.NUR_ERROR_HW_MISMATCH)
                        {
                            AddListViewEntry("Beeper not supported in this device");
                        }
                        else
                        {
                            await App.ShowException(ex);
                        }
                    }
                });
            }
        }

        // Command executor for vibra button
        public ICommand VibraCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        AddListViewEntry("Vibrate 1000ms");

                        // Exec nurapi command in own task
                        await Task.Run(() =>
                        {
                            App.NurApi.AccVibrate(1000, 1);
                        });
                    }
                    catch (Exception ex)
                    {
                        if (ex is NurApiException && (ex as NurApiException).error == NurApiErrors.NUR_ERROR_HW_MISMATCH)
                        {
                            AddListViewEntry("Vibrate not supported in this device");
                        }
                        else
                        {
                            await App.ShowException(ex);
                        }
                    }
                });
            }
        }
    }
}
