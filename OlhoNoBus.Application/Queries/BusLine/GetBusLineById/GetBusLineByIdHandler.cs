

using MediatR;
using OlhoNoBus.Application.DTOs;
using OlhoNoBus.Core.Repositories;
using OlhoNoBus.Core.Repositories.Interfaces;

namespace OlhoNoBus.Application.Queries.BusLine.GetBusLineById;

public class GetBusLineByIdHandler:IRequestHandler<GetBusLineByIdQuery,BusLineDto>
{

    private readonly IBusLineRepository _repository;
    public GetBusLineByIdHandler(IBusLineRepository repository)
    {
        _repository = repository;
        
    }

    public async Task<BusLineDto> Handle(GetBusLineByIdQuery request, CancellationToken cancellationToken)
    {
        var busLine = await _repository.GetById(request.Id);

        var busLineViewModel =  BusLineDto.FromEntity(busLine);

        return busLineViewModel;

    }
}
