using AutoMapper;
using GhibliServer.Application.Dtos.Size;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.SizeCommands
{
    public class UpdateSizeCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid SizeId { get; set; }
        public SizeCreateOrUpdateDto SizeDTO { get; set; }
    }

    public class UpdateSizeCommandHandler : IRequestHandler<UpdateSizeCommand, ServiceResponse<Guid>>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public UpdateSizeCommandHandler(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateSizeCommand request, CancellationToken cancellationToken)
        {
            var existingSize = await _sizeRepository.GetItemByIdAsync(request.SizeId);

            if (existingSize == null)
            {
                return null;
            }

            _mapper.Map(request.SizeDTO, existingSize);

            await _sizeRepository.UpdateAsync(existingSize.Id, existingSize);

            return new ServiceResponse<Guid>(existingSize.Id);
        }
    }
}
