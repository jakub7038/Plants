using Plants.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plants.Data
{
    public static class DataSeeder
    {
        public static void SeedInitialData(AppDbContext context)
        {
            using var transaction = context.Database.BeginTransaction();

            try
            {
                context.Database.ExecuteSqlRaw("DELETE FROM \"CareLogs\"");
                context.Database.ExecuteSqlRaw("DELETE FROM \"Plants\"");
                context.Database.ExecuteSqlRaw("DELETE FROM \"Species\"");
                context.Database.ExecuteSqlRaw("ALTER SEQUENCE \"Species_Id_seq\" RESTART WITH 1");
                context.Database.ExecuteSqlRaw("ALTER SEQUENCE \"Plants_Id_seq\" RESTART WITH 1");
                context.Database.ExecuteSqlRaw("ALTER SEQUENCE \"CareLogs_Id_seq\" RESTART WITH 1");

                var species = new[]
                {
                    new Species("Róża", "Europa", 20, 60),
                    new Species("Kaktus", "Pustynia", 35, 10),
                    new Species("Orchidea", "Tropiki", 25, 80),
                    new Species("Piwonia", "Europa", 30, 65),
                    new Species("Stokrotka", "Europa", 10, 75),
                    new Species("Tulipan", "Europa", 15, 65),
                    new Species("Lawenda", "Europa", 40, 40),
                    new Species("Fiołek", "Europa", 10, 70),
                    new Species("Margarita", "Europa", 12, 50)
                };
                context.Species.AddRange(species);
                context.SaveChanges();

                var plants = species
                    .SelectMany(s => Enumerable.Range(1, 3)
                        .Select(i => new Plant
                        {
                            Name = $"{s.Name} #{i}",
                            Region = s.Region,
                            SpeciesId = s.Id
                        }))
                    .ToList();
                context.Plants.AddRange(plants);
                context.SaveChanges();

                var careLogs = new List<CareLog>();
                var rand = new Random();

                foreach (var plant in plants)
                {
                    foreach (CareActionType action in Enum.GetValues(typeof(CareActionType)))
                    {
                        int entries = rand.Next(1, 4);
                        for (int i = 0; i < entries; i++)
                        {
                            careLogs.Add(new CareLog
                            {
                                PlantId = plant.Id,
                                Action = action,
                                CareDate = DateTime.UtcNow.AddDays(-rand.Next(1, 60)),
                                Comment = GetCommentForAction(action)
                            });
                        }
                    }
                }

                context.CareLogs.AddRange(careLogs);
                context.SaveChanges();

                Console.WriteLine("All data successfully seeded.");
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"SEEDING FAILED: {ex.Message}");
            }
        }

        private static string GetCommentForAction(CareActionType action)
        {
            return action switch
            {
                CareActionType.Podlewanie => "Standardowe podlewanie rośliny",
                CareActionType.Nawożenie => "Nawożenie mineralne",
                CareActionType.Przycinanie => "Przycinanie martwych gałęzi",
                CareActionType.Ochrona => "Oprysk przeciw szkodnikom",
                CareActionType.Przesadzanie => "Przesadzanie do większej donicy",
                CareActionType.Kontrola_chorób => "Rutynowa kontrola zdrowia",
                _ => "Zabieg pielęgnacyjny"
            };
        }
    }
}
