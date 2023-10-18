using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.AccountCommands
{
    public class DeleteMovieFromWatchlistCommand : IRequest<ServiceResponse<Guid>>
    {
        public string UserId { get; set; }
        public Guid MovieId { get; set; }
    }

    public class DeleteMovieFromWatchlistCommandHandler : IRequestHandler<DeleteMovieFromWatchlistCommand, ServiceResponse<Guid>>
    {
        private readonly IUserMovieRepository _userMovieRepository;

        public DeleteMovieFromWatchlistCommandHandler(IUserMovieRepository userMovieRepository)
        {
            _userMovieRepository = userMovieRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteMovieFromWatchlistCommand request, CancellationToken cancellationToken)
        {
            var userMovies = await _userMovieRepository.GetAllItemsAsync();

                var userMovie = userMovies.Find(um=>um.AppUserId==request.UserId && um.MovieId==request.MovieId);
                if (userMovie == null)
                {
                    return null;
                }

                userMovies.Remove(userMovie);
                await _userMovieRepository.DeleteAsync(userMovie.Id);
                return new ServiceResponse<Guid>(userMovie.Id);
            
            
        }
    }

}
