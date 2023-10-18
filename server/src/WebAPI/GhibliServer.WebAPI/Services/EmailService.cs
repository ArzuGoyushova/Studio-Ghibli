using MimeKit.Text;
using MimeKit;
using GhibliServer.WebAPI.Services.Interfaces;
using MailKit.Net.Smtp;

namespace GhibliServer.WebAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration; 

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Send(string to, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Smtp:FromAddress").Value)); 
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body }; 


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
