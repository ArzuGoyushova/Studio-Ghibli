using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }

        public List<UserMovie>? UserMovies { get; set; } = new List<UserMovie>();

        public bool IsBlocked { get; set; }
        public string? ConnectionId { get; set; }
        public string? OTP { get; set; }
        public string? VerificationRequestId { get; set; }
    }
}
