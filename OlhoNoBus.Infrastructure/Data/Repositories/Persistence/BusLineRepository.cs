using OlhoNoBus.Core.Repositories;
using OlhoNoBus.Core.Entities;
using OlhoNoBus.Core.Repositories.Interfaces;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
namespace OlhoNoBus.Infrastructure.Data.Repositories.Persistence;

public class BusLineRepository : IBusLineRepository
{

    private readonly OlhoNoBusDbContext _context;
    public BusLineRepository(OlhoNoBusDbContext Context)
    {
        _context = Context;
    }
    public async Task<BusLine> Add(BusLine busline)
    {
        await _context.AddAsync(busline);
        await _context.SaveChangesAsync();

        return busline;

    }

    public async Task<List<BusLine>> GetBusLinesByBusStopId(long busStopId)
    {

        List<BusLine> busLines = new List<BusLine>();

        busLines = await _context.BusLine.Where(bs => bs.BusStops.Any(b => b.Id == busStopId)).ToListAsync();

        return busLines;

    }


    public async Task<BusLine> GetById(long busLineID)
    {

        BusLine busLine = new BusLine();

        busLine = await _context.BusLine.FirstOrDefaultAsync(bl => bl.Id == busLineID);

        return busLine;

    }

    public async Task<List<BusLine>> GetAll()
    {

        List<BusLine> busLines = new List<BusLine>();

        busLines = await _context.BusLine.ToListAsync();

        return busLines;

    }


    public async Task<bool> Update(BusLine busLine)
    {
        _context.BusLine.Update(busLine);

       var affectedRows = await _context.SaveChangesAsync();

        return affectedRows > 0;


    }


    public async Task<bool> Delete(long busLineId)
    {
        
        var busLine = _context.BusLine.FirstOrDefault(bl => bl.Id == busLineId);

        if (busLine is null)
        {
            return false;
        }

        _context.BusLine.Remove(busLine);
       
        var affectedRows = await _context.SaveChangesAsync();

        return affectedRows > 0;

    }



}
