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
    public class CategFunctionController:ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CategFunctionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IEnumerable<CategoryFunctionDto> Get()
        {
            return _mediator.Send(new GetAllGenericQuery<CategoryFunction>(includes: i => i.Include(x => x.Category).Include(a=>a.Function)))
                .Result.Select(comp => _mapper.Map<CategoryFunctionDto>(comp));
        }

        [HttpPost("PostCategory")]
        public async Task<CategoryFunction> Post(CategoryFunction Cat)
        {
            return await _mediator.Send(new PostId<CategoryFunction>(Cat));
        }
        [HttpPut("updatecategory")]
        public string Put([FromBody] CategoryFunction Cat)
        {
            return _mediator.Send(new PutGeneric<CategoryFunction>(Cat)).Result;
        }
        [HttpGet("getbycategoryId")]
       
          public IEnumerable<CategoryFunctionDto> getCategorybuFunctionId(Guid categoryId)
            {
                var data = _mediator.Send(new GetAllGenericQuery<CategoryFunction>(includes:
                    e => e.Include(z => z.Category).
                   Include(s => s.Function).ThenInclude(it => it.FunctionofUsers), condition: (g => g.Category.CategoryId== categoryId)
                  )).Result.Select(data => _mapper.Map<CategoryFunctionDto>(data));

                return data;
            }
        [HttpDelete("deleteFunctioncat")]
        public string Delete(Guid id)
        {
            return _mediator.Send(new DeleteGeneric<CategoryFunction>(id)).Result;
        }
    }
    }

