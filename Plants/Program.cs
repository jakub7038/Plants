using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plants.Data;
using Plants.Data.Helpers;
using System;
using System.Windows.Forms;
using Plants.Forms;
using Plants.Helpers;


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

            if (args.Length > 0 && args[0] == "--clean") // argument --clean do czyszczenia bazy danych
            {
                CleanDatabase(host);
                return;
            }

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    if (!context.Database.CanConnect())
                    {
                        MessageBox.Show(
                            "Nie mo�na nawi�za� po��czenia z baz� danych. Aplikacja zostanie zamkni�ta.",
                            "B��d po��czenia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Wyst�pi� b��d podczas pr�by po��czenia z baz� danych:\n{ex.Message}",
                        "B��d po��czenia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new PlantManagerForm());
        }

        static void SeedDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AppDbContext>();
                DatabaseSeeder.Seed(context);
                Console.WriteLine("Dane zosta�y za�adowane pomy�lnie!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"B��d podczas seedowania bazy danych: {ex.Message}");
            }
        }

        static void CleanDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AppDbContext>();
                DatabaseCleaner.Clean(context);
                Console.WriteLine("Baza zosta�a wyczyszczona pomy�lnie!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"B��d podczas czyszczenia bazy danych: {ex.Message}");
            }
        }
    }
}
