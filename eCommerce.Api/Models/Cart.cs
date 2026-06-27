using System.ComponentModel.DataAnnotations;

namespace eCommerce.Api.Models;

public class Cart
{
    [Key]
    public int CartId { get; set; }
    public DateTime CartDate { get; set; }
    public int? CustomerId { get; set; }

    public Customer? Customer { get; set; }
    public ICollection<CartItem>? CartItems { get; set; }
    public Invoice? Invoice { get; set; }
}
