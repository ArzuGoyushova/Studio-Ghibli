using AutoMapper;
using GhibliServer.Application.Dtos.Account;
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

namespace GhibliServer.Application.Features.Queries.AccountQueries
{
    public class GetUserQuery : IRequest<ServiceResponse<UserProfileViewDto>>
    {
    }

    [Authorize]
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ServiceResponse<UserProfileViewDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserQueryHandler(UserManager<AppUser> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<UserProfileViewDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.Users
                .Include(u=>u.UserMovies)
                .SingleOrDefaultAsync(u=>u.Id == userId);

            var viewModel = _mapper.Map<UserProfileViewDto>(user);

            return new ServiceResponse<UserProfileViewDto>(viewModel);
        }
    }
    
}
