
using System.ComponentModel.DataAnnotations;


namespace OlhoNoBus.Core.Entities;

public class BusLine
{

    public long Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public List<BusStop> BusStops { get; set; }





}
