using AutoMapper;
using Data.Repositry;
using Domain.Interface;
using Domain.Models;
using Domain.Quieres;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class NotificationControlleur : ControllerBase
    {
        private readonly Data.Context.DBContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly IMapper _mapper;

        public NotificationControlleur(Data.Context.DBContext context, IHubContext<BroadcastHub, IHubClient> hubContext, IMapper mapper)
        {
            _context = context;
            _hubContext = hubContext;
            _mapper = mapper;
        }


        [HttpGet("Find")]
        public IEnumerable<Notification> GetNotificationCount()
        {
            var notifications = _context.Notifications;
            return notifications;

        }
        [HttpGet("findbyuser")]
        public IEnumerable<Notification> GetNotifi(Guid id)
        {


            var notifications = _context.Notifications.Where(b => b.userId == id);  
             return notifications;


        }
        [HttpGet("Message")]
        public IEnumerable<Notification> GetNotifi(string message)
        {


            var notifications = _context.Notifications.Where(b => b.Message == message);
            return notifications;


        }
        [HttpDelete("Delete")]
        public string Delete(Guid id)
        {
            var Notification = _context.Notifications.Find(id);
            _context.Notifications.Remove(Notification);
            _context.SaveChanges();
            return "Done";

        }
    }
}
