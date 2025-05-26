
using Microsoft.EntityFrameworkCore;
using OlhoNoBus.Core.Entities;
using OlhoNoBus.Core.Repositories.Interfaces;

namespace OlhoNoBus.Infrastructure.Data.Repositories.Persistence;

public class VehiclePositionRepository:IVehiclePositionRepository
{

    private readonly OlhoNoBusDbContext _context;

    public VehiclePositionRepository(OlhoNoBusDbContext Context)
    {
        _context = Context;
    }

    public async Task<VehiclePosition> Add(VehiclePosition vehiclePosition)
    {

        _context.VehiclePosition.Add(vehiclePosition);

        await _context.SaveChangesAsync();

        return vehiclePosition;


    }

    public async  Task<bool> Update(VehiclePosition vehiclePosition)
    {
        
        if(vehiclePosition == null) return false;   

        _context.VehiclePosition.Update(vehiclePosition);

        var affectedRows = await _context.SaveChangesAsync();

        return affectedRows > 0;


    }

    public async Task<bool> Delete(long Id)
    {

        VehiclePosition vehiclePosition = _context.VehiclePosition.FirstOrDefault(vp => vp.Id == Id);   

        if (vehiclePosition == null) return false;

        _context.VehiclePosition.Remove(vehiclePosition);

        var affectedRows = await _context.SaveChangesAsync();

        return affectedRows > 0;


    }

    public async Task<VehiclePosition> GetById(long Id)
    {

        VehiclePosition vehiclePosition = await _context.VehiclePosition.FirstOrDefaultAsync(vp => vp.Id == Id);
                
        return vehiclePosition;


    }

    public async Task<List<VehiclePosition>> GetAll()
    {

        List<VehiclePosition> vehiclePositions = await _context.VehiclePosition.ToListAsync();

        return vehiclePositions;


    }



}
