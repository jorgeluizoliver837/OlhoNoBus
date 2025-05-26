
using Microsoft.AspNetCore.Mvc;
using OlhoNoBus.Application.Queries;
using MediatR;
using OlhoNoBus.Application.Queries.BusLine.GetBusLinesAll;

namespace OlhoNoBus.API.Controllers;

    [ApiController] 
    [Route("api/[controller]")] 
    public class BusLineController : ControllerBase
    {

        private readonly IMediator _mediator;
        public BusLineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetBusLinesAllQuery());

            return Ok(result);
        }

       
    }

