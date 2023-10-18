using GhibliServer.WebAPI.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace GhibliServer.WebAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IConfiguration _configuration;

        public OrderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Send(string to, string subject, string body, byte[] attachmentData)
        {

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Smtp:FromAddress").Value));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;

            var attachment = new MimePart("application", "pdf")
            {
                Content = new MimeContent(new MemoryStream(attachmentData)),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = "ticket.pdf"
            };

            bodyBuilder.Attachments.Add(attachment);

            email.Body = bodyBuilder.ToMessageBody();

            using SmtpClient smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("Smtp:Server").Value,
                int.Parse(_configuration.GetSection("Smtp:Port").Value),
                MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("Smtp:FromAddress").Value,
                _configuration.GetSection("Smtp:Password").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
