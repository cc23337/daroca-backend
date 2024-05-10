using System.ComponentModel.DataAnnotations;

public class Customer
{
    [Key] //PrimaryKey
    public int ID { get; set; }

    [Required] //mesmo que "obrigatorio"
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    public double Latitude { get; set;}
    public double Longitude { get; set;}
}