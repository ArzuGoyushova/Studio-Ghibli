using AutoMapper;
using GhibliServer.Application.Dtos.Account;
using GhibliServer.Application.Profiles;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.AccountCommands
{
    public class UpdatePasswordCommand : IRequest<ServiceResponse<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, ServiceResponse<string>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger _logger;

        public UpdatePasswordCommandHandler(UserManager<AppUser> userManager, ILogger<UpdatePasswordCommandHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<ServiceResponse<string>> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            _logger.LogInformation($"User: {user.Id}, Token: {token}");

            var result = await _userManager.ResetPasswordAsync(user, token, request.Password);
            _logger.LogInformation($"Reset result: {result.Succeeded}");

            var response = new ServiceResponse<string>();

            if (result.Succeeded)
            {
                response.Success = true;
                response.Message = "Password updated successfully.";
            }
            else
            {
                response.SetErrors(result.Errors.Select(error => error.Description).ToList());
            }

            return response;
        }

    }
}
