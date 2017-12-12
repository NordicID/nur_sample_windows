using System;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace Mvvm.Services
{
    public static class Navigation
    {
        private static Frame _frame;
        private static readonly EventHandler<BackRequestedEventArgs> GoBackHandler = (s, e) => Navigation.GoBack();

        public static Frame Frame
        {
            get { return _frame; }
            set { _frame = value; }
        }

        public static bool Navigate(Type sourcePageType)
        {
            if (_frame.CurrentSourcePageType != sourcePageType)
            {
                return _frame.Navigate(sourcePageType);
            }

            return true;
        }

        public static void EnableBackButton()
        {
            var navManager = SystemNavigationManager.GetForCurrentView();
            navManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            navManager.BackRequested -= GoBackHandler;
            navManager.BackRequested += GoBackHandler;
        }

        public static void DisableBackButton()
        {
            var navManager = SystemNavigationManager.GetForCurrentView();
            navManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            navManager.BackRequested -= GoBackHandler;
        }

        public static void GoBack()
        {
            if (_frame.CanGoBack)
            {
                _frame.GoBack();
            }
        }
    }
}
