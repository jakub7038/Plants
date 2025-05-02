using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        protected Species() { }

        public Species(string name, string region, double idealTemperature)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Region = region ?? throw new ArgumentNullException(nameof(region));
            IdealTemperature = idealTemperature;
        }
    }
}