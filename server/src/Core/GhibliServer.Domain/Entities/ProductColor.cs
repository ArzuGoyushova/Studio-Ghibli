﻿using GhibliServer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Domain.Entities
{
    public class ProductColor:BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid ColorId { get; set; }
        public Color Color { get; set; }
    }
}
