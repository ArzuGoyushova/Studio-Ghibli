using GhibliServer.Application.Dtos.Ticket;
using GhibliServer.Application.Features.Commands.SizeCommands;
using GhibliServer.Application.Features.Queries.SizeQueries;
using GhibliServer.Application.Features.Queries.TicketQueries;
using GhibliServer.WebAPI.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace GhibliServer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOrderService _orderService;
        private readonly IConfiguration _configuration;
        public TicketController(IMediator mediator, IOrderService orderService, IConfiguration configuration)
        {
            _mediator = mediator;
            _orderService = orderService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllTicketsQuery();
            var response = await _mediator.Send(query);
            return Ok(response.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetTicketByIdQuery { Id = id };
            var response = await _mediator.Send(query);

            if (response.Value == null)
            {
                return NotFound();
            }

            return Ok(response.Value);
        }


        [HttpPost("send-ticket-pdf")]
        public IActionResult SendTicketPdf([FromBody] TicketPdfEmailRequest request)
        {
            try
            {
                byte[] pdfData = Convert.FromBase64String(request.PdfDataUrl.Split(',')[1]);

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Smtp:FromAddress").Value));
                email.Subject = request.Subject;
                email.To.Add(MailboxAddress.Parse(request.To));
                

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = request.Body;

                var attachment = new MimePart("application", "pdf")
                {
                    Content = new MimeContent(new MemoryStream(pdfData)),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = "ticket.pdf"
                };

                bodyBuilder.Attachments.Add(attachment);

                email.Body = bodyBuilder.ToMessageBody();

                _orderService.Send(request.To, request.Subject, request.Body, pdfData);

                return Ok(new { message = "Ticket sent successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred" });
            }
        }
    }
}
