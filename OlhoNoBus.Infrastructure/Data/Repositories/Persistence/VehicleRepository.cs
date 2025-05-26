
using Microsoft.EntityFrameworkCore;
using OlhoNoBus.Core.Entities;
using OlhoNoBus.Core.Repositories.Interfaces;

namespace OlhoNoBus.Infrastructure.Data.Repositories.Persistence;

public class VehicleRepository : IVehicleRepository
{
    private readonly OlhoNoBusDbContext _context;

    public VehicleRepository(OlhoNoBusDbContext context)
    {
        _context = context;
    }


    public async Task<Vehicle> Add(Vehicle vehicle)
    {

        _context.Vehicle.Add(vehicle);

        await _context.SaveChangesAsync();

        return vehicle;


    }

    public async Task<bool> Update(Vehicle vehicle)
    {

        if (vehicle == null) return false;

        _context.Vehicle.Update(vehicle);

        var affectedRows = await _context.SaveChangesAsync();

        return affectedRows > 0;


    }

    public async Task<bool> Delete(long Id)
    {

        Vehicle vehicle = _context.Vehicle.FirstOrDefault(vp => vp.Id == Id);

        if (vehicle == null) return false;

        _context.Vehicle.Remove(vehicle);

        var affectedRows = await _context.SaveChangesAsync();

        return affectedRows > 0;


    }

    public async Task<Vehicle> GetById(long Id)
    {

        Vehicle vehicle = await _context.Vehicle.FirstOrDefaultAsync(vp => vp.Id == Id);

        return vehicle;


    }

    public async Task<List<Vehicle>> GetAll()
    {

        List<Vehicle> vehicle = await _context.Vehicle.ToListAsync();

        return vehicle;


    }

    public async Task<List<Vehicle>> GetVehiclesByBusLineId(long id)
    {
       List<Vehicle> vehicles = new List<Vehicle>();

       vehicles = await _context.Vehicle.Where(bl => bl.BusLine.Id == id).ToListAsync();

        return vehicles;



    }   



}
