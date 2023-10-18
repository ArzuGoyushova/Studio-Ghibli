using GhibliServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Product
{
    public class ProductViewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double? OldPrice { get; set; }
        public double RegularPrice { get; set; }
        public int Count { get; set; }
        public int? Discount { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<Guid> ColorIds { get; set; }
        public List<Guid> SizeIds { get; set; }
        public string Desc { get; set; }
        public double Tax { get; set; }
        public string Brand { get; set; }
        public string Code { get; set; }
        public string Availability { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CategoryId { get; set; }
    }
}
