using AspNetCore.Identity.MongoDbCore.Infrastructure;
using EcoTech.Contexts;
using EcoTech.Models;
using Infrastructure.Encrypt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.Configure<MongoDbSettings>(
    configuration.GetSection("MongoDbSettings"));

builder.Services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JwtSettings>>().Value);

builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddSingleton<EcoTechAppMongoDbContext>();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>(
        configuration["MongoDbSettings:ConnectionString"],
        configuration["MongoDbSettings:DatabaseName"])
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseCors(configurePolicy: c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseRouting()
    .UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();