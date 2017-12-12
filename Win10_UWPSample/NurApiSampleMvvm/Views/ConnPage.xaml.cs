using Mvvm;
using NurApiDotNet.UWP;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NurApiSampleMvvm
{
    public sealed partial class ConnPage : Page
    {
        internal ConnPageViewModel ViewModel { get { return ConnPageViewModel.Instance(); } }

        public ConnPage()
        {
            this.InitializeComponent();
            DataContext = ViewModel;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e) => ViewModel.OnNavigatedFrom(e);
        protected override void OnNavigatedTo(NavigationEventArgs e) => ViewModel.OnNavigatedTo(e);

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.DeviceSpecStr = ((TextBox)sender).Text;
        }

        private void ListView_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            ViewModel.ConnectCommand.Execute(null);
        }
    }
}
