

using MediatR;
using OlhoNoBus.Application.DTOs;
using OlhoNoBus.Core.Repositories;

namespace OlhoNoBus.Application.Queries.BusLine.GetBusLinesAll;

public class GetBusLinesAllQuery:IRequest<List<BusLineDto>>
{
}
