

using OlhoNoBus.Core.Entities;

namespace OlhoNoBus.Core.Repositories.Interfaces;

public interface IBusStopRepository
{

    public Task<BusStop> Add(BusStop busStop);  

    public Task<bool>  Delete(long id);

    public Task<bool> Update(BusStop busStop);

    public Task<BusStop> GetById(long id);

    public Task<List<BusStop>> GetAll();

}
