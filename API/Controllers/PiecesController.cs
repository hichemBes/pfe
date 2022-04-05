using AutoMapper;
using Domain.Commands;
using Domain.Quieres;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
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
        public PiecesController(IMediator mediator, IMapper mapper, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _mapper = mapper;
            _env = env;

        }
        [HttpGet]
        public IEnumerable<Domain.Models.PieceJoint> Get()
        {
            return _mediator.Send(new GetAllGenericQuery<Domain.Models.PieceJoint>()).Result.Select(data => _mapper.Map<Domain.Models.PieceJoint>(data));
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

                        Name = file.Name,
                        fk_Request = fk,
                        path = filepath,


                    };
                    file.CopyToAsync(stream);
                    _mediator.Send(new PostId<Domain.Models.PieceJoint>(PieceJoint));

                }
            }
            return Ok(new { count = files.Count, size });
        }






        [HttpPost("download/{id}")]
        public async Task<ActionResult> Download(Guid id)
        {
            var provider = new FileExtensionContentTypeProvider();
            var data = _mediator.Send(new GetGenericQueryById<Domain.Models.PieceJoint>(g => g.PieceId == id)).Result;
            if (data == null)
            
                return BadRequest("data is emptyy ");


            var file = data.path;
            string contenttype;
            if(!provider.TryGetContentType(file,out contenttype))
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
