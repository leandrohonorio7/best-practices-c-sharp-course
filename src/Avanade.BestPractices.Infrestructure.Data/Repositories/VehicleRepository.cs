using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Domain.Interfaces.Repositories;
using Avanade.BestPractices.Infrestructure.Data.Contexts;
using Avanade.BestPractices.Infrestructure.Data.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Avanade.BestPractices.Infrestructure.Data.Repositories
{
    public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(EntityContext db) : base(db)
        {

        }
        public new Task<Vehicle> GetByIdAsync(Guid id)
        {
            return _db.Vehicles
                .Include(x => x.ModelVersion.Model.Manufacturer)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
