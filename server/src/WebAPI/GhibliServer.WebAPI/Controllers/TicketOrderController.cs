using GhibliServer.Application.Dtos.Basket;
using GhibliServer.Application.Features.Commands.SizeCommands;
using GhibliServer.Application.Features.Commands.TicketCommands;
using GhibliServer.Application.Features.Commands.TicketOrderCommands;
using GhibliServer.Application.Features.Queries.TicketQueries;
using GhibliServer.Domain.Helper;
using GhibliServer.WebAPI.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Stripe;
using System;
using System.Threading.Tasks;

namespace GhibliServer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketOrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IStripeService _stripeService;

        public TicketOrderController(IMediator mediator, IStripeService stripeService)
        {
            _mediator = mediator;
            _stripeService = stripeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllTicketOrdersQuery();
            var response = await _mediator.Send(query);
            return Ok(response.Value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketOrderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(new
            {
                TicketOrderId = response.Value
            });
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetTicketOrderByIdBasketQuery { Id = id };
            var response = await _mediator.Send(query);

            if (response.Value == null)
            {
                return NotFound();
            }

            return Ok(response.Value);
        }

        [HttpGet("admin/{id}")]
        public async Task<IActionResult> GetByIdAdmin(Guid id)
        {
            var query = new GetTicketOrderByIdAdminQuery { Id = id };
            var response = await _mediator.Send(query);

            if (response.Value == null)
            {
                return NotFound();
            }

            return Ok(response.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdatePaymentStatusAdminCommand command)
        {
            if (id != command.TicketOrderId)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTicketOrderCommand { TicketOrderId = id };
            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }


        [HttpPost("verify-payment")]
        public async Task<IActionResult> VerifyPayment(VerifyPaymentRequestDto requestDto)
        {
            var query = new GetTicketOrderByIdBasketQuery { Id = requestDto.TicketOrderId };
            var response = await _mediator.Send(query);

            if (response.Value == null)
            {
                return NotFound();
            }


            var (paymentIntentId, clientSecret) = await _stripeService.CreatePaymentIntent(
     response.Value.TicketOrderId,
     response.Value.TotalPrice,
     "usd",
     requestDto.PaymentMethodId
 );

            if (string.IsNullOrEmpty(clientSecret))
            {
                return BadRequest(new { Message = "Failed to create payment intent." });
            }

            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.GetAsync(paymentIntentId);

            var updateCommand = new UpdatePaymentStatusCommand
            {
                OrderId = response.Value.TicketOrderId,
                PaymentStatus = paymentIntent.Status == "succeeded" ? PaymentStatus.Completed : PaymentStatus.Failed
            };

            await _mediator.Send(updateCommand);


            if (string.IsNullOrEmpty(clientSecret))
            {
                return BadRequest(new { Message = "Failed to create payment intent." });
            }
            return Ok(new { ClientSecret = clientSecret });
        }

    }
}
