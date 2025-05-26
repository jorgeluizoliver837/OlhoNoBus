using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OlhoNoBus.Application.DTOs;

namespace OlhoNoBus.Application.Queries.BusLine.GetBusLineById
{
    public class GetBusLineByIdQuery:IRequest<BusLineDto>
    {

        public long Id { get; set; }

        public GetBusLineByIdQuery(long id)
        {
            Id = id;
        }


    }
}
