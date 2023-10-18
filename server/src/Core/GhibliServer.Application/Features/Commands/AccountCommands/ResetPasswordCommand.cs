using GhibliServer.Application.Dtos.Account;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.AccountCommands
{
    public class ResetPasswordCommand : IRequest<ResetPasswordDto>
    {
        public string Email { get; set; }
    }

    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordDto>
    {
        private readonly UserManager<AppUser> _userManager;
        public ResetPasswordCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResetPasswordDto> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return null;
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetPasswordDto = new ResetPasswordDto
            {
                Token = resetToken,
                Email = user.Email
            };

            return resetPasswordDto; ;
        }
    }
}
