using eCommerce.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Api.Dal;

/// <summary>
/// Canonical catalog / reference seed data applied via EF Core migrations
/// (HasData). Transactional tables (Carts, CartItems, Invoices, Customers)
/// are intentionally left unseeded.
/// </summary>
internal static class ModelBuilderSeedExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Sports Shoes", Description = "Performance footwear built for running, training and the field." },
            new Category { CategoryId = 2, CategoryName = "Casual Shoes", Description = "Everyday comfort and style for any occasion." },
            new Category { CategoryId = 3, CategoryName = "Boots", Description = "Rugged, durable boots made for the outdoors." },
            new Category { CategoryId = 4, CategoryName = "Lifestyle", Description = "Trend-forward sneakers to complete your look." }
        );

        modelBuilder.Entity<Supplier>().HasData(
            new Supplier { SupplierId = 1, Name = "Adidas India Pvt Ltd", City = "Bengaluru" },
            new Supplier { SupplierId = 2, Name = "Nike Sports Trading", City = "Mumbai" },
            new Supplier { SupplierId = 3, Name = "Bata India Ltd", City = "Kolkata" },
            new Supplier { SupplierId = 4, Name = "Campus Activewear", City = "New Delhi" },
            new Supplier { SupplierId = 5, Name = "New Balance", City = "Pune" }
        );

        modelBuilder.Entity<Shipper>().HasData(
            new Shipper { ShipperId = 1, Name = "BlueDart Express", ContactNumber = "1800-233-1234", EmailId = "support@bluedart.com" },
            new Shipper { ShipperId = 2, Name = "Delhivery", ContactNumber = "1800-209-3666", EmailId = "care@delhivery.com" },
            new Shipper { ShipperId = 3, Name = "DTDC Couriers", ContactNumber = "1860-123-4567", EmailId = "help@dtdc.com" },
            new Shipper { ShipperId = 4, Name = "Fedex", ContactNumber = "9098987665", EmailId = "sk@gmail.com" }
        );

        modelBuilder.Entity<Product>().HasData(
            Product(1, 1, 1, "Adidas Galaxy Runner", "Lightweight cushioned running shoe for men.", 5999.00m, "Men", 15, "~/Images/adidas_soc_m_1.jpeg"),
            Product(2, 1, 1, "Adidas Cloudfoam (W)", "Breathable everyday trainer for women.", 5499.00m, "Women", 10, "~/Images/adidas_soc_w_1.jpeg"),
            Product(3, 1, 1, "Adidas Pure Boost (W)", "Responsive boost cushioning for long runs.", 7999.00m, "Women", 20, "~/Images/adidas_soc_w_2.jpeg"),
            Product(4, 2, 1, "Nike Air Zoom", "Springy Zoom Air unit for explosive pace.", 8999.00m, "Men", 18, "~/Images/nike_soc_m_1.jpeg"),
            Product(5, 2, 1, "Nike Revolution (W)", "Soft foam midsole for daily training.", 6499.00m, "Women", 12, "~/Images/nike_soc_w_1.jpeg"),
            Product(6, 3, 1, "Puma Velocity", "Energy-return running shoe for men.", 5799.00m, "Men", 25, "~/Images/puma_soc_m_1.jpeg"),
            Product(7, 3, 1, "Puma Nitro Pro", "Premium nitrogen-infused racing foam.", 9499.00m, "Men", 22, "~/Images/puma_soc_m_2.png"),
            Product(8, 4, 1, "Reebok Floatride (W)", "Plush, lightweight ride for women.", 6999.00m, "Women", 14, "~/Images/reebook_soc_w1.jpeg"),
            Product(9, 5, 2, "Bata Comfort Walk", "All-day casual comfort for men.", 2499.00m, "Men", 10, "~/Images/bata_c_m_1.jpeg"),
            Product(10, 5, 2, "Bata Slip-On", "Easy slip-on casual shoe.", 1999.00m, "Men", 5, "~/Images/bata_c_m_2.jpeg"),
            Product(11, 5, 2, "Bata Breeze (W)", "Lightweight casual shoe for women.", 2299.00m, "Women", 8, "~/Images/bata_c_w_1.jpeg"),
            Product(12, 6, 2, "Campus Street", "Sporty casual look for men.", 1799.00m, "Men", 12, "~/Images/campus_c_m_1.jpeg"),
            Product(13, 6, 2, "Campus Bloom (W)", "Fashion-forward casual for women.", 1899.00m, "Women", 15, "~/Images/campus_c_w_2.jpeg"),
            Product(14, 7, 2, "Sparx Active (W)", "Comfortable casual everyday shoe.", 1599.00m, "Women", 10, "~/Images/sparx_c_w_1.jpeg"),
            Product(15, 3, 2, "Puma Casual Court", "Clean court-style casual sneaker.", 3499.00m, "Men", 18, "~/Images/puma_c_m_1.jpg"),
            Product(16, 8, 3, "Woodland Trekker", "Rugged leather boots for tough terrain.", 4999.00m, "Men", 12, "~/Images/woodland_b_m_1.jpeg"),
            Product(17, 8, 3, "Woodland Summit", "Durable hiking boots with grip sole.", 5499.00m, "Men", 16, "~/Images/woodland_b_m_2.jpg"),
            Product(18, 8, 3, "Woodland Trail (W)", "Outdoor ankle boots for women.", 4799.00m, "Women", 10, "~/Images/woodland_b_w_1.jpg"),
            Product(19, 5, 3, "Bata Ranger", "Sturdy everyday work boots.", 3299.00m, "Men", 8, "~/Images/bata_b_m_1.jpg"),
            Product(20, 6, 3, "Campus Hiker", "Lightweight hiking boots for men.", 2999.00m, "Men", 14, "~/Images/campus_b_m_1.jpg"),
            Product(21, 2, 4, "Nike Lifestyle Low", "Iconic everyday lifestyle sneaker.", 7499.00m, "Men", 20, "~/Images/nike_l_m_1.jpg"),
            Product(22, 2, 4, "Nike Retro Court", "Retro court styling for daily wear.", 6999.00m, "Men", 15, "~/Images/nike_l_m_2.jpg"),
            Product(23, 2, 4, "Nike Street (W)", "Streetwear-ready sneaker for women.", 7299.00m, "Women", 18, "~/Images/nike_l_w_1.jpg"),
            Product(24, 6, 4, "Campus Urban", "Modern lifestyle sneaker for men.", 2199.00m, "Men", 12, "~/Images/campus_l_m_2.jpg"),
            Product(25, 3, 4, "Puma Lifestyle (W)", "Stylish everyday sneaker for women.", 3999.00m, "Women", 22, "~/Images/puma_l_w_1.jpg")
        );
    }

    private static Product Product(int id, int brandId, int categoryId, string name,
        string description, decimal unitPrice, string gender, int discount, string picture) =>
        new()
        {
            ProductId = id,
            BrandId = brandId,
            CategoryId = categoryId,
            ProductName = name,
            Description = description,
            UnitPrice = unitPrice,
            MadeIn = "India",
            Gender = gender,
            WarrantyPeriod = "1-Year",
            ReturnPolicy = "15-Days",
            ProductQuantity = 1,
            Discount = discount,
            Picture = picture
        };
}
