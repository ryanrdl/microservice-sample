using System;

namespace WebApp
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    using NServiceBus;
    using PingMessages.Events;

    public class MessageHandler : //Hub, 
        IHandleMessages<PingReceived>,
        IHandleMessages<PingComplete>,
        IHandleMessages<PingFailed>
    {
        private IHubConnectionContext<dynamic> _clients; 
        public MessageHandler()
        {
            _clients = GlobalHost.ConnectionManager.GetHubContext<MessageHub>().Clients;
        }

        public void Handle(PingReceived message)
        {
            _clients.All.pingReceived(message);
        }

        public void Handle(PingComplete message)
        {
            _clients.All.pingComplete(message);
        }

        public void Handle(PingFailed message)
        {
            _clients.All.pingFailed(message);
        }
    }

    public class MessageHub : Hub
    {
         
    }
}
