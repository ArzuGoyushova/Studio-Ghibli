using AutoMapper;
using GhibliServer.Application.Dtos.About;
using GhibliServer.Application.Exceptions;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Profiles;
using GhibliServer.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.AboutCommands
{
    public class UpdateAboutCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid AboutId { get; set; }
        public AboutCreateOrUpdateDto AboutDTO { get; set; }
    }

    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, ServiceResponse<Guid>>
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IMapper _mapper;

        public UpdateAboutCommandHandler(IAboutRepository aboutRepository, IMapper mapper)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _aboutRepository.GetItemByIdAsync(request.AboutId);

            if (about == null)
            {
                throw new NotFoundException();
            }

            _mapper.Map(request.AboutDTO, about);

            if (request.AboutDTO.OriginImage != null)
            {
                ProcessImage(request.AboutDTO.OriginImage, about.OriginImageUrl);
            }

            if (request.AboutDTO.HeightImage != null)
            {
                ProcessImage(request.AboutDTO.HeightImage, about.HeightImageUrl);
            }
            if (request.AboutDTO.FutureImage != null)
            {
                ProcessImage(request.AboutDTO.FutureImage, about.FutureImageUrl);
            }

            if (request.AboutDTO.GhibliImage != null)
            {
                ProcessImage(request.AboutDTO.GhibliImage, about.GhibliImageUrl);
            }
            if (request.AboutDTO.MessageImage != null)
            {
                ProcessImage(request.AboutDTO.MessageImage, about.MessageImageUrl);
            }

            if (request.AboutDTO.GlobalImage != null)
            {
                ProcessImage(request.AboutDTO.GlobalImage, about.GlobalImageUrl);
            }

            await _aboutRepository.UpdateAsync(about.Id, about);

            return new ServiceResponse<Guid>(about.Id);
        }
        private void ProcessImage(IFormFile image, string imageUrl)
        {
            var uniqueFileName = MapProfile.GetUniqueFileName(image.FileName);
            var uniqueFileNameWithExtension = uniqueFileName + Path.GetExtension(image.FileName);
            imageUrl = uniqueFileNameWithExtension;

            string filePath = Path.Combine("https://arzugoyushova.github.io/StudioGhibli/images/about", uniqueFileNameWithExtension);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }
        }
    }
    }
