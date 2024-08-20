using EcoTech.Configurations;
using EcoTech.Contexts;
using Infrastructure.Contexts;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddDependencyInjection();
builder.Services.useMongoDbConventions();

builder.Services.Configure<MongoDBSettings>(configuration.GetSection("DataBase"));
builder.Services.AddSingleton<EcoTechAppMongoDbContext>();


var app = builder.Build();

IServiceScope scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

EcoTechAppMongoDbContext mongoDbContext = scope.ServiceProvider.GetRequiredService<EcoTechAppMongoDbContext>();
mongoDbContext.Execute();


app.UseCors(configurePolicy: c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseRouting()
    .UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
