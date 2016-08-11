namespace WebApp2
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
            this._clients = GlobalHost.ConnectionManager.GetHubContext<MessageHub>().Clients;
        }

        public void Handle(PingReceived message)
        {
            this._clients.All.pingReceived(message);
        }

        public void Handle(PingComplete message)
        {
            this._clients.All.pingComplete(message);
        }

        public void Handle(PingFailed message)
        {
            this._clients.All.pingFailed(message);
        }
    }

    public class MessageHub : Hub
    {
         
    }
}
