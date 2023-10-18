using GhibliServer.WebAPI.Services.Interfaces;

namespace GhibliServer.WebAPI.Services
{
    public class FileService : IFileService
    {
        public string ReadFile(string path, string body)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                body = sr.ReadToEnd();
            }
            return body;
        }
    }
}
