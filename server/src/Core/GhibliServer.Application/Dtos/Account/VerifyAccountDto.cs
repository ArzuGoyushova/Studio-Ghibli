﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Account
{
    public class VerifyAccountDto
    {
        public string Email { get; set; }
        public string Otp { get; set; }
        public string UserId { get; set; }

    }
}
