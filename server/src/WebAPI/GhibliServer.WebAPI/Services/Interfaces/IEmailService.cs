namespace GhibliServer.WebAPI.Services.Interfaces
{
    public interface IEmailService
    {
        void Send(string to, string subject, string body);
    }
}
