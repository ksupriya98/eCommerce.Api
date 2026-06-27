using System.ComponentModel.DataAnnotations;

namespace eCommerce.Api.Models;

public class Supplier
{
    [Key]
    public int SupplierId { get; set; }
    [Required(ErrorMessage = "Name is a required field!")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "City is a required field!")]
    public string City { get; set; } = string.Empty;
}
