using AutoMapper;
using GhibliServer.Application.Dtos.Product;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.ProductQueries
{
    public class GetProductByIdQuery : IRequest<ServiceResponse<ProductViewDto>>
    {
        public Guid Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<ProductViewDto>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<ProductViewDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetItemByIdWithIncludesAsync(
                    request.Id,
                    p=>p.Pictures,
                    p=>p.ProductSizes,
                    p=>p.ProductColors,
                    p=>p.Category
                    ); 

                var viewModel = _mapper.Map<ProductViewDto>(product);

                return new ServiceResponse<ProductViewDto>(viewModel);
            }
        }
    }
}
