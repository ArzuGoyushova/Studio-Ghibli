using AutoMapper;
using GhibliServer.Application.Dtos.Category;
using GhibliServer.Application.Dtos.Color;
using GhibliServer.Application.Features.Queries.ColorQueries;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.CategoryQueries
{
    public class GetAllCategoriesQuery : IRequest<ServiceResponse<List<CategoryViewDto>>>
    {
        public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, ServiceResponse<List<CategoryViewDto>>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<List<CategoryViewDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var Categories = await _categoryRepository.GetAllItemsWithIncludesAsync(
    c => c.Products,
    c => c.Blogs,
    c => c.Movies
);

                var viewModel = _mapper.Map<List<CategoryViewDto>>(Categories);

                return new ServiceResponse<List<CategoryViewDto>>(viewModel);
            }
        }
    }
}
