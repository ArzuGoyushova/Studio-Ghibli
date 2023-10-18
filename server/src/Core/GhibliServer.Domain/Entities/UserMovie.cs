using GhibliServer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Domain.Entities
{
    public class UserMovie : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
