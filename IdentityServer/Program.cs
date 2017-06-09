using System;
using System.Collections.Generic;
using Microsoft.Owin.Hosting;
using Serilog;

namespace IdentityServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "IdentityServer3 w/ WS-Federation SelfHost";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .CreateLogger();

            const string url = "https://localhost:44333/core";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("\n\nServer listening at {0}. Press enter to stop", url);
                Console.ReadLine();
            }
        }
    }
}