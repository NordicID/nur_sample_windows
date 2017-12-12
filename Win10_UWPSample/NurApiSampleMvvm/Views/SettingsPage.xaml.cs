using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Mvvm;
using Mvvm.Services;
using Windows.ApplicationModel.Core;

namespace NurApiSampleMvvm
{
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        public ICommand ExitCommand => new DelegateCommand(() => { CoreApplication.Exit(); } );
    }
}
