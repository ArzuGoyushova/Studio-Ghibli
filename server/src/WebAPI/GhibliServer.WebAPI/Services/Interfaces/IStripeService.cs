using Stripe;

namespace GhibliServer.WebAPI.Services.Interfaces
{
    public interface IStripeService
    {
        Task<(string PaymentIntentId, string ClientSecret)> CreatePaymentIntent(Guid orderId, double amount, string currency, string paymentMethodId);
    }
}
