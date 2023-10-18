namespace GhibliServer.WebAPI.Services.Interfaces
{
    public interface IOrderService
    {
        void Send(string to, string subject, string body, byte[] attachmentData);
    }
}
