using System;
using System.ComponentModel.DataAnnotations;

namespace Avanade.BestPractices.API.Models.Ride
{
    public class StartRideRequest
    {
        [Required]
        public Guid VehicleId { get; set; }

        [Required]
        public Guid AccountId { get; set; }
    }
}
