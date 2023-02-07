using Avanade.BestPractices.Infrestructure.Core.Payments.Requests;
using Avanade.BestPractices.Infrestructure.Core.Payments.Responses;
using System.Threading.Tasks;

namespace Avanade.BestPractices.Infrestructure.Core.Payments
{
    public interface IPaymentProvider
    {
        Task<GenerateCreditCardTokenResponse> GenerateCreditCardTokenAsync(GenerateCreditCardTokenRequest request);
        Task<PaymentResponse> MakePaymentAsync<T>(PaymentRequest<T> payment) where T: class;
    }
}
