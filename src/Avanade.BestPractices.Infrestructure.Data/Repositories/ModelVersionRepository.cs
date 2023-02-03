using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Domain.Interfaces.Repositories;
using Avanade.BestPractices.Infrestructure.Data.Contexts;
using Avanade.BestPractices.Infrestructure.Data.Repositories.Core;

namespace Avanade.BestPractices.Infrestructure.Data.Repositories
{
    public class ModelVersionRepository : RepositoryBase<ModelVersion>, IModelVersionRepository
    {
        public ModelVersionRepository(EntityContext db) : base(db)
        {

        }
    }
}
