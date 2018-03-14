using MvvmHelpers;
using Prism.Commands;
using Prism.Navigation;
using ChatClient.Models;
using ChatClient.Services;

namespace ChatClient.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand SendCommand { get; set; }

        public ObservableRangeCollection<Message> Messages { get; }

        private string _outGoingText;
        public string OutGoingText
        {
            get { return _outGoingText; }
            set { SetProperty(ref _outGoingText, value); }
        }

        private IChatServices _chatService;

        public MainPageViewModel(INavigationService navigationService, IChatServices chatService) : base(navigationService)
        {
            _chatService = chatService;

            Title = "SignalR Chat";

            Messages = new ObservableRangeCollection<Message>();

            SendCommand = new DelegateCommand(SendExecute);

            _chatService.OnMessageReceived += OnMessageReceived;
            _chatService.ConnectAsync();
        }

        private void OnMessageReceived(object sender, Message message)
        {
            Messages.Add(message);
        }

        private async void SendExecute()
        {
            var message = new Message {
                Name = "Chater",
                Text = OutGoingText
            };

            await _chatService.SendAsync(message);

            OutGoingText = string.Empty;
        }
    }
}
