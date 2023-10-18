using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Blog
{
    public class BlogViewDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ImageUrl { get; set; }
        public Guid? CategoryId { get; set; }
        public string BlogContent { get; set; }
    }
}
