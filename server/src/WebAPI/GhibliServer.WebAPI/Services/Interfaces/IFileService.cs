namespace GhibliServer.WebAPI.Services.Interfaces
{
    public interface IFileService
    {
        string ReadFile(string path, string body);
    }
}
