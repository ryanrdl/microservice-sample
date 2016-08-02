using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PongApi
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            BusFactory.Init();

            var host = new WebHostBuilder()
                .UseUrls(PongConfiguration.GetUseUrls())
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
