using AutoMapper;
using GhibliServer.Application.Dtos.Color;
using GhibliServer.Application.Dtos.Size;
using GhibliServer.Application.Features.Queries.ColorQueries;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.SizeQueries
{
    public class GetSizeByIdQuery : IRequest<ServiceResponse<SizeViewDto>>
    {
        public Guid Id { get; set; }
        public class GetSizeByIdQueryHandler : IRequestHandler<GetSizeByIdQuery, ServiceResponse<SizeViewDto>>
        {
            private readonly ISizeRepository _sizeRepository;
            private readonly IMapper _mapper;
            public GetSizeByIdQueryHandler(ISizeRepository sizeRepository, IMapper mapper)
            {
                _sizeRepository = sizeRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<SizeViewDto>> Handle(GetSizeByIdQuery request, CancellationToken cancellationToken)
            {
                var size = await _sizeRepository.GetItemByIdAsync(request.Id);

                var viewModel = _mapper.Map<SizeViewDto>(size);

                return new ServiceResponse<SizeViewDto>(viewModel);
            }
        }
    }
}
