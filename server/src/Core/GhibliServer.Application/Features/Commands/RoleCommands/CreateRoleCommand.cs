using AutoMapper;
using GhibliServer.Application.Dtos.Role;
using GhibliServer.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.RoleCommands
{
    public class CreateRoleCommand : IRequest<ServiceResponse<string>>
    {
        public RoleCreateDto RoleDTO { get; set; }
    }

    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, ServiceResponse<string>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<IdentityRole>(request.RoleDTO);

            await _roleManager.CreateAsync(role);

            return new ServiceResponse<string>(role.Id);
        }

    }
}

