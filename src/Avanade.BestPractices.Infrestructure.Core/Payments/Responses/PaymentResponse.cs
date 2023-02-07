using System;
using Avanade.BestPractices.Infrestructure.Core.Payments.Models;

namespace Avanade.BestPractices.Infrestructure.Core.Payments.Responses
{
    public class PaymentResponse
    {
        public string Hash { get; set; }
        public PaymentStatus Status { get; set; }
        public string Provider { get; set; }
        public DateTime ConfirmDate { get; set; }
    }
}
