using AutoMapper;
using GhibliServer.Application.Dtos.About;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Profiles;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace GhibliServer.Application.Features.Commands.AboutCommands
{
    public class CreateAboutCommand : IRequest<ServiceResponse<Guid>>
    {
        public AboutCreateOrUpdateDto AboutDTO { get; set; }
    }

    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, ServiceResponse<Guid>>
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IMapper _mapper;

        public CreateAboutCommandHandler(IAboutRepository aboutRepository, IMapper mapper)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = _mapper.Map<About>(request.AboutDTO);

            if (request.AboutDTO.OriginImage != null)
            {
                about.OriginImageUrl = ProcessImage(request.AboutDTO.OriginImage);
            }


            if (request.AboutDTO.HeightImage != null)
            {
                about.HeightImageUrl = ProcessImage(request.AboutDTO.HeightImage);
            }
            if (request.AboutDTO.FutureImage != null)
            {
                about.FutureImageUrl = ProcessImage(request.AboutDTO.FutureImage);
            }

            if (request.AboutDTO.GhibliImage != null)
            {
                about.GhibliImageUrl = ProcessImage(request.AboutDTO.GhibliImage);
            }
            if (request.AboutDTO.MessageImage != null)
            {
                about.MessageImageUrl = ProcessImage(request.AboutDTO.MessageImage);
            }

            if (request.AboutDTO.GlobalImage != null)
            {
                about.GlobalImageUrl = ProcessImage(request.AboutDTO.GlobalImage);
            }

            await _aboutRepository.CreateAsync(about);

            return new ServiceResponse<Guid>(about.Id);
        }


        private string ProcessImage(IFormFile image)
        {
            var uniqueFileName = MapProfile.GetUniqueFileName(image.FileName);
            var uniqueFileNameWithExtension = uniqueFileName + Path.GetExtension(image.FileName);
            var imageUrl = uniqueFileNameWithExtension;

            string filePath = Path.Combine("https://arzugoyushova.github.io/StudioGhibli/images/about", uniqueFileNameWithExtension);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return imageUrl;
        }

    }


}
