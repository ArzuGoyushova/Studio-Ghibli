using MediatR;
using GhibliServer.Application.Wrappers;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using GhibliServer.Domain.Entities;

namespace GhibliServer.Application.Features.Commands.AccountCommands
{
    public class MarkAccountAsVerifiedCommand : IRequest<ServiceResponse<string>>
    {
        public string UserId { get; set; }
    }

    public class MarkAccountAsVerifiedCommandHandler : IRequestHandler<MarkAccountAsVerifiedCommand, ServiceResponse<string>>
    {
        private readonly UserManager<AppUser> _userManager;

        public MarkAccountAsVerifiedCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ServiceResponse<string>> Handle(MarkAccountAsVerifiedCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null)
            {
                return new ServiceResponse<string> { Success = false, Message = "User not found." };
            }

            user.EmailConfirmed = true; 
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                var updateErrors = result.Errors.Select(error => error.Description).ToList();
                return new ServiceResponse<string> { Success = false, Errors = updateErrors };
            }

            return new ServiceResponse<string> { Success = true, Message = "Account marked as verified." };
        }
    }
}
