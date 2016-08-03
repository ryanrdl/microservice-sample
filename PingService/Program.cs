namespace PingService
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new PingHost();

            host.Start();

#if DEBUG
            while (Menu(host))
            {

            }
#else
            Console.Read();
#endif

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