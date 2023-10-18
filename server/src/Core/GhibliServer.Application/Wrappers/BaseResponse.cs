using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Wrappers
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public String Message { get; set; }
    }
}
