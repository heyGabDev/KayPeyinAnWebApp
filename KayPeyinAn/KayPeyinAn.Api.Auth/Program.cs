using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// Register the Services with the dependency injection container
// TODO : add services here

// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<KayPeyinAn.Api.Auth.Context.AuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("AuthDbConnection"));
});

// Configure ASP.NET Core Identity
builder.Services.AddIdentity<KayPeyinAn.Api.Auth.Models.User, KayPeyinAn.Api.Auth.Models.Role>(options =>
{
    // TODO : ajuster les règles de mot de passe en production
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<KayPeyinAn.Api.Auth.Context.AuthDbContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // ← doit être AVANT UseAuthorization

app.UseAuthorization();

app.MapControllers();

app.Run();
