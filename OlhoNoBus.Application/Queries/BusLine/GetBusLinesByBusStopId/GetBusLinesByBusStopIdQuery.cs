

using MediatR;
using OlhoNoBus.Application.DTOs;

namespace OlhoNoBus.Application.Queries.BusLine.GetBusLinesByBuStopId;

public class GetBusLinesByBusStopIdQuery : IRequest<List<BusLineDto>>
{

    public GetBusLinesByBusStopIdQuery(long IdBusStop)
    {
        Id = IdBusStop;
    }

    public long Id { get; set; }

}
