using AutoMapper;
using Domain.Commands;
using Domain.Dto;
using Domain.Models;
using Domain.Quieres;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class typereqCatgController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public typereqCatgController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        [HttpPost("posttypeRequestCatg")]
        public async Task<typerequestCatg> Post(typerequestCatg Cat)
        {
            return await _mediator.Send(new PostId<typerequestCatg>(Cat));
        }
        [HttpGet("posttypeRequestCatg")]
        public typeRequestCatgDto Get(Guid id)
        {
            var Category = _mediator.Send(new GetGenericQueryById<typerequestCatg>(includes: i => i.Include(x => x.Category).Include(x => x.typeRequest), condition: c => c.Fk_CategoryId == id)).Result;
            return _mapper.Map<typeRequestCatgDto>(Category);
        }
    }
}
