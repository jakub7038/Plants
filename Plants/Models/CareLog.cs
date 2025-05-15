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

    public enum PlantHealthStatus
    {
        Doskonała,
        Dobra,
        Średnia,
        Zła
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

        [Required]
        public int PlantId { get; set; }

        [ForeignKey("PlantId")]
        public Plant Plant { get; set; } = null!;

        public string? Comment { get; set; }

        [Range(-50, 100)]
        public double? TemperatureAtCare { get; set; }

        [Range(0, 100)]
        public double? HumidityAtCare { get; set; }

        [MaxLength(1_048_576)] // 1 MB
        public byte[]? Photo { get; set; }


        [Range(0, 500)]
        public double? GrowthMeasurementCm { get; set; }

        [StringLength(300)]
        public string? ObservedProblems { get; set; }

        [Required]
        public PlantHealthStatus HealthStatus { get; set; }

        public CareLog() { }

        public CareLog(
            CareActionType action,
            DateTime careDate,
            int plantId,
            PlantHealthStatus healthStatus = PlantHealthStatus.Doskonała,
            string? comment = null,
            double? temperatureAtCare = null,
            double? humidityAtCare = null,
            double? growthMeasurementCm = null,
            string? observedProblems = null,
            byte[]? photo = null)
        {
            Action = action;
            CareDate = careDate;
            PlantId = plantId;
            Comment = comment;
            TemperatureAtCare = temperatureAtCare;
            HumidityAtCare = humidityAtCare;
            GrowthMeasurementCm = growthMeasurementCm;
            ObservedProblems = observedProblems;
            HealthStatus = healthStatus;

            if (photo != null && photo.Length <= 1048576)
            {
                Photo = photo;
            }
            else if (photo != null)
            {
                throw new ArgumentException("Photo size must be less than or equal to 1MB.");
            }
        }
    }
}
