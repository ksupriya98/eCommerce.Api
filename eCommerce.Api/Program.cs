using eCommerce.Api.Dal;
using eCommerce.Api.Models;
using eCommerce.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Resolve the connection string from (in order): the ApiEComDbConStr environment
// variable, then configuration (user secrets in Development, appsettings, etc.).
// Credentials are intentionally NOT committed to source control.
var connectionString = Environment.GetEnvironmentVariable("ApiEComDbConStr")
    ?? builder.Configuration.GetConnectionString("ApiEComDbConStr");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "No database connection string configured. Set the 'ApiEComDbConStr' environment " +
        "variable or add it via user secrets / connection strings configuration.");
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<eCommerceApiDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

builder.Services.AddScoped<ICommonRepository<Category>, CommonRepository<Category>>();
builder.Services.AddScoped<ICommonRepository<Product>, CommonRepository<Product>>();
builder.Services.AddScoped<ICommonRepository<Customer>, CommonRepository<Customer>>();
builder.Services.AddScoped<ICommonRepository<Cart>, CommonRepository<Cart>>();
builder.Services.AddScoped<ICommonRepository<CartItem>, CommonRepository<CartItem>>();
builder.Services.AddScoped<ICommonRepository<Invoice>, CommonRepository<Invoice>>();
builder.Services.AddScoped<ICommonRepository<Shipper>, CommonRepository<Shipper>>();
builder.Services.AddScoped<ICommonRepository<Supplier>, CommonRepository<Supplier>>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config.WithOrigins("http://localhost:5173", "http://localhost:4200");
        config.AllowAnyHeader();
        config.AllowAnyMethod();
    });
});

var app = builder.Build();

// Apply any pending EF Core migrations on startup so a fresh database is
// created and seeded automatically (no manual 'dotnet ef database update').
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<eCommerceApiDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
