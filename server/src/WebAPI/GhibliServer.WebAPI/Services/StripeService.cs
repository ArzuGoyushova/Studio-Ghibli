using GhibliServer.Domain.Entities;
using GhibliServer.WebAPI.Services.Interfaces;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;

namespace GhibliServer.WebAPI.Services
{
    public class StripeService : IStripeService
    {
        private readonly StripeSettings _stripeSettings;

        public StripeService(IOptions<StripeSettings> stripeSettings)
        {
            _stripeSettings = stripeSettings.Value;
        }

        public async Task<(string PaymentIntentId, string ClientSecret)> CreatePaymentIntent(Guid orderId, double amount, string currency, string paymentMethodId)
        {
            var paymentIntentService = new PaymentIntentService();
            var options = new PaymentIntentCreateOptions
            {
                PaymentMethod = paymentMethodId,
                Amount = (long)(amount * 100),
                Currency = currency,
                PaymentMethodTypes = new List<string> { "card" },
                Metadata = new Dictionary<string, string>
        {
            { "OrderId", orderId.ToString() }
        },
                Confirm = true,
                OffSession = true,
            };
            var paymentIntent = await paymentIntentService.CreateAsync(options);

            return (paymentIntent.Id, paymentIntent.ClientSecret);
        }
    }

}

