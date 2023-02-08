using System;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.PayPal.Models
{
    public class PayPalPaymentResponse
    {
        public string Hash { get; set; }
        public string Status { get; set; }
        public DateTime ConfirmDate { get; set; }
    }
}
