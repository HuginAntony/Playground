using System;
using Microsoft.Owin.Hosting;

namespace OwinSelfHostWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Listening on port http://localhost:9000/");
                Console.WriteLine("Press enter to stop.");
                Console.ReadLine();
            }
        }
    }
}
