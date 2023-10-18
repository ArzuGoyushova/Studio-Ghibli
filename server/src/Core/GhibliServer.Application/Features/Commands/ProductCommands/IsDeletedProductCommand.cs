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
    public class IsDeletedProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid ProductId { get; set; }
    }
    public class IsDeletedProductCommandHandler : IRequestHandler<IsDeletedProductCommand, ServiceResponse<Guid>>
    {
        private readonly IProductRepository _productRepository;

        public IsDeletedProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(IsDeletedProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.IsDeletedAsync(request.ProductId);

            return new ServiceResponse<Guid>(request.ProductId);
        }
    }
}
