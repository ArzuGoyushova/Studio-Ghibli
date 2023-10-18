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

namespace GhibliServer.Application.Features.Queries.ColorQueries
{
    public class GetColorByIdQuery : IRequest<ServiceResponse<ColorViewDto>>
    {
        public Guid Id { get; set; }
        public class GetColorByIdQueryHandler : IRequestHandler<GetColorByIdQuery, ServiceResponse<ColorViewDto>>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;
            public GetColorByIdQueryHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<ColorViewDto>> Handle(GetColorByIdQuery request, CancellationToken cancellationToken)
            {
                var color = await _colorRepository.GetItemByIdAsync(request.Id);

                var viewModel = _mapper.Map<ColorViewDto>(color);

                return new ServiceResponse<ColorViewDto>(viewModel);
            }
        }
    
    }
}
