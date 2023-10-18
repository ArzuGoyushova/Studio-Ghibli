using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.ColorCommands
{
    public class DeleteColorCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid ColorId { get; set; }
    }

    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, ServiceResponse<Guid>>
    {
        private readonly IColorRepository _colorRepository;

        public DeleteColorCommandHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            var existingColor = await _colorRepository.GetItemByIdAsync(request.ColorId);

            if (existingColor == null)
            {
                return null;
            }

            await _colorRepository.DeleteAsync(existingColor.Id);

            return new ServiceResponse<Guid>(existingColor.Id);
        }
    }

}
