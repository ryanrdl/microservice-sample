using Microsoft.Owin;
using WebApp;

[assembly: OwinStartup(typeof(Startup))]
namespace WebApp
{
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}