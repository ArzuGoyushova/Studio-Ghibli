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
    public class GetAllBlogsQuery : IRequest<ServiceResponse<List<BlogViewDto>>>
    {
        public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, ServiceResponse<List<BlogViewDto>>>
        {
            private readonly IBlogRepository _blogRepository;
            private readonly IMapper _mapper;
            public GetAllBlogsQueryHandler(IBlogRepository blogRepository, IMapper mapper)
            {
                _blogRepository = blogRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<List<BlogViewDto>>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
            {
                var Blogs = await _blogRepository.GetAllItemsAsync();

                var viewModel = _mapper.Map<List<BlogViewDto>>(Blogs);

                return new ServiceResponse<List<BlogViewDto>>(viewModel);
            }
        }
    }
}
