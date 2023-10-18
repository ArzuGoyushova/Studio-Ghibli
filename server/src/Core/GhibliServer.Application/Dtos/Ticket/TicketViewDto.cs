using GhibliServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Ticket
{
    public class TicketViewDto
    {
        public string TicketCode { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid EventId { get; set; }
        public int? SeatNumber { get; set; }
    }
}
