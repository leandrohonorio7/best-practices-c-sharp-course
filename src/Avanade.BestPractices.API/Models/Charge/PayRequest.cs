namespace Avanade.BestPractices.API.Models.Charge
{
    public class PayRequest
    {
        public CreditCardModel CreditCard { get; set; }
        public string PaymentProvider { get; set; }
    }
}
