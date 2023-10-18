using GhibliServer.Application.Dtos.Account;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.AccountCommands
{
    public class MarkPhoneNumberVerifiedCommand : IRequest<ServiceResponse<string>>
    {
        public string UserId { get; set; }
    }
    public class MarkPhoneNumberVerifiedCommandHandler : IRequestHandler<MarkPhoneNumberVerifiedCommand, ServiceResponse<string>>
    {
        private readonly UserManager<AppUser> _userManager;

        public MarkPhoneNumberVerifiedCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ServiceResponse<string>> Handle(MarkPhoneNumberVerifiedCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null)
            {
                var response = new ServiceResponse<string>();
                response.SetErrors(new List<string> { "User not found" });
                return response;
            }

            var result = await _userManager.SetPhoneNumberAsync(user, user.PhoneNumber);

            if (result.Succeeded)
            {
                user.PhoneNumberConfirmed = true;
                await _userManager.UpdateAsync(user);
                var response = new ServiceResponse<string> { Success = true, Message = "Phone number verified successfully" };
                return response;
            }
            else
            {
                var response = new ServiceResponse<string>();
                response.SetErrors(result.Errors.Select(error => error.Description).ToList());

                return new ServiceResponse<string> { Success = true, Message = "Phone number marked as verified." };
            }
        }
    }


}
