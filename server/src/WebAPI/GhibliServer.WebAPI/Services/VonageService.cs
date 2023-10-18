using Vonage;
using GhibliServer.Domain.Entities;
using Microsoft.Extensions.Options;
using GhibliServer.WebAPI.Services.Interfaces;
using Vonage.Verify;
using GhibliServer.WebAPI.Controllers;
using Microsoft.Extensions.Caching.Memory;

namespace GhibliServer.WebAPI.Services
{
    public class VonageService : IVonageService
    {
        private readonly VonageClient _vonageClient;
        private readonly IMemoryCache _cache;

        public VonageService(VonageClient vonageClient, IMemoryCache cache)
        {
            _vonageClient = vonageClient;
            _cache = cache;
        }

        public async Task<bool> SendVerificationCode(string phoneNumber)
        {
            try
            {
                var response = await _vonageClient.VerifyClient.VerifyRequestAsync(new VerifyRequest
                {
                    Number = phoneNumber,
                    Brand = "Ghibli Studios",
                    CodeLength = 4
                });
                _cache.Set($"RequestId_{phoneNumber}", response.RequestId, TimeSpan.FromMinutes(10));

                return response.Status == "0" && !string.IsNullOrEmpty(response.RequestId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string GetRequestId(string phoneNumber)
        {
            if (_cache.TryGetValue($"RequestId_{phoneNumber}", out string requestId))
            {
                return requestId;
            }
            return null;
        }
    }
   
}
