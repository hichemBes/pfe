using AutoMapper;
using Domain.Commands;
using Domain.Dto;

using Domain.Models;
using Domain.Quieres;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public RequestController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("postRequest")]
        public Request Post([FromBody] Request Action)
        {
            return _mediator.Send(new PostId<Request>(Action)).Result;
        }


        [HttpGet("getById")]
        public RequestDto GetbyId(Guid id)
        {
            var data = _mediator.Send(new GetGenericQueryById<Request>(includes:
                e => e.Include(z => z.Organisme).Include(s => s.RequestType), condition: (g => g.RequestId == id))).Result;
            return _mapper.Map<RequestDto>(data);
        }
        [HttpGet("getallrequest")]
        public IEnumerable< RequestDto> Getrequest()
        {
            var data = _mediator.Send(new GetAllGenericQuery<Request>(includes:
                e => e.Include(z => z.Organisme).Include(s => s.RequestType))).Result.Select(data => _mapper.Map<RequestDto>(data));
            return data;
        }
        [HttpGet("getstatusInProgress")]
        public IEnumerable<RequestDto> Getwaitingvalidation()
        {
            var data = _mediator.Send(new GetAllGenericQuery<Request>(includes:
                e => e.Include(z => z.Organisme).Include(s => s.RequestType), condition: (g=>g.state==Domain.Models.Request.Status.InProgress))
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
            return _mediator.Send(new DeleteGeneric<Request>(id)).Result;
        }
        [HttpPut("updateRequest")]
        public string Put([FromBody] Request Role)
        {
            return _mediator.Send(new PutGeneric<Request>(Role)).Result;
        }
    }
   
}
    