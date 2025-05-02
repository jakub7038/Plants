using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plants.Models
{
    public class CareLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlantId { get; set; }

        [Required]
        public string Action { get; set; } = null!;

        public string? Comment { get; set; }

        [Required]
        public DateTime CareDate { get; set; }

        [ForeignKey("PlantId")]
        public Plant Plant { get; set; } = null!;

        protected CareLog() { }

        public CareLog(string action, string? comment, DateTime careDate, int plantId)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
            Comment = comment;
            CareDate = careDate;
            PlantId = plantId;
        }
    }
}