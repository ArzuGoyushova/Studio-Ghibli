using AutoMapper;
using GhibliServer.Application.Dtos.Category;
using GhibliServer.Application.Dtos.Color;
using GhibliServer.Application.Features.Queries.ColorQueries;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery : IRequest<ServiceResponse<CategoryViewDto>>
    {
        public Guid Id { get; set; }
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, ServiceResponse<CategoryViewDto>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<CategoryViewDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetItemByIdWithIncludesAsync(
                    request.Id,
                    c => c.SubCategories,
                    c => c.Products,
                    c => c.Blogs,
                    c => c.Movies);

                var viewModel = _mapper.Map<CategoryViewDto>(category);

                return new ServiceResponse<CategoryViewDto>(viewModel);
            }
        }
    }
}
