using Avanade.BestPractices.Infrestructure.Core.Payments;
using Avanade.BestPractices.Infrestructure.Core.Payments.Models;
using Avanade.BestPractices.Infrestructure.Core.Payments.Requests;
using Avanade.BestPractices.Infrestructure.Core.Payments.Responses;
using System.Threading.Tasks;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.PayPal
{
    public class PaymentProvider : IPaymentProvider
    {
        private readonly PayPal _payPal;

        public PaymentProvider(PayPal payPal)
        {
            _payPal = payPal;
        }

        public async Task<GenerateCreditCardTokenResponse> GenerateCreditCardTokenAsync(GenerateCreditCardTokenRequest request)
        {
            var response = await _payPal.GenerateTokenAsync();

            return await Task.FromResult(new GenerateCreditCardTokenResponse
            {
                Token = response,
                Provider = PaymentProviderName.PayPal
            });
        }

        public async Task<PaymentResponse> MakePaymentAsync<T>(PaymentRequest<T> payment) where T : class
        {
            if (payment.Data is CreditCard)
            {
                var response = await _payPal.MakeCreditCardPaymentAsync();

                return new PaymentResponse
                {
                    ConfirmDate = response.ConfirmDate,
                    Hash = response.Hash,
                    Provider = PaymentProviderName.PayPal,
                    Status = GetPaymentStatus(response.Status)
                };
            }

            //Bank Slip

            //Debit card

            return default;
        }

        private PaymentStatus GetPaymentStatus(string status)
        {
            return status switch
            {
                "Approved" => PaymentStatus.Approved,
                "Declined" => PaymentStatus.Denied,
                _ => PaymentStatus.Unknown,
            };
        }
    }
}
