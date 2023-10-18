using GhibliServer.Application.Features.Commands.RoleCommands;
using GhibliServer.Application.Features.Queries.RoleQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GhibliServer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllRolesQuery();
            var response = await _mediator.Send(query);
            return Ok(response.Value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteRoleCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }
    }
}
