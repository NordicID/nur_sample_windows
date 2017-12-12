namespace Mvvm.Services
{
    public static class Icon
    {
        public static string GetIcon(string name)
        {
            try
            {
                return (string)Windows.UI.Xaml.Application.Current.Resources[name];
            }
            catch
            {
                // If not found, use default
                return "F1 M 16,12 20,2L 20,16 1,16";
            }
        }
    }
}
