using System.Collections.ObjectModel;
using Windows.UI.Xaml.Navigation;

namespace Mvvm
{
    internal class ViewModelBase : BindableBase
    {
        public ViewModelBase()
        {
        }

        protected internal virtual void OnNavigatedFrom(NavigationEventArgs e)
        {
            
        }

        protected internal virtual void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }
    }
}
