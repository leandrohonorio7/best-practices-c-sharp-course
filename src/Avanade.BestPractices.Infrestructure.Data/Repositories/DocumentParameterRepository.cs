using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Domain.Interfaces.Repositories;
using Avanade.BestPractices.Infrestructure.Data.Contexts;
using Avanade.BestPractices.Infrestructure.Data.Repositories.Core;

namespace Avanade.BestPractices.Infrestructure.Data.Repositories
{
    public class DocumentParameterRepository : RepositoryBase<DocumentParameter>, IDocumentParameterRepository
    {
        public DocumentParameterRepository(EntityContext db) : base(db)
        {

        }
    }
}
