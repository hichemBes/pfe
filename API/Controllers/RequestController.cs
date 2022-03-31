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
                e => e.Include(z => z.Organisme).Include(s => s.RequestType))).Result;
            return _mapper.Map<RequestDto>(data);
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
    