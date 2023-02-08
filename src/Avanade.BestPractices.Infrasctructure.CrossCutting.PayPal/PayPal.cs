using Avanade.BestPractices.Infrasctructure.CrossCutting.PayPal.Models;
using System;
using System.Threading.Tasks;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.PayPal
{
    public class PayPal
    {
        public Task<string> GenerateTokenAsync()
        {
            var generatedToken = Guid.NewGuid().ToString();
            Console.WriteLine($"Gerou o token no PayPal: {generatedToken}");
            return Task.FromResult(generatedToken);
        }

        public Task<PayPalPaymentResponse> MakeCreditCardPaymentAsync()
        {
            var response = new PayPalPaymentResponse
            {
                ConfirmDate = DateTime.Now,
                Hash = Guid.NewGuid().ToString(),
                Status = "Approved"
            };

            Console.WriteLine($"Gerou o pagamento com o PayPal");
            return Task.FromResult(response);
        }
    }
}
