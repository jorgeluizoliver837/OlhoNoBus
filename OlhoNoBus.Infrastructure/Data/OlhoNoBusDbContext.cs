

using System;
using Microsoft.EntityFrameworkCore;
using OlhoNoBus.Core.Entities;


namespace OlhoNoBus.Infrastructure.Data;

public class OlhoNoBusDbContext: DbContext
{

    public OlhoNoBusDbContext(DbContextOptions<OlhoNoBusDbContext> options) : base(options)
    {
        
    }

    public DbSet<BusLine> BusLine { get; set; }

    public DbSet<BusStop> BusStop { get; set; }

    public DbSet<Vehicle> Vehicle { get; set; }

    public DbSet<VehiclePosition> VehiclePosition   { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        base.OnModelCreating(modelBuilder);
    }

}
