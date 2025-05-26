
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace OlhoNoBus.Core.Entities;

public class BusLine
{

    public long Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [JsonIgnore]
    public List<BusStop> BusStops { get; set; }





}
