using AutoMapper;
using GhibliServer.Application.Dtos.Role;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using GhibliServer.Domain.Helper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.RoleQueries
{
    public class GetAllRolesQuery : IRequest<ServiceResponse<List<RoleViewDto>>>
    {
    }
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, ServiceResponse<List<RoleViewDto>>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<RoleViewDto>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = _roleManager.Roles;

            var viewModel = _mapper.Map<List<RoleViewDto>>(roles);

            return new ServiceResponse<List<RoleViewDto>>(viewModel);
        }
    }

}
