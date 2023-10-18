using AutoMapper;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.ProductCommands
{
    public class DeleteProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid ProductId { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ServiceResponse<Guid>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetItemByIdAsync(request.ProductId);

            if (existingProduct == null)
            {
                return null; 
            }

            await _productRepository.DeleteAsync(request.ProductId);

            return new ServiceResponse<Guid>(request.ProductId);
        }
    }

}
