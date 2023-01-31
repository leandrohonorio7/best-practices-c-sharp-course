using Avanade.BestPractices.Infrestructure.Core.Entities;
using System;

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
    }
}
