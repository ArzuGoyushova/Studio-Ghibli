using AutoMapper;
using GhibliServer.Application.Dtos.Product;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Profiles;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.ProductCommands
{
    public class UpdateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid ProId { get; set; }
        public ProductCreateOrUpdateDto ProductDTO { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ServiceResponse<Guid>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetItemByIdWithIncludesAsync(
                request.ProId,
                p=>p.ProductColors,
                p=>p.ProductSizes);

            if (existingProduct == null)
            {
                return null;
            }

            var updatedPictures = MapProfile.MapPictures(request.ProductDTO.NewPictures, "products");
            existingProduct.Pictures.AddRange(updatedPictures);

            var hasMainPicture = existingProduct.Pictures.Any(p => p.isMain);
            if (!hasMainPicture && existingProduct.Pictures.Count > 0)
            {
                existingProduct.Pictures[0].isMain = true;
            }

            _mapper.Map(request.ProductDTO, existingProduct);

            await _productRepository.UpdateAsync(existingProduct.Id, existingProduct);

            return new ServiceResponse<Guid>(existingProduct.Id);
        }
    }
}
