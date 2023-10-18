using GhibliServer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public int RunningTime { get; set; }
        public string Genre { get; set; }
        public string TrailerVideoUrl { get; set; }
        public string MainVideoUrl { get; set; }
        public double ImdbRating { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Picture> Pictures { get; set; }
        public List<UserMovie>? UserMovies { get; set; }
        public List<Review>? Reviews { get; set; }
        public Movie()
        {
            Pictures = new();
        }
    }
}
