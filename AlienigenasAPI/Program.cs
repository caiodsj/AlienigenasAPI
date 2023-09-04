global using Microsoft.EntityFrameworkCore;
global using AlienigenasAPI.Data;
global using AlienigenasAPI.Services.Interfaces;
using AlienigenasAPI.Services;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new OpenApiInfo
    {
        Title = "API Alienígenas",
        Version = "v1",
        Description = "Sistema de Controle de Alienígenas"
    });
});

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IAlienService,AlienService>();
builder.Services.AddScoped<IPlanetaService,PlanetaService>();
builder.Services.AddScoped<IPoderService,PoderService>();
builder.Services.AddScoped<ITerraService,TerraService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json","API Alienígenas v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
