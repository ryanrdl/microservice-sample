namespace PongService
{
    using System;
    using PongMessages.Commands;

    public class Program
    { 
        public static void Main(string[] args)
        {
            var host = new PongHost();

            host.Start();

#if DEBUG
            while (Menu(host))
            {

            }
#else
            Console.Read();
#endif
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