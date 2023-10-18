using GhibliServer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Domain.Entities
{
    public class Color:BaseEntity
    {
        public string Name { get; set; }
        public List<ProductColor> ProductColors { get; set; }

    }
}
