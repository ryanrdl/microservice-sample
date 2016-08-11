
using Microsoft.Owin;
using WebApp2;

[assembly: OwinStartup(typeof(Startup))]
namespace WebApp2
{ 
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            BusFactory.Init();
            app.MapSignalR(); //this has to come before UseNancy or signalr/hubs will not be found on the client
            app.UseNancy();
        }
    }
}