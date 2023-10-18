using GhibliServer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ImageUrl { get; set; }
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
        public string BlogContent { get; set; }
        public bool IsDeleted { get; set; }
    }
}
