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
    public class GetAllColorsQuery : IRequest<ServiceResponse<List<ColorViewDto>>>
    {
        public class GetAllColorsQueryHandler : IRequestHandler<GetAllColorsQuery, ServiceResponse<List<ColorViewDto>>>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;
            public GetAllColorsQueryHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<List<ColorViewDto>>> Handle(GetAllColorsQuery request, CancellationToken cancellationToken)
            {
                var colors = await _colorRepository.GetAllItemsAsync();

                var viewModel = _mapper.Map<List<ColorViewDto>>(colors);

                return new ServiceResponse<List<ColorViewDto>>(viewModel);
            }
        }
    }
}
