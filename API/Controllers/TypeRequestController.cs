using AutoMapper;
using Domain.Commands;
using Domain.Models;
using Domain.Quieres;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TypeRequestController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TypeRequestController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpPost("posttypeRequest")]
        public async Task<typeRequest> Post(typeRequest Cat)
        {
            return await _mediator.Send(new PostId<typeRequest>(Cat));
        }
           [HttpGet("Getall")]
        public typeRequest Getall()
        {

            var Category = _mediator.Send(new GetGenericQueryById<typeRequest>()).Result;
            return _mapper.Map<typeRequest>(Category);
        }

        [HttpGet("{id}")]
        public  typeRequest Get(Guid id)
        {

            var Category = _mediator.Send(new GetGenericQueryById<typeRequest>(condition: c => c.RequestTypeId == id)).Result;
            return _mapper.Map<typeRequest>(Category);
        }
        [HttpDelete("deleteTypeRequest")]
        public string Delete(Guid id)
        {
            return _mediator.Send(new DeleteGeneric<typeRequest>(id)).Result;
        }
        [HttpPut("updatetypeRequest")]
        public string Put([FromBody] typeRequest Cat)
        {
            return _mediator.Send(new PutGeneric<typeRequest>(Cat)).Result;
        }
    }
    }

