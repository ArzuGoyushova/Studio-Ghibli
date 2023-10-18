using GhibliServer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public double? OldPrice { get; set; }
        public double RegularPrice { get; set; }
        public int Count { get; set; }
        public int? Discount { get; set; }
        public string Desc { get; set; }
        public double Tax { get; set; }
        public string Brand { get; set; }
        public string Code { get; set; }
        public string Availability { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Picture> Pictures { get; set; }
        public List<ProductColor>? ProductColors { get; set; }
        public List<ProductSize>? ProductSizes { get; set; }
        public List<Review>? Reviews { get; set; }
        public Product()
        {
            Pictures = new();
            ProductColors = new();
            ProductSizes = new();
        }
    }
}
