using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlhoNoBus.Core.Entities;

namespace OlhoNoBus.Core.Repositories.Interfaces;

public interface IVehiclePositionRepository
{

    public Task<VehiclePosition> Add(VehiclePosition vehiclePosition);

    public Task<bool> Update(VehiclePosition vehiclePosition);   

    public Task<bool> Delete(long id);

    public Task<VehiclePosition> GetById(long id);

    public Task<List<VehiclePosition>> GetAll();


}
