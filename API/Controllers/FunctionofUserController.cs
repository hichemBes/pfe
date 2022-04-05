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
    public class FunctionofUserController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public FunctionofUserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet("getallfunctionofuser")]
        public IEnumerable<FunctionofUserDto> get()
        {
            var data = _mediator.Send(new GetAllGenericQuery<FunctionofUser>(includes: i => i.Include(x => x.Function)
              )).Result.Select(data => _mapper.Map<FunctionofUserDto>(data));

            return data;

        }
        [HttpGet("getfonctionobyuser")]
        public IEnumerable<FunctionofUserDto> getuserofuserbyId(Guid IdUser)
        {
            var data = _mediator.Send(new GetAllGenericQuery<FunctionofUser>(includes: i => i.Include(x => x.Function)
             , condition: (g => g.Fk_User == IdUser))).Result.Select(data => _mapper.Map<FunctionofUserDto>(data));

            return data;

        }
        [HttpGet("getfonctionobyid")]
        public IEnumerable<FunctionofUserDto> getuserbyfunction(Guid Id)
        {
            var data = _mediator.Send(new GetAllGenericQuery<FunctionofUser>(includes: i => i.Include(x => x.Function)
             , condition: (g => g.Function.IdFunction == Id))).Result.Select(data => _mapper.Map<FunctionofUserDto>(data));

            return data;

        }
        [HttpPost("postfunctionofuser")]
        public async Task<FunctionofUser> Post(FunctionofUser f)
        {
            return await _mediator.Send(new PostId<FunctionofUser>(f));
        }

        [HttpDelete("delete")]
        public string Delete(Guid id)
        {
            return _mediator.Send(new DeleteGeneric<FunctionofUser>(id)).Result;
        }
    }
}
