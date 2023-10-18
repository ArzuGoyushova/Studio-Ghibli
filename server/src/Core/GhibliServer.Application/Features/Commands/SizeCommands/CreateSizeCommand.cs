using AutoMapper;
using GhibliServer.Application.Dtos.Size;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.SizeCommands
{
    public class CreateSizeCommand : IRequest<ServiceResponse<Guid>>
    {
        public SizeCreateOrUpdateDto SizeDTO { get; set; }
    }

    public class CreateSizeCommandHandler : IRequestHandler<CreateSizeCommand, ServiceResponse<Guid>>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public CreateSizeCommandHandler(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateSizeCommand request, CancellationToken cancellationToken)
        {
            var size = _mapper.Map<Size>(request.SizeDTO);

            await _sizeRepository.CreateAsync(size);

            return new ServiceResponse<Guid>(size.Id);
        }

    }
}
