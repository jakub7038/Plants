using Plants.Models;
using Plants.Data;

namespace Plants.Data.Helpers
{
    public static class DatabaseSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Species.Any())
            {
                var ficus = new Species("Ficus", "Azja", "22-28°C", "50-70%");
                var cactus = new Species("Kaktus", "Ameryka Południowa", "25-35°C", "10-30%");

                context.Species.AddRange(ficus, cactus);
                context.SaveChanges();

                var plant1 = new Plant("Fikus Benjamina", ficus);
                var plant2 = new Plant("Opuncja", cactus);

                context.Plants.AddRange(plant1, plant2);
                context.SaveChanges();
            }

            if (!context.CareLogs.Any())
            {
                var plants = context.Plants.ToList();
                var now = DateTime.UtcNow;

                var logs = new List<CareLog>();

                foreach (var plant in plants)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        logs.Add(new CareLog(
                            action: (CareActionType)(i % Enum.GetValues<CareActionType>().Length),
                            careDate: now.AddDays(-i * 3),
                            plantId: plant.Id,
                            healthStatus: (PlantHealthStatus)(i % Enum.GetValues<PlantHealthStatus>().Length),
                            comment: $"Automatyczny wpis {i} dla {plant.Name}",
                            temperatureAtCare: 20 + i,
                            humidityAtCare: 40 + i,
                            growthMeasurementCm: 100 + i * 5
                        ));
                    }
                }

                context.CareLogs.AddRange(logs);
                context.SaveChanges();
            }
        }
    }
}
