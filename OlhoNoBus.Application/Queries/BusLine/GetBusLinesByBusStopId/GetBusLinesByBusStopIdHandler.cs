

using MediatR;
using OlhoNoBus.Application.DTOs;
using OlhoNoBus.Core.Repositories;
using OlhoNoBus.Core.Repositories.Interfaces;


namespace OlhoNoBus.Application.Queries.BusLine.GetBusLinesByBuStopId;

public class GetBusLinesByBusStopIdHandler : IRequestHandler<GetBusLinesByBusStopIdQuery, List<BusLineDto>>
{


    private readonly IBusLineRepository _repository;
    public GetBusLinesByBusStopIdHandler(IBusLineRepository repository)
    {
        _repository = repository;
    }


    public async Task<List<BusLineDto>> Handle(GetBusLinesByBusStopIdQuery request, CancellationToken cancellationToken)
    {

        var busLines = await _repository.GetBusLinesByBusStopId(request.Id);


        var busLinesViewModel = busLines.Select(BusLineDto.FromEntity).ToList();


        return busLinesViewModel;

    }
}