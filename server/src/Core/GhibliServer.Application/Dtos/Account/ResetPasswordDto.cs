using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Dtos.Account
{
    public class ResetPasswordDto
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
