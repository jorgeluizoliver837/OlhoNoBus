

using OlhoNoBus.Core.Entities;

namespace OlhoNoBus.Core.Repositories.Interfaces;

public interface IVehicleRepository
{

    public Task<Vehicle> Add(Vehicle vehicle);

    public Task<bool> Update(Vehicle vehicle);

    public Task<bool> Delete(long id);

    public Task<Vehicle> GetById(long id);

    public Task<List<Vehicle>> GetAll();

    public Task<List<Vehicle>> GetVehiclesByBusLineId(long id);


}
