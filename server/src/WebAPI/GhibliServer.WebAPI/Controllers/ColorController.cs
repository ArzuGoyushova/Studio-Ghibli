using GhibliServer.Application.Features.Commands.ColorCommands;
using GhibliServer.Application.Features.Queries.ColorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GhibliServer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ColorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllColorsQuery();
            var response = await _mediator.Send(query);
            return Ok(response.Value);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetColorByIdQuery { Id = id };
            var response = await _mediator.Send(query);

            if (response.Value == null)
            {
                return NotFound();
            }

            return Ok(response.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateColorCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateColorCommand command)
        {
            if (id != command.ColorId)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteColorCommand { ColorId = id };
            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }
    }
}
