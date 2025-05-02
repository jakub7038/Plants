using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [StringLength(100)]
        public string Region { get; set; } = null!;

        [Required]
        public string Action { get; set; } = null!;

        public int SpeciesId { get; set; }
        public Species Species { get; set; } = null!;

        public ICollection<CareLog> CareLogs { get; set; } = new List<CareLog>();

        protected Plant() { }

        public Plant(string name, string region, string action, int speciesId)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Region = region ?? throw new ArgumentNullException(nameof(region));
            Action = action ?? throw new ArgumentNullException(nameof(action));
            SpeciesId = speciesId;
        }
    }
}