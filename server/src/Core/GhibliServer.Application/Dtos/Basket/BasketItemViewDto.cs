using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Basket
{
    public class BasketItemViewDto
    {
        public Guid EventId { get; set; }
        public Guid AppUserId { get; set; }
        public string TicketCode { get; set; }
        public int? SeatNumber { get; set; }
    }
}
