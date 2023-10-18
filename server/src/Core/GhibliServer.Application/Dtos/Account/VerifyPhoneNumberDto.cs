using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Account
{
    public class VerifyPhoneNumberDto
    {
        public string Otp { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
    }
}
