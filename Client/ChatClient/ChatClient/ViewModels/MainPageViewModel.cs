using Prism.Navigation;

namespace ChatClient.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "SignalR Chat";
        }
    }
}
