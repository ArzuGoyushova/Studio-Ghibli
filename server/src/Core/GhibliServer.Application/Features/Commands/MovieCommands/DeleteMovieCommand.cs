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
    public class DeleteMovieCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid MovieId { get; set; }
    }
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, ServiceResponse<Guid>>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var existingMovie = await _movieRepository.GetItemByIdAsync(request.MovieId);

            if (existingMovie == null)
            {
                return null;
            }

            await _movieRepository.DeleteAsync(request.MovieId);

            return new ServiceResponse<Guid>(request.MovieId);
        }
    }
}
