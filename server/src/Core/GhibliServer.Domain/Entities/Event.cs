using GhibliServer.Domain.Common;
using GhibliServer.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Domain.Entities
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string? ImageUrl { get; set; }
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
        public EventType EventType { get; set; }
        public int? MaxSeats { get; set; }
        public string? ReservedSeats { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
