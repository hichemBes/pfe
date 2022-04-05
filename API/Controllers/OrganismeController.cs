using AutoMapper;
using Domain.Commands;
using Domain.Models;
using Domain.Quieres;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{

    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class OrganismeController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public OrganismeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpGet("GetAll")]
        public IEnumerable<Organisme> Get()
        {
            return _mediator.Send(new GetAllGenericQuery<Organisme>())
                .Result.Select(comp => _mapper.Map<Organisme>(comp));
        }
        [HttpGet("{id}")]
        public Organisme Get(Guid id)
        {

            var org = _mediator.Send(new GetGenericQueryById<Organisme>(condition: c => c.OrganismeId == id)).Result;
            return _mapper.Map<Organisme>(org);
        }
        [HttpPost("PostOrganisme")]
        public async Task<Organisme> Post(Organisme org)
        {
            return await _mediator.Send(new PostId<Organisme>(org));
        }
        [HttpDelete("deleteCategory")]
        public string Delete(Guid id)
        {
            return _mediator.Send(new DeleteGeneric<Organisme>(id)).Result;
        }
        [HttpPut("updatecategory")]
        public string Put([FromBody] Organisme org)
        {
            return _mediator.Send(new PutGeneric<Organisme>(org)).Result;
        }

    }
}

