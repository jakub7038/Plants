using System.ComponentModel.DataAnnotations;

public class Species
{
    [Key]
    public int Id { get; set; }
    public Species(string name, string region, double idealTemperature)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Region = region ?? throw new ArgumentNullException(nameof(region));
        IdealTemperature = idealTemperature;
    }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(100)]
    public string Region { get; set; }

    [Range(0, 50)]
    public double IdealTemperature { get; set; }
    public double? Humidity { get; set; }
    public ICollection<Plant>? Plants { get; set; }
}
