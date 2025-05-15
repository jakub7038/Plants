using Plants.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plants.Data
{
    public static class DatabaseSeeder
    {
        private static readonly Random _rand = new();

        public static void Seed(AppDbContext context)
        {
            if (context.Species.Any() || context.Plants.Any())
            {
                Console.WriteLine("Dane już istnieją, seedowanie pominięte.");
                return;
            }

            Console.WriteLine("Rozpoczynam seedowanie danych...");

            var speciesList = CreateSpecies();
            context.Species.AddRange(speciesList);
            context.SaveChanges();

            var plantList = CreatePlants(speciesList);
            context.Plants.AddRange(plantList);
            context.SaveChanges();

            CreateCareLogs(context, plantList);

            Console.WriteLine("Seedowanie zakończone pomyślnie!");
        }

        private static List<Species> CreateSpecies()
        {
            return new List<Species>
            {
                new Species("Fikus", "Tropikalne lasy", 22, 60),
                new Species("Kaktus", "Pustynia", 30, 20),
                new Species("Aloes", "Sawanna", 25, 40),
                new Species("Paproć", "Lasy wilgotne", 20, 80),
                new Species("Storczyk", "Tropikalne lasy", 24, 70)
            };
        }

        private static List<Plant> CreatePlants(List<Species> speciesList)
        {
            var names = new[] { "Benek", "Zuzia", "Spike", "Ala", "Mela", "Dżungla", "Kaktusik" };

            var plants = new List<Plant>();

            foreach (var name in names)
            {
                var species = speciesList[_rand.Next(speciesList.Count)];
                plants.Add(new Plant(name, species));
            }

            return plants;
        }

        private static void CreateCareLogs(AppDbContext context, List<Plant> plants)
        {
            var problemsList = new[]
            {
                "Liście żółknące",
                "Ziemia przesuszona",
                "Plamy na liściach",
                "Opadające liście",
                "Brak nowych przyrostów"
            };

            foreach (var plant in plants)
            {
                int numberOfLogs = _rand.Next(2, 6); // Każda roślina ma 2-5 wpisów opieki

                for (int i = 0; i < numberOfLogs; i++)
                {
                    var action = RandomAction();
                    var careDate = DateTime.Now.AddDays(-_rand.Next(5, 90));
                    var healthStatus = RandomHealthStatus();

                    var log = new CareLog(
                        action: action,
                        careDate: careDate,
                        plantId: plant.Id,
                        healthStatus: healthStatus,
                        comment: _rand.Next(0, 3) == 0 ? "Brak uwag." : "Automatyczny wpis.",
                        temperatureAtCare: _rand.Next(18, 30),
                        humidityAtCare: _rand.Next(30, 80),
                        growthMeasurementCm: _rand.Next(10, 150),
                        observedProblems: _rand.Next(0, 4) == 0 ? problemsList[_rand.Next(problemsList.Length)] : null
                    );

                    context.CareLogs.Add(log);
                }
            }

            context.SaveChanges();
        }

        private static CareActionType RandomAction()
        {
            int roll = _rand.Next(100);

            if (roll < 50) return CareActionType.Podlewanie;   // 50% szansy na podlewanie
            if (roll < 70) return CareActionType.Nawożenie;    // 20% nawożenie
            if (roll < 85) return CareActionType.Przycinanie;  // 15% przycinanie
            if (roll < 95) return CareActionType.Ochrona;      // 10% ochrona
            return CareActionType.Przesadzanie;                // 5% przesadzanie
        }

        private static PlantHealthStatus RandomHealthStatus()
        {
            int roll = _rand.Next(100);

            if (roll < 60) return PlantHealthStatus.Doskonała;
            if (roll < 85) return PlantHealthStatus.Dobra;
            if (roll < 95) return PlantHealthStatus.Średnia;
            return PlantHealthStatus.Zła;
        }
    }
}
