using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using ChatClient.Models;


namespace ChatClient.Services
{
    public class ChatService : IChatServices
    {
        private readonly HubConnection _connection;
        //private readonly IHubProxy _proxy;

        public event EventHandler<Message> OnMessageReceived;

        public ChatService()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("https://signalxtest.azurewebsites.net/chat")
                .Build();

            _connection.On("sendToAll", (string name, string text) => OnMessageReceived(this, new Message {
                Name = name,
                Text = text
            }));
        }

        public async Task ConnectAsync()
        {
            await _connection.StartAsync();
        }

        public async Task SendAsync(Message message)
        {
            await _connection.InvokeAsync("sendToAll", message.Name, message.Text);
        }
    }
}
