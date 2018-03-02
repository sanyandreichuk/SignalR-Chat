using System;
using System.Threading.Tasks;
using ChatClient.Models;


namespace ChatClient.Services
{
    public interface IChatServices
    {
        Task ConnectAsync();
        Task SendAsync(Message message);
        event EventHandler<Message> OnMessageReceived;
    }
}
