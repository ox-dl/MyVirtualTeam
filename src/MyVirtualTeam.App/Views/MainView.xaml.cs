using MyVirtualTeam.App.ViewModels;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;

namespace MyVirtualTeam.App.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            var settingsViewModel = new SettingsViewModel();
            DataContext = new MainViewModel(settingsViewModel);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CustomizeTopBarPopup();
        }

        private void CustomizeTopBarPopup()
        {
            var target = AboutBtn;

            if (target != null && target.Template != null)
            {
                if (target.Template.FindName("PART_Popup", target) is Popup popup)
                {
                    popup.Placement = PlacementMode.Right;
                    popup.HorizontalOffset = 4;
                }
                if (target.Template.FindName("PopupPositionRef", target) is Rectangle rectangle)
                {
                    rectangle.HorizontalAlignment = HorizontalAlignment.Right;
                }
            }
        }


    }
}
