namespace WebApp2
{
    using System;
    using Fclp;
    using Microsoft.Owin.Hosting;

    class Program
    {
        static void Main(string[] args)
        {
            var p = new FluentCommandLineParser();

            string uri = null;

            p.Setup<string>('u', "server.urls")
             .Callback(o => uri = o)
             .Required();

            var result = p.Parse(args);

            if (result.HasErrors)
            {
                throw new ArgumentException(result.ErrorText);
            }

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Your application is running on " + uri);
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
            }
        }
    }
}
