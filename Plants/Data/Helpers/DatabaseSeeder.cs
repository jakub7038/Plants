using Plants.Models;
using Plants.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Plants.Data.Helpers
{
    public static class DatabaseSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Species.Any())
            {
                var speciesData = new List<Species>
                {
                    new Species("Ficus benjamina",        "Azja Południowo-Wschodnia", "[18, 24]°C", "[50, 60]%"),
                    new Species("Monstera deliciosa",      "Południowa Meksyk",         "[20, 28]°C", "[60, 80]%"),
                    new Species("Epipremnum aureum",       "Wyspy Salomona",            "[18, 24]°C", "[50, 70]%"),
                    new Species("Sansevieria trifasciata", "Zachodnia Afryka",          "[18, 27]°C", "[30, 50]%"),
                    new Species("Chlorophytum comosum",    "RPA",                       "[16, 24]°C", "[40, 60]%"),
                    new Species("Dracaena marginata",      "Madagaskar",                "[20, 26]°C", "[50, 60]%"),
                    new Species("Spathiphyllum wallisii",  "Ameryka Środkowa",          "[18, 26]°C", "[50, 70]%"),
                    new Species("Hedera helix",            "Europa",                    "[10, 21]°C", "[40, 60]%"),
                    new Species("Aloe vera",               "Półwysep Arabski",          "[20, 30]°C", "[30, 50]%"),
                    new Species("Codiaeum variegatum",     "Indonezja",                 "[18, 30]°C", "[50, 70]%"),
                    new Species("Zamioculcas zamiifolia",  "Afryka Wschodnia",          "[20, 28]°C", "[30, 50]%"),
                    new Species("Philodendron hederaceum", "Brazylia",                  "[18, 28]°C", "[50, 70]%"),
                    new Species("Yucca elephantipes",      "Ameryka Środkowa",          "[20, 35]°C", "[40, 60]%"),
                    new Species("Calathea orbifolia",      "Boliwia",                   "[18, 24]°C", "[60, 80]%"),
                    new Species("Aglaonema modestum",      "Południowe Chiny",          "[18, 26]°C", "[60, 70]%")
                };

                context.Species.AddRange(speciesData);
                context.SaveChanges();
            }

            if (!context.Plants.Any())
            {
                var speciesList = context.Species.ToList();
                var plantData = new List<(string PlantName, string SpeciesName)>
                {
                    ("Fikus Benjamina",       "Ficus benjamina"),
                    ("Fikus Golden King",     "Ficus benjamina"),
                    ("Monstera Swiss Cheese", "Monstera deliciosa"),
                    ("Monstera Adansonii",    "Monstera deliciosa"),
                    ("Pothos Golden",         "Epipremnum aureum"),
                    ("Pothos Neon",           "Epipremnum aureum"),
                    ("Sansewieria Laurenti",  "Sansevieria trifasciata"),
                    ("Sansewieria Cylindrica","Sansevieria trifasciata"),
                    ("Chlorofitum Vittatum",  "Chlorophytum comosum"),
                    ("Chlorofitum Ocean",     "Chlorophytum comosum"),
                    ("Dracena Colorama",      "Dracaena marginata"),
                    ("Dracena Tricolor",      "Dracaena marginata"),
                    ("Skrzydłokwiat Mauna Loa","Spathiphyllum wallisii"),
                    ("Skrzydłokwiat Sensation","Spathiphyllum wallisii"),
                    ("Bluszcz Pospolity",     "Hedera helix"),
                    ("Bluszcz Irish",         "Hedera helix"),
                    ("Aloes Vera",            "Aloe vera"),
                    ("Aloes Socotrina",       "Aloe vera"),
                    ("Croton Petra",          "Codiaeum variegatum"),
                    ("Croton Gold Dust",      "Codiaeum variegatum")
                };

                var allPlants = new List<Plant>();
                foreach (var (PlantName, SpeciesName) in plantData)
                {
                    var species = speciesList.First(s => s.Name == SpeciesName);
                    allPlants.Add(new Plant(PlantName, species));
                }

                context.Plants.AddRange(allPlants);
                context.SaveChanges();
            }

            if (!context.CareLogs.Any())
            {
                var plants = context.Plants.ToList();
                var now = DateTime.UtcNow;
                var logs = new List<CareLog>();
                var rand = new Random();

                var healthyComments = new[]
                {
                    "Liście wyglądają zdrowo",
                    "Wzrost stabilny",
                    "Roślina w dobrej formie",
                    "Nowe pędy rozwijają się prawidłowo",
                    "Ładny kolor liści"
                };

                var problemComments = new[]
                {
                    "Żółte plamy na liściach",
                    "Sucha ziemia, widać więdnięcie",
                    "Widoczne szkodniki",
                    "Sporadyczne brązowienie liści",
                    "Nadmierna wilgoć powoduje gnijące korzenie"
                };

                const int logsPerPlant = 10;

                string[] imageFiles = new[]
                {
                    "1.jpg",
                    "2.jpg",
                    "3.jpg",
                    "4.jpg",
                    "5.jpg",
                    "6.jpg"
                };

                static string? FindImagesFolder()
                {
                    var dir = new DirectoryInfo(AppContext.BaseDirectory);
                    while (dir != null && !dir.Name.Equals("Plants", StringComparison.OrdinalIgnoreCase))
                    {
                        dir = dir.Parent;
                    }

                    if (dir == null)
                        return null;

                    var candidate = Path.Combine(dir.FullName, "Data", "Helpers", "images");
                    return Directory.Exists(candidate) ? candidate : null;
                }

                byte[] LoadRandomCareLogImage(Random rng, string imagesFolder)
                {
                    string chosenFile = imageFiles[rng.Next(imageFiles.Length)];
                    string fullPath = Path.Combine(imagesFolder, chosenFile);

                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            byte[] bytes = File.ReadAllBytes(fullPath);
                            if (bytes.Length > 0)
                                return bytes;
                            else
                            {
                                MessageBox.Show(
                                    $"Plik istnieje, ale jest pusty (0 bajtów):\n{fullPath}",
                                    "Błąd ładowania obrazu",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return Array.Empty<byte>();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                $"Nie udało się wczytać pliku obrazu:\n{fullPath}\n\nBłąd: {ex.Message}",
                                "Błąd ładowania obrazu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            return Array.Empty<byte>();
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Plik obrazu nie został znaleziony:\n{fullPath}",
                            "Brak pliku obrazu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return Array.Empty<byte>();
                    }
                }

                string? imagesFolderPath = FindImagesFolder();
                if (imagesFolderPath == null)
                {
                    MessageBox.Show(
                        $"Nie można odnaleźć folderu „Data\\Helpers\\images” (ze schodzeniem z {AppContext.BaseDirectory}).",
                        "Błąd lokalizacji folderu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                for (int plantIndex = 0; plantIndex < plants.Count; plantIndex++)
                {
                    var plant = plants[plantIndex];

                    for (int logIndex = 0; logIndex < logsPerPlant; logIndex++)
                    {
                        int globalIndex = plantIndex * logsPerPlant + logIndex;
                        var careDate = now.AddDays(-globalIndex);

                        var allActions = Enum.GetValues<CareActionType>();
                        var action = (CareActionType)allActions.GetValue(globalIndex % allActions.Length)!;
                        var allStatuses = Enum.GetValues<PlantHealthStatus>();
                        var health = (PlantHealthStatus)allStatuses.GetValue(globalIndex % allStatuses.Length)!;

                        int temperatureAtCare = 15 + rand.Next(21);
                        int humidityAtCare = 30 + rand.Next(51);
                        double growthCm = 10 + rand.NextDouble() * 5;

                        string? comment = null;
                        string? observedProblems = null;

                        if (rand.NextDouble() < 0.15)
                        {
                            observedProblems = problemComments[rand.Next(problemComments.Length)];
                            comment = observedProblems;
                        }
                        else if (rand.NextDouble() < 0.60)
                        {
                            comment = healthyComments[rand.Next(healthyComments.Length)];
                        }

                        var careLog = new CareLog(
                            action: action,
                            careDate: careDate,
                            plantId: plant.Id,
                            healthStatus: health,
                            comment: comment,
                            temperatureAtCare: temperatureAtCare,
                            humidityAtCare: humidityAtCare,
                            growthMeasurementCm: growthCm,
                            observedProblems: observedProblems
                        );

                        careLog.Photo = LoadRandomCareLogImage(rand, imagesFolderPath);

                        logs.Add(careLog);
                    }
                }

                context.CareLogs.AddRange(logs);
                context.SaveChanges();
            }
        }
    }
}
