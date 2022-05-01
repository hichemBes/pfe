using AutoMapper;
using Data.Repositry;
using Domain.Commands;
using Domain.Dto;
using Domain.Interface;
using Domain.Models;
using Domain.Quieres;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly Data.Context.DBContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public CategoryController(IMediator mediator, IMapper mapper, Data.Context.DBContext context, IHubContext<BroadcastHub,IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public IEnumerable<Category> Get()
        {
            return _mediator.Send(new GetAllGenericQuery<Category>())
                .Result.Select(comp => _mapper.Map<Category>(comp));
        }

        [HttpGet("{id}")]
        public Category Get(Guid id)
        {

            var Category = _mediator.Send(new GetGenericQueryById<Category>(condition: c => c.CategoryId == id)).Result;
            return _mapper.Map<Category>(Category);
        }

        [HttpPost("PostCategory")]
        public async Task<Category> Post(Category Cat)
        {
            return await _mediator.Send(new PostId<Category>(Cat));
        }

        [HttpDelete("deleteCategory")]
        public string Delete(Guid id)
        {
            Notification notification = new Notification()
            {
                Message = " Suprission de categorie",
                Id=Guid.NewGuid(),

            };
            _context.Notifications.Add(notification);
            _hubContext.Clients.All.BroadcastMessage();
            return _mediator.Send(new DeleteGeneric<Category>(id)).Result;
        }
        [HttpPut("updatecategory")]
        public string Put([FromBody] Category Cat)
        {
            return _mediator.Send(new PutGeneric<Category>(Cat)).Result;
            //Notification notification = new Notification()
            //{ Message = "a"
            //};
        }

        [HttpGet("GetbyidFunction")]
        public IEnumerable<CategoryFunctionDto> getCategorybuFunctionId(Guid IdFonction)
        {
            var data = _mediator.Send(new GetAllGenericQuery<CategoryFunction>(includes:
                e => e.Include(z => z.Category).
               Include(s => s.Function).ThenInclude(it => it.FunctionofUsers), condition: (g => g.Function.IdFunction == IdFonction)
              )).Result.Select(data => _mapper.Map<CategoryFunctionDto>(data));
        
            return data;
        }

            //}
            //[HttpGet("Getcatbyusercin")]
            //public IEnumerable<CategoryFunctionUserDto> Getcatbyusercin(string Cin)
            //{
            //    var data = _mediator.Send(new GetAllGenericQuery<CategoryFunctionUser>(includes:
            //        e => e.Include(z => z.Category).
            //       Include(s => s.FunctionofUser).ThenInclude(it => it.Function), condition: (g =>g.FunctionofUser.Fk_User)
            //      )).Result.Select(data => _mapper.Map<CategoryFunctionUserDto>(data));

            //    return data;

            //}
        }
    }
