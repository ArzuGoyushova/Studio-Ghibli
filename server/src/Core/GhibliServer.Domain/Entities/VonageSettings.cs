using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Domain.Entities
{
    public class VonageSettings
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string Number { get; set; }
    }
}
