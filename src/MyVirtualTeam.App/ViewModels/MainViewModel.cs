using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MyVirtualTeam.App.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public virtual string Title => "My Virtual Team";
    }

    public class NavigationService(MainViewModel main)
    {
        private readonly MainViewModel _main = main;

        public void Navigate(BaseViewModel viewModel)
        {
            _main.CurrentView = viewModel;
        }
    }

    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentView;
        public BaseViewModel CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Title));
            }
        }
        public override string Title =>
             CurrentView?.Title ?? "My Virtual Team";
        public MainViewModel()
        {
            _currentView = new HomeViewModel(this);
            Debug.WriteLine("CurrentView = " + CurrentView?.GetType().Name);
        }
    }
}
