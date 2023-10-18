using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Movie
{
    public class MovieViewDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public int RunningTime { get; set; }
        public string Genre { get; set; }
        public string TrailerVideoUrl { get; set; }
        public string MainVideoUrl { get; set; }
        public double ImdbRating { get; set; }
        public List<string> ImageUrls { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CategoryId { get; set; }
    }
}
