
using System.ComponentModel.DataAnnotations;


namespace OlhoNoBus.Core.Entities;

public class BusStop
{

    public long Id { get; set; }

    [Required]
    public string Name { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public List<BusLine> BusLines { get; set; }

}
