namespace PongService
{
    using System;
    using PongMessages.Commands;

    public class Program
    { 
        public static void Main(string[] args)
        {
            PongConfiguration.RabbitMQConnectionString = "host=10.2.17.218;username=test;password=test;VirtualHost=demo";
            PongConfiguration.MongoDbConnectionString = "mongodb://test:test@ds033015.mlab.com:33015/microservice-demo";
            PongConfiguration.NServiceBusLicensePath = "c:\\dev\\NSBLicense.xml";
            
            var host = new PongHost();

            host.Start();

            while (Menu(host))
            {
                
            }
        }

        public static bool Menu(PongHost host)
        {
            var pings = host.GetPings();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------------------");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- Select an option below:       -");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------------------");

            Console.ForegroundColor = ConsoleColor.White;
          
            foreach (var item in pings)
            {
                Console.WriteLine($"({item.Key}) Repond {item.Value}");
            }

            Console.WriteLine("- (Q)uit");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------------------");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" : ");

            var input = Console.ReadLine() ?? "";

            if (input == "q") return false;

            int index;
            if (int.TryParse(input, out index))
            {
                PongHost.Repond(index, relay => host.Send(new SendPong {Relay = relay}));
            } 

            Console.Clear();
            return true;
        }
    }
}