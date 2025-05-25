

namespace OlhoNoBus.Core.Entities;

public class VehiclePosition
{

    public long Id { get; set; }
    public  double Latitude { get; set; }

    public double Longitude { get; set; }   

    public Vehicle Vehicle { get; set; }


}
