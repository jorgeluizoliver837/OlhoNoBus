
using MediatR;
using OlhoNoBus.Application.DTOs;
using OlhoNoBus.Core.Entities;
using OlhoNoBus.Core.Repositories.Interfaces;
namespace OlhoNoBus.Application.Queries.BusLine.GetBusLinesAll
{
    public class GetBusLinesAllHandler:IRequestHandler<GetBusLinesAllQuery,List<BusLineDto>>
    {
        private readonly IBusLineRepository _repository;
        public GetBusLinesAllHandler(IBusLineRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BusLineDto>> Handle(GetBusLinesAllQuery request, CancellationToken cancellationToken)
        {
            var busLines = await _repository.GetAll();

            var busLinesViewModel = busLines.Select(BusLineDto.FromEntity).ToList();

            return busLinesViewModel;

        }
    }
}
