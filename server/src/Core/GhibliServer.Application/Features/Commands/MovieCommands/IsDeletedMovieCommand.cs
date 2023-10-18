using GhibliServer.Application.Features.Commands.ProductCommands;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.MovieCommands
{
    public class IsDeletedMovieCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid MovieId { get; set; }
    }
    public class IsDeletedMovieCommandHandler : IRequestHandler<IsDeletedMovieCommand, ServiceResponse<Guid>>
    {
        private readonly IMovieRepository _movieRepository;

        public IsDeletedMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(IsDeletedMovieCommand request, CancellationToken cancellationToken)
        {
            await _movieRepository.IsDeletedAsync(request.MovieId);

            return new ServiceResponse<Guid>(request.MovieId);
        }
    }
}
