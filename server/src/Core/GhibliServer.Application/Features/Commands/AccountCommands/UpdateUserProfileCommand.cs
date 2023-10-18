using AutoMapper;
using GhibliServer.Application.Dtos.Account;
using GhibliServer.Application.Profiles;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GhibliServer.Application.Features.Commands.AccountCommands
{
    public class UpdateUserProfileCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public UserProfileUpdateDto ProfileDTO { get; set; }
    }

    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, ServiceResponse<Guid>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UpdateUserProfileCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var stringId = request.Id.ToString();
            var user = await _userManager.FindByIdAsync(stringId);

            if (user == null)
            {
                return null;
            }

            if (request.ProfileDTO.Image != null) 
            {
                var uniqueFileName = MapProfile.GetUniqueFileName(request.ProfileDTO.Image.FileName);
                var uniqueFileNameWithExtension = uniqueFileName + Path.GetExtension(request.ProfileDTO.Image.FileName);

                user.ImageUrl = uniqueFileNameWithExtension;

                string filePath = Path.Combine("https://arzugoyushova.github.io/StudioGhibli/images/users", uniqueFileNameWithExtension);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    request.ProfileDTO.Image.CopyTo(stream);
                }
            }

            if (request.ProfileDTO.MovieIds != null)
            {
                user.UserMovies.Clear();
                foreach (var mId in request.ProfileDTO.MovieIds)
                {
                    user.UserMovies.Add(new UserMovie { MovieId = mId });
                }
            }
            _mapper.Map(request.ProfileDTO, user);

            await _userManager.UpdateAsync(user);

            return new ServiceResponse<Guid>(request.Id);
        }

    }
}
