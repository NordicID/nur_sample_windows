using Mvvm;
using NurApiDotNet.UWP;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NurApiSampleMvvm
{
    public sealed partial class InventoryPage : Page
    {
        internal InventoryPageViewModel ViewModel { get { return InventoryPageViewModel.Instance(); } }

        public InventoryPage()
        {
            this.InitializeComponent();
            DataContext = ViewModel;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e) => ViewModel.OnNavigatedFrom(e);
        protected override void OnNavigatedTo(NavigationEventArgs e) => ViewModel.OnNavigatedTo(e);
    }
}
