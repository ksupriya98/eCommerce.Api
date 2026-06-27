using System.ComponentModel.DataAnnotations;

namespace eCommerce.Api.Models;

public class Shipper
{
    [Key]
    public int ShipperId { get; set; }
    [Required(ErrorMessage = "Name is a required field!")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Contact Number is a required field!")]
    public string ContactNumber { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email Id is a required field!")]
    [EmailAddress]
    public string EmailId { get; set; } = string.Empty;
}
