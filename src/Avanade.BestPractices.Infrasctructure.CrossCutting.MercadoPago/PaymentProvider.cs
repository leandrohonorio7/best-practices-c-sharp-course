using AutoMapper;
using Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago.Models;
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
        private readonly IMapper _mapper;

        public PaymentProvider(MercadoPago mercadoPago,
            IMapper mapper)
        {
            _mercadoPago = mercadoPago;
            _mapper = mapper;
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
                Provider = PaymentProviderName.MercadoPago
            });
        }

        public async Task<PaymentResponse> MakePaymentAsync<T>(PaymentRequest<T> payment) where T : class
        {
            if (payment.Data is CreditCard)
            {
                var mercadoPagoPaymentRequest = _mapper.Map<PaymentRequest<CreditCard>, Payment>(payment as PaymentRequest<CreditCard>);
                var mercadoPagoPaymentResponse = await _mercadoPago.MakeCreditCardPaymentAsync(mercadoPagoPaymentRequest);
                var paymentResponse = _mapper.Map<MercadoPagoPaymentResponse, PaymentResponse>(mercadoPagoPaymentResponse);
                return paymentResponse;
            }

            //Bank Slip

            //Debit card

            return default;
        }
    }
}
