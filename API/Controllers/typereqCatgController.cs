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
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class typereqCatgController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public typereqCatgController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        [HttpPost("Post")]
        public  Task<typerequestCatg> Post([FromBody]typerequestCatg Cat)
        {
           
                return _mediator.Send(new PostId<typerequestCatg>(Cat));
            
          
        }
        [HttpGet("gettypeRequestCatg")]
        public IEnumerable<typeRequestCatgDto>Get(Guid id)
        {
            var data = _mediator.Send(new GetAllGenericQuery<typerequestCatg>(includes:
             e => e.Include(z => z.Category).Include(s => s.typeRequest), condition: (g => g.Fk_CategoryId==id))
               ).Result.Select(data => _mapper.Map<typeRequestCatgDto>(data));
            return data;
        }
        [HttpGet("gettypeRequestCatg2")]
        public IEnumerable<typeRequestCatgDto>  Get2(Guid id)
        {
            var data = _mediator.Send(new GetAllGenericQuery<typerequestCatg>(includes:
                 e => e.Include(z => z.Category).Include(s => s.typeRequest), condition: (g => g.FK_typeRequest == id))
                   ).Result.Select(data => _mapper.Map<typeRequestCatgDto>(data));
            return data;

        }
        [HttpDelete("delete")]
        public string  Delete (Guid idcategory)
        {
            return _mediator.Send(new DeleteGeneric<typerequestCatg>(idcategory)).Result;
          

        }
    }
}
