using GhibliServer.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Domain.Entities
{
    public class Review : BaseEntity
    {
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public Guid? MovieId { get; set; }
        public Movie? Movie { get; set; }

        public Review()
        {
            Date = DateTime.Now;
        }
    }
}
