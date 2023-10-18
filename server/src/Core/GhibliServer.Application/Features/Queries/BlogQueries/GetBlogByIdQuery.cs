using AutoMapper;
using GhibliServer.Application.Dtos.Blog;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.BlogQueries
{
    public class GetBlogByIdQuery : IRequest<ServiceResponse<BlogViewDto>>
    {
        public Guid Id { get; set; }
        public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, ServiceResponse<BlogViewDto>>
        {
            private readonly IBlogRepository _blogRepository;
            private readonly IMapper _mapper;
            public GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper)
            {
                _blogRepository = blogRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<BlogViewDto>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
            {
                var blog = await _blogRepository.GetItemByIdAsync(request.Id);

                var viewModel = _mapper.Map<BlogViewDto>(blog);

                return new ServiceResponse<BlogViewDto>(viewModel);
            }
        }
    }
}

