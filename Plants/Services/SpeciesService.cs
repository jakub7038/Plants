using System.Collections.Generic;
using System.Linq;
using Plants.Data.Helpers;
using Plants.Models;

namespace Plants.Services
{
    public class SpeciesService
    {
        public List<Species> GetAllSpecies()
        {
            using var context = DbContextHelper.Create();
            return context.Species.ToList();
        }

        public void AddSpecies(Species species)
        {
            using var context = DbContextHelper.Create();
            context.Species.Add(species);
            context.SaveChanges();
        }

        public bool DoesSpeciesExist(string name)
        {
            using var context = DbContextHelper.Create();
            return context.Species.Any(s => s.Name.ToLower() == name.ToLower());
        }
    }
}
