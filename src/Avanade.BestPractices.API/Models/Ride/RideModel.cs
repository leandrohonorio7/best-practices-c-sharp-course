using Avanade.BestPractices.Domain.Entities;
using System;

namespace Avanade.BestPractices.API.Models.Ride
{
    public class RideModel
    {
        public Guid Id { get; set; }

        public DateTime StartAt { get; set; }

        public Guid AccountId { get; set; }

        public Guid VehicleId { get; set; }

        public string VehiclePlate { get; set; }
        public string VehicleYear { get; set; }
        public string VehicleColor { get; set; }

        public string VehicleModelVersionName { get; set; }
    }
}
