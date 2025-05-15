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
        [StringLength(50)]
        public string IdealTemperature { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string IdealHumidity { get; set; } = null!;

        public ICollection<Plant> Plants { get; set; } = new List<Plant>();

        public Species() { }

        public Species(string name, string region, string idealTemperature, string idealHumidity)
        {
            Name = name;
            Region = region;
            IdealTemperature = idealTemperature;
            IdealHumidity = idealHumidity;
        }
    }
}
