using KayPeyinAn.Api.Products.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// Register the ProductService with the dependency injection container
builder.Services.AddScoped<IProductService, ProductService>();

// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<KayPeyinAn.Api.Products.Data.AppDbContext>(options =>
 {
     options.UseSqlServer(builder.Configuration
     .GetConnectionString("DefaultConnection"));
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
// docs not in prod only dev
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
