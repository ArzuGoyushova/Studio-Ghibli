using AutoMapper;
using GhibliServer.Application.Dtos.Blog;
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

namespace GhibliServer.Application.Features.Commands.BlogCommands
{
    public class CreateBlogCommand : IRequest<ServiceResponse<Guid>>
    {
        public BlogCreateOrUpdateDto BlogDTO { get; set; }
    }

    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, ServiceResponse<Guid>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = _mapper.Map<Domain.Entities.Blog>(request.BlogDTO);

            if (request.BlogDTO.NewImage != null)
            {
                blog.ImageUrl = ProcessImage(request.BlogDTO.NewImage);
            }

            await _blogRepository.CreateAsync(blog);

            return new ServiceResponse<Guid>(blog.Id);
        }

        private string ProcessImage(IFormFile image)
        {
            var uniqueFileName = MapProfile.GetUniqueFileName(image.FileName);
            var uniqueFileNameWithExtension = uniqueFileName + Path.GetExtension(image.FileName);
            var imageUrl = uniqueFileNameWithExtension;

            string filePath = Path.Combine("https://arzugoyushova.github.io/StudioGhibli/images/blog", uniqueFileNameWithExtension);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return imageUrl;
        }
    }
}
