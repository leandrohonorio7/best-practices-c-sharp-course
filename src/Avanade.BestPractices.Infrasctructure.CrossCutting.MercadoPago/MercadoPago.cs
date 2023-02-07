using Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago.Models;
using System;
using System.Threading.Tasks;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago
{
    public class MercadoPago
    {
        public Task<string> GenerateTokenAsync(GenerateToken token)
        {
            var generatedToken = Guid.NewGuid().ToString();
            Console.WriteLine($"Gerou o token no mercado pago: {generatedToken}");
            return Task.FromResult(generatedToken);
        }

        public Task<MercadoPagoPaymentResponse> MakeCreditCardPaymentAsync(Payment payment)
        {
            var response = new MercadoPagoPaymentResponse
            {
                ConfirmDate = DateTime.Now,
                Hash = Guid.NewGuid().ToString(),
                Status = MercadoPagoStatus.Approved
            };

            Console.WriteLine($"Gerou o pagamento com o valor de : {payment.Total}");
            return Task.FromResult(response);
        }
    }
}
