using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.UserCommands
{
    public class ToggleIsBlockedCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
    }

    public class ToggleIsBlockedCommandHandler : IRequestHandler<ToggleIsBlockedCommand, ServiceResponse<Guid>>
    {
        private readonly UserManager<AppUser> _userManager;

        public ToggleIsBlockedCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ServiceResponse<Guid>> Handle(ToggleIsBlockedCommand request, CancellationToken cancellationToken)
        {
            var stringId = request.Id.ToString();
            var existingUser = await _userManager.FindByIdAsync(stringId);

            if (existingUser != null)
            {
                existingUser.IsBlocked = !existingUser.IsBlocked;
            } else
            {
                return null;
            }
           
            await _userManager.UpdateAsync(existingUser);

            return new ServiceResponse<Guid>(request.Id);
        }
    }
}
