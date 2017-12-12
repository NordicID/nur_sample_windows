using Mvvm.Services;
using System.Collections.ObjectModel;
using NurApiSampleMvvm;
using Windows.ApplicationModel.Core;

namespace Mvvm
{
    internal class ShellViewModel
    {
        private static readonly ObservableCollection<MenuItem> AppMenu = new ObservableCollection<MenuItem>();
        private static readonly ObservableCollection<MenuItem> AppSecondMenu = new ObservableCollection<MenuItem>();

        public ObservableCollection<MenuItem> Menu => AppMenu;
        public ObservableCollection<MenuItem> SecondMenu => AppSecondMenu;

        public ShellViewModel()
        {
            // Build the menus
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("ConnPageIcon"), Text = "Connection", NavigationDestination = typeof(ConnPage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("InventoryPageIcon"), Text = "Inventory", NavigationDestination = typeof(InventoryPage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("AccessoryDevPageIcon"), Text = "Accessory", NavigationDestination = typeof(AccessoryDevPage) });

            SecondMenu.Add(new MenuItem() { Glyph = Icon.GetIcon("GearIcon"), Text = "Settings", NavigationDestination = typeof(SettingsPage) });
            SecondMenu.Add(new MenuItem() { Glyph = Icon.GetIcon("InfoIcon"), Text = "About", NavigationDestination = typeof(AboutPage) });
        }
    }
}
