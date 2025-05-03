using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plants.Data;
using System;
using System.Windows.Forms;

namespace Plants
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

                    services.AddDbContext<AppDbContext>(options =>
                        options
                            .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                            .LogTo(Console.WriteLine)
                    );
                })
                .Build();

            if (args.Length > 0 && args[0] == "--seed") // argument --seed do seedowanie
            {
                SeedDatabase(host);
                return;
            }

            Application.Run(new MainCareForm());
        }

        private static void SeedDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AppDbContext>();
                DataSeeder.SeedInitialData(context);
                Console.WriteLine("Dane zosta�y za�adowane!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"B��d: {ex.Message}");
            }
        }
    }
}
