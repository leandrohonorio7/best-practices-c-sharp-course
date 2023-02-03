using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Domain.Interfaces.Repositories;
using Avanade.BestPractices.Infrestructure.Data.Contexts;
using Avanade.BestPractices.Infrestructure.Data.Repositories.Core;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace Avanade.BestPractices.Infrestructure.Data.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(EntityContext db) : base(db)
        {

        }

        public new Task<Account> GetByIdAsync(Guid id)
        {
            return _db.Accounts
                .Include(x => x.Documents)
                    .ThenInclude(x => x.DocumentParameters)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
