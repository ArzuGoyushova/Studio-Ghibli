using GhibliServer.Application.Dtos.Account;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.AccountCommands
{
    public class GoogleLoginCommand : IRequest<ServiceResponse<LoginResultDto>>
    {
        public string GoogleCredentialEmail { get; set; }
    }
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommand, ServiceResponse<LoginResultDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public GoogleLoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ServiceResponse<LoginResultDto>> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
        {
            
            var response = new ServiceResponse<LoginResultDto>();

            var user = await _userManager.FindByEmailAsync(request.GoogleCredentialEmail);

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }

            await _signInManager.SignInAsync(user, isPersistent: true);

            var userRoles = await _userManager.GetRolesAsync(user);

            var loginResult = new LoginResultDto
            {
                User = user,
                UserRoles = userRoles
            };

            response.Success = true;
            response.Message = "Login successful.";
            response.Value = loginResult;

            return response;

        }
    }

}
