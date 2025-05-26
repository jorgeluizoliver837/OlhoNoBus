using Microsoft.EntityFrameworkCore;
using OlhoNoBus.Core.Repositories.Interfaces;
using OlhoNoBus.Infrastructure.Data;
using OlhoNoBus.Infrastructure.Data.Repositories.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("OlhoNoBusCS");
builder.Services.AddDbContext<OlhoNoBusDbContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddScoped<IBusLineRepository, BusLineRepository>();
builder.Services.AddScoped<IBusStopRepository, BusStopRepository>();
builder.Services.AddScoped<IVehiclePositionRepository, VehiclePositionRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

// No seu Program.cs (ou Startup.cs, no método ConfigureServices)
builder.Services.AddMediatR(cfg =>
{

    cfg.RegisterServicesFromAssembly(typeof(OlhoNoBus.Application.Queries.BusLine.GetBusLinesAll.GetBusLinesAllQuery).Assembly);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
