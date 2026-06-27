using eCommerce.Api.Dal;
using eCommerce.Api.Models;
using eCommerce.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("ApiEComDbConStr");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<eCommerceApiDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

builder.Services.AddScoped<ICommonRepository<Category>,CommonRepository<Category>>();
builder.Services.AddScoped<ICommonRepository<Product>, CommonRepository<Product>>();


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
