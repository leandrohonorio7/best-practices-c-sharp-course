using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Infrestructure.Core.Entities.Interfaces;
using System;
using System.Threading.Tasks;

namespace Avanade.BestPractices.Domain.Interfaces.Services
{
    public interface IVehicleService : IService<Vehicle>
    {
        Task<Vehicle> GetByIdAsync(Guid id);

        Task SetIsAvailableAsync(Guid vehicleId, bool isAvailable);
    }
}
