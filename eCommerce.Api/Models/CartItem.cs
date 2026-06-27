using System.ComponentModel.DataAnnotations;

namespace eCommerce.Api.Models;

public class CartItem
{
    [Key]
    public int CartItemId { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }

    public Cart? Cart { get; set; }
    public Product? Product { get; set; }
}
