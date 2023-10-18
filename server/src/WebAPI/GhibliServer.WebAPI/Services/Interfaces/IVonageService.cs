namespace GhibliServer.WebAPI.Services.Interfaces
{
    public interface IVonageService
    {
        Task<bool> SendVerificationCode(string phoneNumber);
        string GetRequestId(string phoneNumber);
    }
}
