using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Plants.Models
{
    public class Species
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Region { get; set; } = null!;

        [Required]
        [Range(0, 50)]
        public double IdealTemperature { get; set; }

        public double? Humidity { get; set; }

        public ICollection<Plant> Plants { get; set; } = new List<Plant>();

        public Species() { }

        public Species(string name, string region, double idealTemperature, double? humidity = null)
        {
            Name = name;
            Region = region;
            IdealTemperature = idealTemperature;
            Humidity = humidity;
        }
    }
}
