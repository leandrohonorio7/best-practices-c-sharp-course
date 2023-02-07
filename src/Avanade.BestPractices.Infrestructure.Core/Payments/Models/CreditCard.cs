using System;

namespace Avanade.BestPractices.Infrestructure.Core.Payments.Models
{
    public class CreditCard
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Brand { get; set; }
        public string VerificationCode { get; set; }
        public DateTime DueDate { get; set; }
    }
}
