namespace MyVirtualTeam.App.ViewModels
{
    public class HomeViewModel(MainViewModel mainViewModel) : BaseViewModel
    {
        private readonly MainViewModel _mainViewModel = mainViewModel;
    }
}
