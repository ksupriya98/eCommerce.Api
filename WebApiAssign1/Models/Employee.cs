using System.ComponentModel.DataAnnotations;

public class Employee
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string City { get; set; }

    [Required]
    [StringLength(50)]
    public string State { get; set; }

    [Required]
    [StringLength(50)]
    public string Country { get; set; }

    [Required]
    [EmailAddress]
    public string EmailId { get; set; }

    [Required]
    [Phone]
    public string PhoneNo { get; set; }
}