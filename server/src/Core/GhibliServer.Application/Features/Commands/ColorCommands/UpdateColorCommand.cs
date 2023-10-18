using AutoMapper;
using GhibliServer.Application.Dtos.Color;
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
    public class UpdateColorCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid ColorId { get; set; }
        public ColorCreateOrUpdateDto ColorDTO { get; set; }
    }

    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, ServiceResponse<Guid>>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public UpdateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            var existingColor = await _colorRepository.GetItemByIdAsync(request.ColorId);

            if (existingColor == null)
            {
                return null;
            }

            _mapper.Map(request.ColorDTO, existingColor);

            await _colorRepository.UpdateAsync(existingColor.Id, existingColor);

            return new ServiceResponse<Guid>(existingColor.Id);
        }
    }

}
