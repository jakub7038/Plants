using System.ComponentModel.DataAnnotations;

public class Plant
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(100)]
    public string Region { get; set; }

    [Required]
    public string Action { get; set; }

    public Plant(string name, string region, string action)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Region = region ?? throw new ArgumentNullException(nameof(region));
        Action = action ?? throw new ArgumentNullException(nameof(action));
    }
}
