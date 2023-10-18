using GhibliServer.Application.Features.Commands.AccountCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GhibliServer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserMovieController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpDelete("remove-movie")]
        public async Task<IActionResult> RemoveMovieFromWatchlist([FromQuery] Guid movieId, string userId)
        {
            var command = new DeleteMovieFromWatchlistCommand
            {
                UserId = userId,
                MovieId = movieId
            };

            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }

    }
}
