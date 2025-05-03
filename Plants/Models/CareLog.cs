using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plants.Models
{
    public enum CareActionType
    {
        Podlewanie,
        Nawożenie,
        Przycinanie,
        Ochrona,
        Przesadzanie,
        Kontrola_chorób
    }

    public class CareLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public CareActionType Action { get; set; }

        [NotMapped]
        public string ActionDisplay => Action.ToString().Replace('_', ' ');

        [Required]
        public DateTime CareDate { get; set; }

        public string? Comment { get; set; }

        [Required]
        public int PlantId { get; set; }

        [ForeignKey("PlantId")]
        public Plant Plant { get; set; } = null!;

        public CareLog() { }

        public CareLog(CareActionType action, DateTime careDate, int plantId, string? comment = null)
        {
            Action = action;
            CareDate = careDate;
            PlantId = plantId;
            Comment = comment;
        }
    }
}
