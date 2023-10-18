using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Subscription
{
    public class SubscriptionViewDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}
