using Avanade.BestPractices.Domain.Entities.Enums;
using Avanade.BestPractices.Domain.ValueObjects;
using Avanade.BestPractices.Infrestructure.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avanade.BestPractices.Domain.Entities
{
    public class Ride : EntityBase
    {
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public DateTime StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public int Distance { get; set; }
        public Money Total
        {
            get
            {
                var currency = Charges.FirstOrDefault()?.GrossValue?.Currency;
                var allowedStatus = new[] 
                { 
                    ChargeStatus.Paid,
                    ChargeStatus.Created
                };

                return new Money
                {
                    Currency = currency,
                    Value = Charges
                        .Where(x => allowedStatus.Contains(x.Status))
                        .Sum(x => x.NetValue.Value)
                };
            }
        }

        public List<Charge> Charges { get; set; }
    }
}
