using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PingApi
{
    using System;
    using Microsoft.Extensions.Configuration;
    using RabbitMQ.Client.Framing;

    public class Program
    {
        public static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            var currentDirectory = Directory.GetCurrentDirectory();

            BusFactory.Init();

            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddEnvironmentVariables()
                .AddJsonFile("hosting.json", optional: true)
                .AddCommandLine(args)
                .Build();

            var host = new WebHostBuilder() 
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
