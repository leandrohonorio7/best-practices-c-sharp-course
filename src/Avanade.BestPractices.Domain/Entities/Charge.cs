using Avanade.BestPractices.Domain.Entities.Enums;
using Avanade.BestPractices.Domain.ValueObjects;
using Avanade.BestPractices.Infrestructure.Core.Entities;
using System;

namespace Avanade.BestPractices.Domain.Entities
{
    public class Charge : EntityBase
    {
        public Guid RideId { get; set; }
        public Ride Ride { get; set; }

        public Money GrossValue { get; set; }
        public Money DiscountValue { get; set; }
        public Money NetValue { get; set; }
        public ChargeStatus Status { get; set; } = ChargeStatus.Created;
        public string Description { get; set; }

        public void CalculateNetValue()
        {
            if (DiscountValue == null)
                DiscountValue = new Money();

            NetValue = GrossValue - DiscountValue;
        }
    }
}
