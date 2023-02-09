using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Domain.Interfaces.Repositories;
using Avanade.BestPractices.Infrestructure.Data.Contexts;
using Avanade.BestPractices.Infrestructure.Data.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Avanade.BestPractices.Infrestructure.Data.Repositories
{
    public class RideRepository : RepositoryBase<Ride>, IRideRepository
    {
        public RideRepository(EntityContext db) : base(db)
        {

        }

        public Task<Ride> GetCurrentAsync(Guid accountId)
        {
            return _db.Rides
                .FirstOrDefaultAsync(x => x.AccountId.Equals(accountId) &&
                                          !x.EndAt.HasValue);
        }
    }
}
