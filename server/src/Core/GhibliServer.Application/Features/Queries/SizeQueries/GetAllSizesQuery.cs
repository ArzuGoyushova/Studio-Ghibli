using AutoMapper;
using GhibliServer.Application.Dtos.Color;
using GhibliServer.Application.Dtos.Size;
using GhibliServer.Application.Features.Queries.ColorQueries;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;

namespace GhibliServer.Application.Features.Queries.SizeQueries
{
    public class GetAllSizesQuery : IRequest<ServiceResponse<List<SizeViewDto>>>
    {
        public class GetAllSizesQueryHandler : IRequestHandler<GetAllSizesQuery, ServiceResponse<List<SizeViewDto>>>
        {
            private readonly ISizeRepository _sizeRepository;
            private readonly IMapper _mapper;
            public GetAllSizesQueryHandler(ISizeRepository sizeRepository, IMapper mapper)
            {
                _sizeRepository = sizeRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<List<SizeViewDto>>> Handle(GetAllSizesQuery request, CancellationToken cancellationToken)
            {
                var sizes = await _sizeRepository.GetAllItemsAsync();

                var viewModel = _mapper.Map<List<SizeViewDto>>(sizes);

                return new ServiceResponse<List<SizeViewDto>>(viewModel);
            }
        }
    }
}
