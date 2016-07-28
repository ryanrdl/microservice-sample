namespace PingService
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new PingHost(new PingConfiguration
            {
                RabbitMQConnectionString = "host=10.2.17.218;username=test;password=test;VirtualHost=demo",
                MongoDbConnectionString = "mongodb://test:test@ds033015.mlab.com:33015/microservice-demo",
                NServiceBusLicensePath = "c:\\dev\\NSBLicense.xml"
            });

            host.Start();

            while (Menu(host))
            {

            }
        }

        public static bool Menu(PingHost host)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------------------");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- Select an option below:       -");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------------------");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- (S)end ping");
            Console.WriteLine("- (Q)uit");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------------------");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" : ");
            var input = Console.ReadKey().Key.ToString() ?? "";

            switch (input.ToLower())
            {
                case "s":
                    host.Send(Guid.NewGuid().ToString());
                    break;
                case "q":
                    return false;
            }

            Console.Clear();
            return true;
        }
    }
}