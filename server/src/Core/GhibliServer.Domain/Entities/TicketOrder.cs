using GhibliServer.Domain.Common;
using GhibliServer.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Domain.Entities
{
    public class TicketOrder : BaseEntity
    {
        public string OrderNumber { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }

}
