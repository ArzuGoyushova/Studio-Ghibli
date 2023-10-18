using AutoMapper;
using GhibliServer.Application.Dtos.Product;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Profiles;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;

namespace GhibliServer.Application.Features.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public ProductCreateOrUpdateDto ProductDTO { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request.ProductDTO);

            var pictures = MapProfile.MapPictures(request.ProductDTO.NewPictures, "products");
            product.Pictures = pictures;

            if (product.Pictures.Count > 0)
            {
                product.Pictures[0].isMain = true;
            }

            await _productRepository.CreateAsync(product);

            return new ServiceResponse<Guid>(product.Id);
        }

    }

}
