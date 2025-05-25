
using System.Drawing;
using OlhoNoBus.Core.Entities;

namespace OlhoNoBus.Core.Repositories.Interfaces;

public interface IBusLineRepository
{

    public Task<BusLine> Add(BusLine busLine);

    public Task<List<BusLine>> GetBusLinesByBusStopId(long busStopId);

    public Task<BusLine> GetById(long busStopId);

    public Task<List<BusLine>> GetAll();

    public Task<bool> Update(BusLine busLine);

    public Task<bool> Delete(long id);

}
