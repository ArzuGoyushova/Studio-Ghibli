using GhibliServer.Application.Features.Commands.AccountCommands;
using GhibliServer.Application.Features.Commands.SizeCommands;
using GhibliServer.Application.Features.Commands.UserCommands;
using GhibliServer.Application.Features.Queries.ProductQueries;
using GhibliServer.Application.Features.Queries.SizeQueries;
using GhibliServer.Application.Features.Queries.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GhibliServer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();
            var response = await _mediator.Send(query);
            return Ok(response.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeRoles(Guid id, ChangeRolesCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }

        [HttpPut("block/{id}")]
        public async Task<IActionResult> ToggleIsBlocked(Guid id, ToggleIsBlockedCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var response = await _mediator.Send(query);

            if (response.Value == null)
            {
                return NotFound();
            }

            return Ok(response.Value);
        }
    }
}
