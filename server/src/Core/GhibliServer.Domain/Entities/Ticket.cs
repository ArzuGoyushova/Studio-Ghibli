using GhibliServer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public string TicketCode { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public int? SeatNumber { get; set; }
    }

}
