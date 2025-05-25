
using System.ComponentModel.DataAnnotations;


namespace OlhoNoBus.Core.Entities;

public class Vehicle
{

    public long Id { get; set; }

    [Required(ErrorMessage ="Provide the vehicle name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Provide the vehicle Model")]
    public string Model { get; set; }
           
    public BusLine BusLine { get; set; }





}
