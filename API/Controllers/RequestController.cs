using AutoMapper;
using Data.Repositry;
using Domain.Commands;
using Domain.Dto;
using Domain.Interface;
using Domain.Models;
using Domain.Quieres;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RequestController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly Data.Context.DBContext _context;
        private IHubContext<ChartHub> _hub;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public RequestController(IMediator mediator, IHubContext<ChartHub> hub,IMapper mapper, Data.Context.DBContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
            _mediator = mediator;
            _mapper = mapper;
            _hub = hub;
        }
        [HttpPost("postRequest")]
        public Request Post([FromBody] Request Action)
        {
            return _mediator.Send(new PostId<Request>(Action)).Result;
            _hub.Clients.All.SendAsync("transferchartdata");

        }
        [HttpGet("statitcs")]
        public statistics getstaticsuser(Guid id )
        {
         
            var data = _mediator.Send(new GetAllGenericQuery<Request>(includes:
              e => e.Include(z => z.Organisme).Include(s => s.RequestType), condition:(d=>d.Fk_User==id))
                ).Result.Select(data => _mapper.Map<RequestDto>(data));
            int waitingvalidation=0, InProgress=0, notDone=0;

            foreach (var item in data)
            {
                if(item.status == "waitingvalidation")
                {
                    waitingvalidation = waitingvalidation + 1;

                }
                if (item.status == "InProgress")
                {
                    InProgress = InProgress + 1;

                }
                if (item.status == " notDone ")
                {
                    notDone = notDone + 1;

                }
            }
            statistics statistics = new statistics()
            {
                Total = data.Count(),
                waitingvalidation = waitingvalidation,
                notDone = notDone,
                InProgress = InProgress,


                };
            return statistics;




        }

        [HttpGet("getById")]
        public RequestDto GetbyId(Guid id)
        {
            Notification notification = new Notification()
            {
                Message = " vue par un autre utlisateur ",
                RequestId = id
            };
            _context.Notifications.Add(notification);
            var data = _mediator.Send(new GetGenericQueryById<Request>(includes:
                e => e.Include(z => z.Organisme).Include(s => s.RequestType), condition: (g => g.RequestId == id))).Result;
            return _mapper.Map<RequestDto>(data);
          
        }
        [HttpGet("getallrequest")]
        public IEnumerable< RequestDto> Getrequest()
        {
            Notification notification = new Notification()
            {
                Message = "Vu par l utlisateur  ",
               
            };
            _context.Notifications.Add(notification);
            var data = _mediator.Send(new GetAllGenericQuery<Request>(includes:
                e => e.Include(z => z.Organisme).Include(s => s.RequestType))).Result.Select(data => _mapper.Map<RequestDto>(data));
            return data;
        }
        [HttpGet("getstatusInProgress")]
        public IEnumerable<RequestDto> GetInProgress()
        {
            var data = _mediator.Send(new GetAllGenericQuery<Request>(includes:
                e => e.Include(z => z.Organisme).Include(s => s.RequestType), condition: (g=>g.state==Domain.Models.Request.Status.InProgress))
                  ).Result.Select(data => _mapper.Map<RequestDto>(data));
            return data;
        }
        [HttpGet("waitingvalidation")]
        public IEnumerable<RequestDto> Getwaiting()
        {
            var data = _mediator.Send(new GetAllGenericQuery<Request>(includes:
                e => e.Include(z => z.Organisme).Include(s => s.RequestType), condition: (g => g.state == Domain.Models.Request.Status.waitingvalidation))
                  ).Result.Select(data => _mapper.Map<RequestDto>(data));
            return data;
        }
        [HttpGet("getstatusNotDone")]
        public IEnumerable<RequestDto> GetNotdone()
        {
            var data = _mediator.Send(new GetAllGenericQuery<Request>(includes:
                e => e.Include(z => z.Organisme).Include(s => s.RequestType), condition: (g => g.state == Domain.Models.Request.Status.NotDone))
                  ).Result.Select(data => _mapper.Map<RequestDto>(data));
            return data;
        }
        [HttpGet("getstatusDone")]
        public IEnumerable<RequestDto> Getdone()
        {
            var data = _mediator.Send(new GetAllGenericQuery<Request>(includes:
                e => e.Include(z => z.Organisme).Include(s => s.RequestType), condition: (g => g.state == Domain.Models.Request.Status.Done))
                  ).Result.Select(data => _mapper.Map<RequestDto>(data));
            return data;
        }
        [HttpGet("getbyuser")]
        public IEnumerable<RequestDto> Getuser(Guid userid)
        {
            var data = _mediator.Send(new GetAllGenericQuery<Request>(includes:
                e => e.Include(z => z.Organisme).Include(s => s.RequestType), condition: (g => g.Fk_User==userid))
                  ).Result.Select(data => _mapper.Map<RequestDto>(data));
            return data;
        }

        [HttpDelete("deleteRequest")]
        public string Delete(Guid id)
        {
            Notification notification = new Notification()
            {
                Message = "Demande suprimer  ",
                RequestId = id
            };
            //_mediator.Send(new PostId<Notification>(notification));
            _context.Notifications.Add(notification);
            return _mediator.Send(new DeleteGeneric<Request>(id)).Result;
            _hub.Clients.All.SendAsync("transferchartdata");
        }
        [HttpPut("updateRequest")]
        public string Put([FromBody] Request request)
        {
            Notification notification = new Notification()
            {
                Message = "Mise a jour  DE Demande ",
                RequestId = request.RequestId,
                userId=request.Fk_User
               
            };
            //_mediator.Send(new PostId<Notification>(notification));
            _context.Notifications.Add(notification);

            _hub.Clients.All.SendAsync("transferchartdata");


        var c =  _mediator.Send(new PutGeneric<Request>(request)).Result;
            _context.SaveChangesAsync();
            _hubContext.Clients.All.BroadcastMessage();
            return "Done";
        }
    }
   
}
    