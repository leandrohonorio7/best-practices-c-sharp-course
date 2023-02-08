using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Infrestructure.Core.Entities.Interfaces;
using System.Threading.Tasks;
using System;

namespace Avanade.BestPractices.Domain.Interfaces.Repositories
{
    public interface IRideRepository : IRepository<Ride>
    {
        Task<Ride> GetCurrentAsync(Guid accountId);
    }
}
