using GhibliServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Account
{
    public class LoginResultDto
    {
        public AppUser User { get; set; }
        public IList<string> UserRoles { get; set; }
    }
}
