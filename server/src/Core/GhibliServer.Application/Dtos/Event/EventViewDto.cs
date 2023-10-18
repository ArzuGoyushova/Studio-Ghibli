using GhibliServer.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Event
{
    public class EventViewDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public EventType EventType { get; set; }
        public int? MaxSeats { get; set; }
        public Guid? CategoryId { get; set; }
        public string? ReservedSeats { get; set; }
        public double Price { get; set; }
    }

}
