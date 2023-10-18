using AutoMapper;
using GhibliServer.Application.Dtos.Account;
using GhibliServer.Application.Dtos.User;
using GhibliServer.Application.Features.Queries.AccountQueries;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.UserQueries
{
    public class GetAllUsersQuery : IRequest<ServiceResponse<List<UserViewDto>>>
    {
    }
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ServiceResponse<List<UserViewDto>>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<UserViewDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.ToList();
            var userDtos = new List<UserViewDto>();

            foreach (var user in users)
            {
                var userDto = _mapper.Map<UserViewDto>(user);
                var roles = await _userManager.GetRolesAsync(user);
                userDto.Roles = roles;
                userDtos.Add(userDto);
            }

            return new ServiceResponse<List<UserViewDto>>(userDtos);
        }
    }

}