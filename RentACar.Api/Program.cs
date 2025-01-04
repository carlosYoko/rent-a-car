using RentACar.Application;
using RentACar.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();