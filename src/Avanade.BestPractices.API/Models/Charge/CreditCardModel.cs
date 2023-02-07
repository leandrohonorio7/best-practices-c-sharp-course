using System;

namespace Avanade.BestPractices.API.Models.Charge
{
    public class CreditCardModel
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Brand { get; set; }
        public string VerificationCode { get; set; }
        public DateTime DueDate { get; set; }
    }
}
