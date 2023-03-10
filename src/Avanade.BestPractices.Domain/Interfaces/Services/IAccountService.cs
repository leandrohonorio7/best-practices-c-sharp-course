using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Infrestructure.Core.Entities.Interfaces;
using System;
using System.Threading.Tasks;

namespace Avanade.BestPractices.Domain.Interfaces.Services
{
    public interface IAccountService : IService<Account>
    {
        Task AddAsync(Account account);

        Task<Account> GetByIdAsync(Guid id);
    }
}
