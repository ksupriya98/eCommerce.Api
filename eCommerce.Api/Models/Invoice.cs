using System.ComponentModel.DataAnnotations;

namespace eCommerce.Api.Models;

public class Invoice
{
    [Key]
    public int InvoiceId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public int CartId { get; set; }

    public Cart? Cart { get; set; }
}
