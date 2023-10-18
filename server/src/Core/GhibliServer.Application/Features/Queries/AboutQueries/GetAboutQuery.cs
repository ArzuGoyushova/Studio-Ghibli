using AutoMapper;
using GhibliServer.Application.Dtos.About;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Queries.AboutQueries
{
    public class GetAboutQuery : IRequest<ServiceResponse<List<AboutViewDto>>>
    {
        public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, ServiceResponse<List<AboutViewDto>>>
        {
            private readonly IAboutRepository _aboutRepository;
            private readonly IMapper _mapper;
            public GetAboutQueryHandler(IAboutRepository aboutRepository, IMapper mapper)
            {
                _aboutRepository = aboutRepository;
                _mapper = mapper;
            }
            public async Task<ServiceResponse<List<AboutViewDto>>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
            {
                var about = await _aboutRepository.GetAllItemsAsync();

                var viewModel = _mapper.Map<List<AboutViewDto>>(about);

                return new ServiceResponse<List<AboutViewDto>>(viewModel);
            }
        }
    }
}
