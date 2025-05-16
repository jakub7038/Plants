using System.Collections.Generic;
using System.Linq;
using Plants.Data.Helpers;
using Plants.Models;

namespace Plants.Services
{
    public class PlantService
    {
        public List<Plant> GetPlants()
        {
            using var context = DbContextHelper.Create();
            return context.Plants
                .Select(p => new Plant
                {
                    Id = p.Id,
                    Name = p.Name,
                    Species = p.Species,
                    SpeciesId = p.SpeciesId
                })
                .ToList();
        }

        public Plant? GetPlantWithCareLogs(int plantId)
        {
            using var context = DbContextHelper.Create();
            return context.Plants
                .Where(p => p.Id == plantId)
                .Select(p => new Plant
                {
                    Id = p.Id,
                    Name = p.Name,
                    Species = p.Species,
                    SpeciesId = p.SpeciesId,
                    CareLogs = p.CareLogs
                        .OrderByDescending(log => log.CareDate)
                        .ToList()
                })
                .FirstOrDefault();
        }

        public void AddCareLog(Plant plant, CareLog careLog)
        {
            using var context = DbContextHelper.Create();
            careLog.PlantId = plant.Id;
            context.CareLogs.Add(careLog);
            context.SaveChanges();
        }

        public void AddPlant(Plant plant)
        {
            using var context = DbContextHelper.Create();

            var species = context.Species.Find(plant.SpeciesId);
            if (species == null) throw new InvalidOperationException("Nie znaleziono takiego gatunku.");

            plant.Species = species;
            context.Plants.Add(plant);
            context.SaveChanges();
        }

        public bool DoesPlantExist(string name)
        {
            using var context = DbContextHelper.Create();
            return context.Plants.Any(p => p.Name.ToLower() == name.ToLower());
        }
    }
}
