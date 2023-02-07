using Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago.Models;
using Avanade.BestPractices.Infrestructure.Core.Extensions;
using Avanade.BestPractices.Infrestructure.Core.Payments;
using Avanade.BestPractices.Infrestructure.Core.Payments.Models;
using Avanade.BestPractices.Infrestructure.Core.Payments.Requests;
using Avanade.BestPractices.Infrestructure.Core.Payments.Responses;
using System.Threading.Tasks;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago
{
    public class PaymentProvider : IPaymentProvider
    {
        private readonly MercadoPago _mercadoPago;

        public PaymentProvider(MercadoPago mercadoPago)
        {
            _mercadoPago = mercadoPago;
        }

        public async Task<GenerateCreditCardTokenResponse> GenerateCreditCardTokenAsync(GenerateCreditCardTokenRequest request)
        {
            var response = await _mercadoPago.GenerateTokenAsync(new Models.GenerateToken
            {
                DueDate = request.CreditCard.DueDate,
                Name = request.CreditCard.Name,
                Number = request.CreditCard.Number,
                Verification = request.CreditCard.VerificationCode
            });

            return await Task.FromResult(new GenerateCreditCardTokenResponse
            {
                Token = response,
                Provider = "MercadoPago"
            });
        }

        public async Task<PaymentResponse> MakePaymentAsync<T>(PaymentRequest<T> payment) where T : class
        {
            if (payment.Data is CreditCard)
            {
                var creditCard = payment.Data as CreditCard;
                var response = await _mercadoPago.MakeCreditCardPaymentAsync(new Models.Payment
                {
                    Brand = creditCard.Brand,
                    DueDate = creditCard.DueDate,
                    Name = creditCard.Name,
                    Number = creditCard.Number,
                    VerificationCode = creditCard.VerificationCode,
                    Total = payment.Value.ConvertToMoney()
                });

                return new PaymentResponse
                {
                    ConfirmDate = response.ConfirmDate,
                    Hash = response.Hash,
                    Provider = "MercadoPago",
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
                MercadoPagoStatus.Approved => PaymentStatus.Approved,
                MercadoPagoStatus.Declined => PaymentStatus.Denied,
                _ => PaymentStatus.Unknown,
            };
        }
    }
}
