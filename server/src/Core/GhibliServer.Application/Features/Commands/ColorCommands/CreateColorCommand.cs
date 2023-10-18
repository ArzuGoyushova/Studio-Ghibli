using AutoMapper;
using GhibliServer.Application.Dtos.Color;
using GhibliServer.Application.Features.Commands.ProductCommands;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.ColorCommands
{
    public class CreateColorCommand : IRequest<ServiceResponse<Guid>>
    {
        public ColorCreateOrUpdateDto ColorDTO { get; set; }
    }

    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, ServiceResponse<Guid>>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public CreateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            var color = _mapper.Map<Color>(request.ColorDTO);

            await _colorRepository.CreateAsync(color);

            return new ServiceResponse<Guid>(color.Id);
        }

    }
}
