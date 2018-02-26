using Microsoft.AspNetCore.SignalR;

namespace ChatBackend.Hubs
{
    public class ChatHub : Hub
    {
        public void SendToAll(string name, double message)
        {
            Clients.All.InvokeAsync("sendToAll", name, message);
        }
    }
}
