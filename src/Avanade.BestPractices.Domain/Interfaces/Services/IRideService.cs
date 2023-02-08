using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Infrestructure.Core.Entities.Interfaces;
using System;
using System.Threading.Tasks;

namespace Avanade.BestPractices.Domain.Interfaces.Services
{
    public interface IRideService : IService<Ride>
    {
        Task<Ride> StartAsync(Guid vehicleId, Guid accountId);

        Task FinishAsync(Guid rideId);

        Task<Ride> GetCurrentAsync(Guid accountId);

        Task<Ride> GetByIdAsync(Guid id);
    }
}
