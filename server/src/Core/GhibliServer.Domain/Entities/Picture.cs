using GhibliServer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Domain.Entities
{
    public class Picture : BaseEntity
    {
        public string ImageUrl { get; set; }
        public bool isMain { get; set; }
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid? MovieId { get; set; } 
        public Movie? Movie { get; set; }
    }
}
