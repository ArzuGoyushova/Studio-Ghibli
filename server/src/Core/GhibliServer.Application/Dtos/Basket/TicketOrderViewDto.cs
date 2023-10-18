﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Basket
{
    public class TicketOrderViewDto
    {
        public Guid TicketOrderId { get; set; }
        public string AppUserId { get; set; }
        public List<BasketItemAddDto> BasketItems { get; set; }
        public double TotalPrice { get; set; }
    }
}
