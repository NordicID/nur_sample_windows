using System.Diagnostics;
using Mvvm;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Mvvm.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NurApiSampleMvvm
{
    public partial class Shell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string mConnInfo;
        public string ConnInfo
        {
            get { return mConnInfo; }
            set { mConnInfo = value; OnPropertyChanged(); }
        }

        public Shell()
        {
            ((App)Application.Current).PropertyChanged += App_PropertyChanged;
            InitializeComponent();

            // Navigate to the home page.
            Navigation.Frame = SplitViewFrame;
            Navigation.Navigate(typeof(ConnPage));
        }

        // Proxy App.ConnInfo to this view ConnInfo
        private void App_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ConnInfo") {
                ConnInfo = App.ConnInfo;
            }
        }

        // Navigate to another page.
        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                // Unselect the other menu.
                if ((sender as ListView) == Menu)
                {
                    SecondMenu.SelectedItem = null;
                }
                else
                {
                    Menu.SelectedItem = null;
                }

                var menuItem = e.AddedItems.First() as MenuItem;
                if (menuItem != null)
                {
                    Navigation.Navigate(menuItem.NavigationDestination);
                }
            }
        }
        
        // Swipe to open the splitview panel.
        private void SplitViewOpener_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X > 50)
            {
                MySplitView.IsPaneOpen = true;
            }
        }

        // Swipe to close the splitview panel.
        private void SplitViewPane_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X < -50)
            {
                MySplitView.IsPaneOpen = false;
            }
        }

        // Open or close the splitview panel through Hamburger button.
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void SplitViewFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            // Lookup destination type in menu(s)
            var item = (from i in Menu.Items
                        where (i as MenuItem).NavigationDestination == e.SourcePageType
                        select i).FirstOrDefault();
            if (item != null)
            {
                Menu.SelectedItem = item;
                return;
            }

            Menu.SelectedIndex = -1;

            item = (from i in SecondMenu.Items
                    where (i as MenuItem).NavigationDestination == e.SourcePageType
                    select i).FirstOrDefault();
            if (item != null)
            {
                SecondMenu.SelectedItem = item;
                return;
            }

            SecondMenu.SelectedIndex = -1;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Navigation.EnableBackButton();
            base.OnNavigatedTo(e);
        }

        private static void Shell_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Navigation.GoBack();
        }
    }
}
