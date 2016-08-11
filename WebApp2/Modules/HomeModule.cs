using Nancy;

namespace WebApp2.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters => this.View["index.cshtml"];
        }
    }
}