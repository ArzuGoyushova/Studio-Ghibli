using GhibliServer.Domain.Entities;
using GhibliServer.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.TicketOrder
{
    public class TicketOrderViewDto
    {
        public Guid Id { get; set; }      
        public string OrderNumber { get; set; }
        public string? AppUserId { get; set; }
        public List<Domain.Entities.Ticket> Tickets { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
