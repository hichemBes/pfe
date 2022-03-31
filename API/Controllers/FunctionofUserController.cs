using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Domain.Quieres;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionofUserController:ControllerBase
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
    }
}
