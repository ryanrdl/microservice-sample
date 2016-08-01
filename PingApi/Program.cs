using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PingApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BusFactory.Init();

            var host = new WebHostBuilder()
                .UseUrls(PingConfiguration.GetUseUrls())
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
