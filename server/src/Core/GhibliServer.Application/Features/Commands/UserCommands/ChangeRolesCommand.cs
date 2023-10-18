using AutoMapper;
using GhibliServer.Application.Dtos.Account;
using GhibliServer.Application.Dtos.User;
using GhibliServer.Application.Features.Commands.AccountCommands;
using GhibliServer.Application.Profiles;
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
    public class ChangeRolesCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public ChangeRolesDto ChangeRolesDTO { get; set; }
    }

    public class ChangeRolesCommandHandler : IRequestHandler<ChangeRolesCommand, ServiceResponse<Guid>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public ChangeRolesCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(ChangeRolesCommand request, CancellationToken cancellationToken)
        {
            var stringId = request.Id.ToString();
            var user = await _userManager.FindByIdAsync(stringId);

            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, request.ChangeRolesDTO.Roles);

            _mapper.Map(request.ChangeRolesDTO, user);

            await _userManager.UpdateAsync(user);

            return new ServiceResponse<Guid>(request.Id);
        }

    }
}
