// creates a web application using the WebApplication class 
using Core.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();

using var scope = app.Services.CreateScope(); // create a scope for the lifetime of the application

var services = scope.ServiceProvider; // get the service provider from the scope
var context = services.GetRequiredService<StoreContext>(); // get the store context from the service provider
var logger = services.GetRequiredService<ILogger<Program>>(); // get the store context from the service provide

try
{
  await context.Database.MigrateAsync(); // migrate the database
  await StoreContextSeed.SeedAsync(context); // seed the database
}
catch (Exception ex)
{
  logger.LogError(ex, "An error occured during migration");
}
app.Run();
