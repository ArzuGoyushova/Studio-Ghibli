using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;

namespace GhibliServer.Application.Features.Commands.SizeCommands
{
    public class DeleteSizeCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid SizeId { get; set; }
    }

    public class DeleteSizeCommandHandler : IRequestHandler<DeleteSizeCommand, ServiceResponse<Guid>>
    {
        private readonly ISizeRepository _sizeRepository;

        public DeleteSizeCommandHandler(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteSizeCommand request, CancellationToken cancellationToken)
        {
            var existingSize = await _sizeRepository.GetItemByIdAsync(request.SizeId);

            if (existingSize == null)
            {
                return null;
            }

            await _sizeRepository.DeleteAsync(existingSize.Id);

            return new ServiceResponse<Guid>(existingSize.Id);
        }
    }
}
