namespace WebApp2
{
    using System;
    using System.Configuration;
    using Microsoft.Owin.Hosting;

    class Program
    {
        static void Main(string[] args)
        {
            var uri ="http://localhost:3579";

            var z = ConfigurationManager.GetSection("MessageForwardingInCaseOfFaultConfig");
             
            using (WebApp.Start<Startup>(uri))
            { 
                Console.WriteLine("Your application is running on " + uri);
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
            }
        }
    }
}
