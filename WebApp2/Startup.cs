
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
            app.UseNancy();
            app.MapSignalR();
        }
    }
}