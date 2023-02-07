using System;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago.Models
{
    public class Payment
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string VerificationCode { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Total { get; set; }
    }
}
