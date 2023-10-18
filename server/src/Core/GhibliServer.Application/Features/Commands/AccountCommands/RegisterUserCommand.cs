using GhibliServer.Application.Dtos.Account;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using GhibliServer.Domain.Helper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.AccountCommands
{
    public class RegisterUserCommand : IRequest<ServiceResponse<string>>
    {
        public RegisterDto RegisterDto { get; set; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ServiceResponse<string>>
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ServiceResponse<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new RegisterDtoValidator();
            var validationResult = await validator.ValidateAsync(request.RegisterDto);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return new ServiceResponse<string> { Success = false, Errors = errorMessages };
            }

            AppUser user = await _userManager.FindByNameAsync(request.RegisterDto.UserName);

            if (user != null)
            {
                return new ServiceResponse<string> { Success = false, Message = "Username already exists." };
            }

            user = new AppUser();
            user.FullName = request.RegisterDto.FullName;
            user.Email = request.RegisterDto.Email;
            user.UserName = request.RegisterDto.UserName;
            user.PhoneNumber = request.RegisterDto.PhoneNumber;

            var result = await _userManager.CreateAsync(user, request.RegisterDto.Password);

            if (!result.Succeeded)
            {
                var registrationErrors = result.Errors.Select(error => error.Description).ToList();
                return new ServiceResponse<string> { Success = false, Errors = registrationErrors };
            }
            var userId = user.Id;
            result = await _userManager.AddToRoleAsync(user, "Member");
            return new ServiceResponse<string>(userId) { Success = true, Message = "User registered successfully." };
        }
    }
}
