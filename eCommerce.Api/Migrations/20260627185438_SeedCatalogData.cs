using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerce.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedCatalogData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ContactName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    ShipperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    ContactNumber = table.Column<string>(type: "longtext", nullable: false),
                    EmailId = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.ShipperId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    InvoiceDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Sports Shoes", "Performance footwear built for running, training and the field." },
                    { 2, "Casual Shoes", "Everyday comfort and style for any occasion." },
                    { 3, "Boots", "Rugged, durable boots made for the outdoors." },
                    { 4, "Lifestyle", "Trend-forward sneakers to complete your look." }
                });

            migrationBuilder.InsertData(
                table: "Shippers",
                columns: new[] { "ShipperId", "ContactNumber", "EmailId", "Name" },
                values: new object[,]
                {
                    { 1, "1800-233-1234", "support@bluedart.com", "BlueDart Express" },
                    { 2, "1800-209-3666", "care@delhivery.com", "Delhivery" },
                    { 3, "1860-123-4567", "help@dtdc.com", "DTDC Couriers" },
                    { 4, "9098987665", "sk@gmail.com", "Fedex" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "City", "Name" },
                values: new object[,]
                {
                    { 1, "Bengaluru", "Adidas India Pvt Ltd" },
                    { 2, "Mumbai", "Nike Sports Trading" },
                    { 3, "Kolkata", "Bata India Ltd" },
                    { 4, "New Delhi", "Campus Activewear" },
                    { 5, "Pune", "New Balance" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "CategoryId", "Description", "Discount", "Gender", "MadeIn", "Picture", "ProductName", "ProductQuantity", "ReturnPolicy", "UnitPrice", "WarrantyPeriod" },
                values: new object[,]
                {
                    { 1, 1, 1, "Lightweight cushioned running shoe for men.", 15, "Men", "India", "~/Images/adidas_soc_m_1.jpeg", "Adidas Galaxy Runner", 1, "15-Days", 5999.00m, "1-Year" },
                    { 2, 1, 1, "Breathable everyday trainer for women.", 10, "Women", "India", "~/Images/adidas_soc_w_1.jpeg", "Adidas Cloudfoam (W)", 1, "15-Days", 5499.00m, "1-Year" },
                    { 3, 1, 1, "Responsive boost cushioning for long runs.", 20, "Women", "India", "~/Images/adidas_soc_w_2.jpeg", "Adidas Pure Boost (W)", 1, "15-Days", 7999.00m, "1-Year" },
                    { 4, 2, 1, "Springy Zoom Air unit for explosive pace.", 18, "Men", "India", "~/Images/nike_soc_m_1.jpeg", "Nike Air Zoom", 1, "15-Days", 8999.00m, "1-Year" },
                    { 5, 2, 1, "Soft foam midsole for daily training.", 12, "Women", "India", "~/Images/nike_soc_w_1.jpeg", "Nike Revolution (W)", 1, "15-Days", 6499.00m, "1-Year" },
                    { 6, 3, 1, "Energy-return running shoe for men.", 25, "Men", "India", "~/Images/puma_soc_m_1.jpeg", "Puma Velocity", 1, "15-Days", 5799.00m, "1-Year" },
                    { 7, 3, 1, "Premium nitrogen-infused racing foam.", 22, "Men", "India", "~/Images/puma_soc_m_2.png", "Puma Nitro Pro", 1, "15-Days", 9499.00m, "1-Year" },
                    { 8, 4, 1, "Plush, lightweight ride for women.", 14, "Women", "India", "~/Images/reebook_soc_w1.jpeg", "Reebok Floatride (W)", 1, "15-Days", 6999.00m, "1-Year" },
                    { 9, 5, 2, "All-day casual comfort for men.", 10, "Men", "India", "~/Images/bata_c_m_1.jpeg", "Bata Comfort Walk", 1, "15-Days", 2499.00m, "1-Year" },
                    { 10, 5, 2, "Easy slip-on casual shoe.", 5, "Men", "India", "~/Images/bata_c_m_2.jpeg", "Bata Slip-On", 1, "15-Days", 1999.00m, "1-Year" },
                    { 11, 5, 2, "Lightweight casual shoe for women.", 8, "Women", "India", "~/Images/bata_c_w_1.jpeg", "Bata Breeze (W)", 1, "15-Days", 2299.00m, "1-Year" },
                    { 12, 6, 2, "Sporty casual look for men.", 12, "Men", "India", "~/Images/campus_c_m_1.jpeg", "Campus Street", 1, "15-Days", 1799.00m, "1-Year" },
                    { 13, 6, 2, "Fashion-forward casual for women.", 15, "Women", "India", "~/Images/campus_c_w_2.jpeg", "Campus Bloom (W)", 1, "15-Days", 1899.00m, "1-Year" },
                    { 14, 7, 2, "Comfortable casual everyday shoe.", 10, "Women", "India", "~/Images/sparx_c_w_1.jpeg", "Sparx Active (W)", 1, "15-Days", 1599.00m, "1-Year" },
                    { 15, 3, 2, "Clean court-style casual sneaker.", 18, "Men", "India", "~/Images/puma_c_m_1.jpg", "Puma Casual Court", 1, "15-Days", 3499.00m, "1-Year" },
                    { 16, 8, 3, "Rugged leather boots for tough terrain.", 12, "Men", "India", "~/Images/woodland_b_m_1.jpeg", "Woodland Trekker", 1, "15-Days", 4999.00m, "1-Year" },
                    { 17, 8, 3, "Durable hiking boots with grip sole.", 16, "Men", "India", "~/Images/woodland_b_m_2.jpg", "Woodland Summit", 1, "15-Days", 5499.00m, "1-Year" },
                    { 18, 8, 3, "Outdoor ankle boots for women.", 10, "Women", "India", "~/Images/woodland_b_w_1.jpg", "Woodland Trail (W)", 1, "15-Days", 4799.00m, "1-Year" },
                    { 19, 5, 3, "Sturdy everyday work boots.", 8, "Men", "India", "~/Images/bata_b_m_1.jpg", "Bata Ranger", 1, "15-Days", 3299.00m, "1-Year" },
                    { 20, 6, 3, "Lightweight hiking boots for men.", 14, "Men", "India", "~/Images/campus_b_m_1.jpg", "Campus Hiker", 1, "15-Days", 2999.00m, "1-Year" },
                    { 21, 2, 4, "Iconic everyday lifestyle sneaker.", 20, "Men", "India", "~/Images/nike_l_m_1.jpg", "Nike Lifestyle Low", 1, "15-Days", 7499.00m, "1-Year" },
                    { 22, 2, 4, "Retro court styling for daily wear.", 15, "Men", "India", "~/Images/nike_l_m_2.jpg", "Nike Retro Court", 1, "15-Days", 6999.00m, "1-Year" },
                    { 23, 2, 4, "Streetwear-ready sneaker for women.", 18, "Women", "India", "~/Images/nike_l_w_1.jpg", "Nike Street (W)", 1, "15-Days", 7299.00m, "1-Year" },
                    { 24, 6, 4, "Modern lifestyle sneaker for men.", 12, "Men", "India", "~/Images/campus_l_m_2.jpg", "Campus Urban", 1, "15-Days", 2199.00m, "1-Year" },
                    { 25, 3, 4, "Stylish everyday sneaker for women.", 22, "Women", "India", "~/Images/puma_l_w_1.jpg", "Puma Lifestyle (W)", 1, "15-Days", 3999.00m, "1-Year" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CartId",
                table: "Invoices",
                column: "CartId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);
        }
    }
}
