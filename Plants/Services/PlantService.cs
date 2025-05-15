using Plants.Models;

namespace Plants.Services
{
    public class PlantService
    {
        private readonly List<Plant> _plants = new();

        public List<Plant> GetPlants() => _plants;

        public void LoadStaticData()
        {
            var species1 = new Species("Ficus", "Tropics", 22.5, 60);
            var species2 = new Species("Cactus", "Desert", 28, 20);

            var plant1 = new Plant("Benek", species1);
            var plant2 = new Plant("Ziggy", species2);

            plant1.CareLogs.Add(new CareLog(
                action: CareActionType.Podlewanie,
                careDate: DateTime.Now.AddDays(-2),
                plantId: plant1.Id,
                healthStatus: PlantHealthStatus.Doskonała,
                comment: "Użyto filtrowanej wody",
                temperatureAtCare: 22,
                humidityAtCare: 55,
                growthMeasurementCm: 120
            ));

            plant2.CareLogs.Add(new CareLog(
                action: CareActionType.Nawożenie,
                careDate: DateTime.Now.AddDays(-10),
                plantId: plant2.Id,
                healthStatus: PlantHealthStatus.Dobra,
                comment: "Zastosowano nawóz uniwersalny",
                temperatureAtCare: 28,
                humidityAtCare: 25,
                growthMeasurementCm: 45,
                observedProblems: "Liście lekko suche"
            ));

            _plants.AddRange(new[] { plant1, plant2 });
        }

        public void AddCareLog(Plant plant, CareLog log)
        {
            plant.CareLogs.Add(log);
        }
    }
}

