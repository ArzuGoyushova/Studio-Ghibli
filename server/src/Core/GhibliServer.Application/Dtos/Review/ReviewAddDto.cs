using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Review
{
    public class ReviewAddDto
    {
        public string Username { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public Guid MovieId { get; set; }

    }
}
