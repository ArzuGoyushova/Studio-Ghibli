using GhibliServer.Application.Features.Commands.ProductCommands;
using GhibliServer.Application.Features.Queries.ProductQueries;
using GhibliServer.Application.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GhibliServer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
            var response = await _mediator.Send(query);
            return Ok(response.Value);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery { Id = id };
            var response = await _mediator.Send(query);

            if (response.Value == null)
            {
                return NotFound();
            }

            return Ok(response.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] UpdateProductCommand command)
        {
            if (id != command.ProId)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand { ProductId = id };
            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> IsDeleted(Guid id)
        {
            var command = new IsDeletedProductCommand { ProductId = id };
            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }

    }
}
