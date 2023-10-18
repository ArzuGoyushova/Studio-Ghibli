using AutoMapper;
using GhibliServer.Application.Dtos.User;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.UserQueries
{
    public class GetUserByIdQuery : IRequest<ServiceResponse<UserViewDto>>
    {
        public Guid Id { get; set; }
    }
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ServiceResponse<UserViewDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<UserViewDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var stringId = request.Id.ToString();
            var user = await _userManager.FindByIdAsync(stringId);


            var userDto = _mapper.Map<UserViewDto>(user);
            var roles = await _userManager.GetRolesAsync(user);
            userDto.Roles = roles;


            return new ServiceResponse<UserViewDto>(userDto);
        }
    }

}