namespace Avanade.BestPractices.Infrestructure.Core.Payments.Models
{
    public enum PaymentStatus
    {
        Unknown,
        AwaitingPayment,
        PreApproved,
        Approved,
        Canceled,
        Expired,
        Denied,
        InAnalysis,
        Refunded,
        Contested,
        Protested
    }
}
