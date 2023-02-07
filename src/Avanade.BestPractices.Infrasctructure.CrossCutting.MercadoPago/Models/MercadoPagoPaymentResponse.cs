using System;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago.Models
{
    public class MercadoPagoPaymentResponse
    {
        public string Hash { get; set; }
        public string Status { get; set; }
        public DateTime ConfirmDate { get; set; }
    }
}
