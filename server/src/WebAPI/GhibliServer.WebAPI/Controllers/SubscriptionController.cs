using GhibliServer.Application.Dtos.Subscription;
using GhibliServer.Application.Dtos.Ticket;
using GhibliServer.Application.Features.Commands.SubscriptionCommands;
using GhibliServer.Application.Features.Queries.SubscriptionQueries;
using GhibliServer.WebAPI.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace GhibliServer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        public SubscriptionController(IMediator mediator, IEmailService emailService, IConfiguration configuration)
        {
            _mediator = mediator;
            _emailService = emailService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSubscriptionsQuery();
            var response = await _mediator.Send(query);
            return Ok(response.Value);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetSubscriptionByIdQuery { Id = id };
            var response = await _mediator.Send(query);

            if (response.Value == null)
            {
                return NotFound();
            }

            return Ok(response.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscriptionCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteSubscriptionCommand { SubscriptionId = id };
            var response = await _mediator.Send(command);
            return Ok(response.Value);
        }

        [HttpPost("send-subscription-message")]
        public IActionResult SendSubscriptionMessage(SubscriptionMessageDto request)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Smtp:FromAddress").Value));
                email.Subject = request.Subject;
                email.To.Add(MailboxAddress.Parse(request.To));


                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = request.Body;


                email.Body = bodyBuilder.ToMessageBody();

                _emailService.Send(request.To, request.Subject, request.Body);

                return Ok(new { message = "Message sent successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred" });
            }
        }
    }
}