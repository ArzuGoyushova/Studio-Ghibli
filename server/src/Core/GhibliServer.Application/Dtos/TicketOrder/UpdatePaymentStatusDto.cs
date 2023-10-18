using GhibliServer.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.TicketOrder
{
    public class UpdatePaymentStatusDto
    {
        public Guid Id { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
