using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PingApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new PingConfiguration
            {
                RabbitMQConnectionString = "host=10.2.17.218;username=test;password=test;VirtualHost=demo",
                NServiceBusLicensePath = "c:\\dev\\NSBLicense.xml"
            };

            BusFactory.Init(config);

            var host = new WebHostBuilder()
                .UseUrls(config.GetUseUrls())
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
