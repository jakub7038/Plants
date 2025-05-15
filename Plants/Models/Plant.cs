using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Plants.Models
{
    public class Plant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public int SpeciesId { get; set; }

        [ForeignKey("SpeciesId")]
        public Species Species { get; set; } = null!;

        public ICollection<CareLog> CareLogs { get; set; } = new List<CareLog>();

        [NotMapped]
        public DateTime? LastWateringDate => GetLastActionDate(CareActionType.Podlewanie);

        [NotMapped]
        public DateTime? LastFertilizationDate => GetLastActionDate(CareActionType.Nawożenie);

        [NotMapped]
        public int? DaysSinceLastWatering => CalculateDaysSince(CareActionType.Podlewanie);

        [NotMapped]
        public int? DaysSinceLastFertilization => CalculateDaysSince(CareActionType.Nawożenie);

        [NotMapped]
        public Dictionary<CareActionType, int?> DaysSinceLastActions =>
            Enum.GetValues(typeof(CareActionType))
                .Cast<CareActionType>()
                .ToDictionary(
                    action => action,
                    action => CalculateDaysSince(action)
                );

        public Plant() { }

        public Plant(string name, string region, Species species)
        {
            Name = name;
            Species = species;
            SpeciesId = species.Id;
        }

        private DateTime? GetLastActionDate(CareActionType actionType)
        {
            return CareLogs?
                .Where(log => log.Action == actionType)
                .Max(log => (DateTime?)log.CareDate);
        }

        private int? CalculateDaysSince(CareActionType actionType)
        {
            var lastDate = GetLastActionDate(actionType);
            return lastDate.HasValue
                ? (DateTime.Now - lastDate.Value).Days
                : null;
        }
    }
}
