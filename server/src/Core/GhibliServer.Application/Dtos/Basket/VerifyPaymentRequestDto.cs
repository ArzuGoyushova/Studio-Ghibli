using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Basket
{
    public class VerifyPaymentRequestDto
    {
        public Guid TicketOrderId { get; set; }
        public string PaymentMethodId { get; set; }
    }
}
