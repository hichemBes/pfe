using AutoMapper;
using Data.Repositry;
using Domain.Commands;
using Domain.Dto;
using Domain.Interface;
using Domain.Models;
using Domain.Quieres;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiecesController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly Data.Context.DBContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public PiecesController(IMediator mediator, IMapper mapper, IWebHostEnvironment env, Data.Context.DBContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _env = env;
            _context = context;
            _hubContext = hubContext;

        }
        [HttpGet("getPieceuser")]
        public  Guid  getuserofuserbyId(Guid Id)
        {
            var data = _mediator.Send(new GetAllGenericQuery<PieceJoint>(includes: i => i.Include(x => x.Requests)
             , condition: (g => g.fk_Request == Id))).Result.Select(data => _mapper.Map<PieceDto>(data));
            var x=data.FirstOrDefault();
            return x.fk_user;
              

        }


        [HttpGet("getbyrequest")]
        public IEnumerable<Domain.Models.PieceJoint> Getbyrequest(Guid id )
        {
            return _mediator.Send(new GetAllGenericQuery<Domain.Models.PieceJoint>(g => g.fk_Request == id)).Result.Select(data => _mapper.Map<Domain.Models.PieceJoint>(data));
        }
        [HttpDelete("Delete")]
        public string  Delete(Guid id)
        {
            return _mediator.Send(new DeleteGeneric<Domain.Models.PieceJoint>(id)).Result;
        }
        [HttpPost("uploadfile")]
        public async Task<IActionResult> uplodsfile(List<IFormFile> files, Guid fk)
        {
            long size = files.Sum(f => f.Length);
            var root = Path.Combine(_env.ContentRootPath, "ressources", "Documents");
            if (!Directory.Exists(root))

                Directory.CreateDirectory(root);

            foreach (var file in files)
            {
                var filepath = Path.Combine(root, file.FileName);
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    var PieceJoint = new Domain.Models.PieceJoint
                    {

                        Name = file.FileName,
                        fk_Request = fk,
                        path = filepath,


                    };
                    Notification notification = new Notification()
                    {
                        Message = "Nouvelle Piece Jointe a  été mise à jour ",
                        RequestId = fk,
                        userId = getuserofuserbyId(fk),

                    };
                    _context.Notifications.Add(notification);
                    _context.SaveChangesAsync();
                    _hubContext.Clients.All.BroadcastMessage();
                
                file.CopyToAsync(stream);

                    _mediator.Send(new PostId<Domain.Models.PieceJoint>(PieceJoint));

                }
            }




            return Ok(new { count = files.Count, size });
        }






        [HttpGet("download/{id}")]
        public async Task<ActionResult> Download(Guid id)
        {
            var provider = new FileExtensionContentTypeProvider();
            var data = _mediator.Send(new GetGenericQueryById<Domain.Models.PieceJoint>(g => g.PieceId == id)).Result;
            if (data == null)

                return BadRequest("data is emptyy ");


            var file = data.path;
            string contenttype;
            if (!provider.TryGetContentType(file, out contenttype))
            {
                contenttype = "application/octet-stream";
            }
            byte[] filebytes;
            if (System.IO.File.Exists(file))
            {

                filebytes = System.IO.File.ReadAllBytes(file);
            }
            else
            {
                return NotFound("file doest exist ");
            }

            return File(filebytes, contenttype, data.Name);
        }




    }
}