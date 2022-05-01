using AutoMapper;
using Data.Repositry;
using Domain.Models;
using Domain.Quieres;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private IHubContext<ChartHub> _hub;
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ChartController(IHubContext<ChartHub> hub, IMediator mediator, IMapper mapper)
        {
            _hub = hub;
          
            _mediator = mediator;
            _mapper = mapper;

        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            _hub.Clients.All.SendAsync("transferchartdata",GetData());
            return Ok(new { Message = "Request Completed" });
        }
        [HttpGet("Get2")]
        public  List<ChartModel> GetData()
        {
            var data1 = _mediator.Send(new GetAllGenericQuery<Request>()).Result;
            var Total = data1.Count();
            var data2 = _mediator.Send(new GetAllGenericQuery<Request>(condition: (g => g.state == Domain.Models.Request.Status.InProgress))
                 ).Result;
            var data3 = _mediator.Send(new GetAllGenericQuery<Request>(condition: (g => g.state == Domain.Models.Request.Status.NotDone))
                 ).Result;
            var NotDone = data3.Count();
            var InProgress = data2.Count();
            var rest=Total-(data2.Count()+data3.Count());
            return new List<ChartModel>()
        {
           new ChartModel { Data = new List<int> {Total }, Label = "Totale Demande " },
           new ChartModel { Data = new List<int> { InProgress }, Label = "En Cours" },
           new ChartModel { Data = new List<int> { InProgress }, Label = "Pas encore Valideé" },
           new ChartModel { Data = new List<int> { rest }, Label = "valider par responsable Filliale" }

        };
        }

    }
}
