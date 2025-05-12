using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plants.Data;
using System;
using System.Windows.Forms;
using Plants.Forms;

namespace Plants
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
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

            ApplicationConfiguration.Initialize();
            Application.Run(new PlantManagerForm());
        }

        private static void SeedDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AppDbContext>();
                DataSeeder.SeedInitialData(context);
                Console.WriteLine("Dane zosta³y za³adowane!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"B³¹d: {ex.Message}");
            }
        }


    }
}
