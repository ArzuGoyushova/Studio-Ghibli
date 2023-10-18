using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.User
{
    public class ChangeRolesDto
    {
        public IList<string> Roles { get; set; }
    }
}
