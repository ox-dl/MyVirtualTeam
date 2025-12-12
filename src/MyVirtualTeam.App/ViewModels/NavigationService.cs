using System.Diagnostics;

namespace MyVirtualTeam.App.ViewModels
{
    public class NavigationService(MainViewModel main)
    {
        private readonly MainViewModel _main = main;

        public void Navigate(string viewName)
        {
            if (!string.IsNullOrEmpty(viewName) && _main.ViewDictionary.TryGetValue(viewName, out var userControl))
            {
                _main.CurrentView = userControl;
            }
            else
            {
                Debug.WriteLine("Error: Attempted navigation to an invalid or null view.");
            }
        }
    }
}
