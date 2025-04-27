using System.ComponentModel.DataAnnotations;

public class CareLog
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlantId { get; set; }
    public CareLog(string action, string comment, DateTime careDate, int plantId)
    {
        Action = action ?? throw new ArgumentNullException(nameof(action));
        Comment = comment ?? throw new ArgumentNullException(nameof(comment));
        CareDate = careDate;
        PlantId = plantId;
    }

    public string Action { get; set; }
    public string Comment { get; set; }
    public DateTime CareDate { get; set; }

    public Plant? Plant { get; set; }
}
