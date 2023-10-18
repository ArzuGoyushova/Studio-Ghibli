using GhibliServer.Application.Features.Commands.ReviewCommands;
using GhibliServer.Application.Features.Queries.ReviewQueries;
using GhibliServer.Application.Features.Queries.SizeQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GhibliServer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllByMovieId(Guid movieId)
        {
            var query = new GetAllReviewsByMovieIdQuery { MovieId = movieId };
            var response = await _mediator.Send(query);

            if (response.Value == null)
            {
                return NotFound();
            }

            return Ok(response.Value);
        }
    }
}
