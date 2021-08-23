using Lab2.TaskManagerApi.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.TaskManagerApi
{
    public class Program
    {
        private static bool _isSeed = true;

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            if (_isSeed)
            {
                using var scope = host.Services.CreateScope();
                var service = scope.ServiceProvider;

                try
                {
                    SeedData.Initialize(service);
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("An error occured seeding the Db", nameof(service));
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occured seeding the Db: {ex.Message}");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("" +
                        "http://localhost:5000",
                        "https://localhost:5001",
                        "http://192.168.0.8:7000",
                        "https://192.168.0.8:5001");
                });
    }
}
