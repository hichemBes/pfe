using AutoMapper;
using Domain.Quieres;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.EntityFrameworkCore;
using Domain.Dto;
using System;
using Domain.Models;
using System.Net.Http;
using Newtonsoft.Json;

using Domain.Commands;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public FunctionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        [HttpGet]
        public IEnumerable<Domain.Models.Function> Get()
        {
            return _mediator.Send(new GetAllGenericQuery<Domain.Models.Function>()).Result.Select(data => _mapper.Map<Domain.Models.Function>(data));
        }
        [HttpGet("getFunctionByid")]
        public Function GetbyId(Guid id)
        {
            var data = _mediator.Send(new GetGenericQueryById<Function>(g => g.IdFunction == id)).Result;
            return _mapper.Map<Function>(data);
        }


        //[HttpGet("getFunctionbycat")]
        //public IEnumerable<CategoryFunctionUserDto> getFunctionbycat(Guid Idcat)
        //{
        //    var data = _mediator.Send(new GetAllGenericQuery<CategoryFunction>(includes:
        //        e => e.Include(z => z.Category).
        //       Include(s => s.Function).ThenInclude(it => it.FunctionofUser), condition: (g => g.Category.CategoryId== Idcat)
        //      )).Result.Select(data => _mapper.Map<CategoryFunctionUserDto>(data));

        //    return data;

        //}
        
        //[HttpGet("getuser")]
        //public UserDto GetSubsidiaryById(Guid id )
        //{
        //    HttpClient _httpClient = new HttpClient();
        //    HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44353/api/User/getById?id=" + id).Result;
        //    response.EnsureSuccessStatusCode();
        //    System.Console.WriteLine("response.Headers: " + response.Headers.ToString());
        //    var responseBody = response.Content.ReadAsStringAsync().Result;
        //    return JsonConvert.DeserializeObject<UserDto>(responseBody);
        //}
        [HttpDelete("deleteFunction")]
        public string Delete(Guid id)
        {
            return _mediator.Send(new DeleteGeneric<Function>(id)).Result;
        }
        [HttpPost("postFunction")]
        public Function Post([FromBody] Function Action)
        {
            return _mediator.Send(new PostId<Function>(Action)).Result;
        }
        [HttpPut("updateFunction")]
        public string Put([FromBody] Function Functio)
        {
            return _mediator.Send(new PutGeneric<Function>(Functio)).Result;
        }
        [HttpPost("postFunctionofuser")]
        public Function Functionofuser([FromBody] Function Action)
        {
            return _mediator.Send(new PostId<Function>(Action)).Result;
        }

    }

}