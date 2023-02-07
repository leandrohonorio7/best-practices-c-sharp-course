using Avanade.BestPractices.Infrestructure.Core.Payments.Models;

namespace Avanade.BestPractices.Infrestructure.Core.Payments.Requests
{
    public class GenerateCreditCardTokenRequest
    {
        public CreditCard CreditCard { get; set; }
    }
}
