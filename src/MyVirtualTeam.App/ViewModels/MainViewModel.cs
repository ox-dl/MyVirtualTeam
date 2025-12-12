using Microsoft.Win32;
using MyVirtualTeam.App.Views;
using MyVirtualTeam.Core.Utils;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


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

    public class MainViewModel : BaseViewModel
    {
        private UserControl _currentView = null!;
        private readonly SettingsViewModel _settingsViewModel;
        private readonly Dictionary<string, UserControl> _viewDictionary;
        private string _projectFilePath = string.Empty;

        public ICommand NavigateCommand { get; }
        public ICommand LoadProjectCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand ChangeThemeCommand { get; }

        public UserControl CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public string ProjectFilePath
        {
            get { return _projectFilePath; }
            set { _projectFilePath = value; OnPropertyChanged(); }
        }

        public Dictionary<string, UserControl> ViewDictionary => _viewDictionary;

        public MainViewModel(SettingsViewModel settingsViewModel)
        {
            _settingsViewModel = settingsViewModel;
            _viewDictionary = new Dictionary<string, UserControl>
            {
                { "Home", new HomeView() },
                { "NewProject", new NewProjectView() },
                { "VirtualMachines", new VirtualMachinesView() },
                { "Events", new EventsView() },
                { "Sequences", new SequencesView() },
                { "Settings", new SettingsView() }
            };

            NavigateCommand = new RelayCommand<string>(Navigate);
            LoadProjectCommand = new RelayCommand<object>(_ => OpenFileDialog());
            ExitCommand = new RelayCommand<object>(_ => ExitApplication());
            ChangeThemeCommand = new RelayCommand<string>(ChangeTheme);

            CurrentView = _viewDictionary["Home"];
        }

        private void OpenFileDialog()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Project (*.myproj)|*.myproj|All files (*.*)|*.*",
                Title = "Open a project"
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                ProjectFilePath = openFileDialog.FileName;
                Debug.WriteLine($"The project has been loaded: {ProjectFilePath}");

                //LoadProject(ProjectFilePath);
            }
            else
            {
                Debug.WriteLine("No file has been selected.");
            }
        }

        public void Navigate(string viewName)
        {
            if (!string.IsNullOrEmpty(viewName) && _viewDictionary.TryGetValue(viewName, out var userControl))
            {
                CurrentView = userControl;
            }
        }

        private void ChangeTheme(string theme)
        {
            _settingsViewModel.CurrentTheme = theme;
        }

        private static void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
