using System.Drawing;
using OlhoNoBus.Core.Entities;

namespace OlhoNoBus.Application.DTOs
{
    public class BusLineDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<BusStop> BusStops { get; set; }

        public BusLineDto(long id,string name,List<BusStop> busStops)
        {
            Id = id;
            Name = name;
            BusStops = busStops;
            
        }
        public static BusLineDto FromEntity(BusLine busLine)
        {
            return new BusLineDto(busLine.Id,busLine.Name, busLine.BusStops);
        }


    }
}
