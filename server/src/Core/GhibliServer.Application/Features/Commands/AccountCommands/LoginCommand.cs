using GhibliServer.Application.Dtos.Account;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.AccountCommands
{
    public class LoginCommand : IRequest<ServiceResponse<LoginResultDto>>
    {
        public LoginDto LoginDto { get; set; }
    }
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ServiceResponse<LoginResultDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ServiceResponse<LoginResultDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = new ServiceResponse<LoginResultDto>();

            var validator = new LoginDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LoginDto);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                response.SetErrors(errorMessages);
                return response;
            }

            var user = await _userManager.FindByNameAsync(request.LoginDto.UserNameOrEmail)
                       ?? await _userManager.FindByEmailAsync(request.LoginDto.UserNameOrEmail);

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.LoginDto.Password, false);

            if (!signInResult.Succeeded)
            {
                response.Success = false;
                response.Message = "Invalid username or password.";
                return response;
            }

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
