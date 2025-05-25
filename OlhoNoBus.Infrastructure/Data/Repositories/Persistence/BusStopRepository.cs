using OlhoNoBus.Core.Repositories;
using OlhoNoBus.Core.Entities;
using OlhoNoBus.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace OlhoNoBus.Infrastructure.Data.Repositories.Persistence;

public class BusStopRepository:IBusStopRepository
{


    private readonly OlhoNoBusDbContext _context;
    public BusStopRepository(OlhoNoBusDbContext Context)
    {
        _context = Context; 

    }

    public async Task<BusStop> Add(BusStop busStop)
    { 
        
       _context.BusStop.Add(busStop);

       await _context.SaveChangesAsync();

       return busStop;
    
    }

    public async Task<bool> Delete(long BusStopId)
    { 

        var busStop = _context.BusStop.FirstOrDefault(b  => b.Id == BusStopId);

        if (busStop is null)
        {
            return false;
        }

        _context.BusStop.Remove(busStop);

        var affectedRows = await _context.SaveChangesAsync();

        return affectedRows > 0;
                   
        
    }

    public async Task<bool> Update(BusStop busStop)
    {
          
        _context.BusStop.Update(busStop);
       
        var affectedRows = await _context.SaveChangesAsync();

        return affectedRows > 0;


    }

    public async Task<BusStop> GetById(long busStopId)
    {
        var busStop = await _context.BusStop.FirstOrDefaultAsync(b => b.Id.Equals(busStopId));

        return busStop;

    }

    public async Task<List<BusStop>> GetAll()
    {
        var busStops = await _context.BusStop.ToListAsync();

        return busStops;

    }




}
