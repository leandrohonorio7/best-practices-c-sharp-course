using System.Collections.Generic;
using System.Linq;
using Avanade.BestPractices.Infrestructure.Core.Payments.Models;

namespace Avanade.BestPractices.Infrestructure.Core.Payments.Requests
{
    public class PaymentRequest<T> where T : class
    {
        public string Currency { get; set; }
        public long Value => Items.Sum(x => x.Total);
        public string StoreReferenceId { get; set; }
        public List<PaymentItem> Items { get; set; }
        public T Data { get; set; }
    }
}
