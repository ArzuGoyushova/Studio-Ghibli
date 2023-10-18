using AutoMapper;
using GhibliServer.Application.Dtos.Blog;
using GhibliServer.Application.Features.Commands.BlogCommands;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Profiles;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.BlogCommands
{
    public class UpdateBlogCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid BlogId { get; set; }
        public BlogCreateOrUpdateDto BlogDTO { get; set; }
    }

    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, ServiceResponse<Guid>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingBlog = await _blogRepository.GetItemByIdAsync(request.BlogId);

                if (existingBlog == null)
                {
                    return new ServiceResponse<Guid>(default, "Blog not found.");
                }
                if (request.BlogDTO.NewImage != null)
                {
                    var uniqueFileName = MapProfile.GetUniqueFileName(request.BlogDTO.NewImage.FileName);
                    var uniqueFileNameWithExtension = uniqueFileName + Path.GetExtension(request.BlogDTO.NewImage.FileName);

                    existingBlog.ImageUrl = uniqueFileNameWithExtension;

                    string filePath = Path.Combine("https://arzugoyushova.github.io/StudioGhibli/images/blog", uniqueFileNameWithExtension);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        request.BlogDTO.NewImage.CopyTo(stream);
                    }
                }


                _mapper.Map(request.BlogDTO, existingBlog);

                await _blogRepository.UpdateAsync(existingBlog.Id, existingBlog);

                return new ServiceResponse<Guid>(existingBlog.Id);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Guid>(default, ex.Message);
            }
        }
    }
}
