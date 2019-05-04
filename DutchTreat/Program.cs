using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using DutchTreat.Data;

namespace DutchTreat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            //we want to seeding t oDB happen way before the web host so....

            RunSeeding(host);// instantiate and build up the seeder

            host.Run();//run the host later,after instantiate and build up the seeder
        }

        private static void RunSeeding(IWebHost host)
        {

            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<DutchSeeder>();//here we create a instance of "DutchSeeder" object through dependancy injection
                                                                     //because we can use the servises from startup class,because "var host" already generated it for us,
                                                                     //only thing to be happen is there should be a service in startup as a dependancy injection to create a "DutchSeeder" object
                seeder.Seed();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>()
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            //removing the default configuration options
            builder.Sources.Clear();

            builder.AddJsonFile("config.json", false, true)
                //.AddXmlFile("config.xml", true)   ,in that way can add muliple types of configuration files
                .AddEnvironmentVariables();
        }
    }
}
