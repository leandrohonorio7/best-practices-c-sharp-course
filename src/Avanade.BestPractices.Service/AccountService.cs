using Avanade.BestPractices.Domain.Entities;
using Avanade.BestPractices.Domain.Interfaces.Repositories;
using Avanade.BestPractices.Domain.Interfaces.Services;
using Avanade.BestPractices.Service.Core;
using Avanade.BestPractices.Service.Validators;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace Avanade.BestPractices.Service
{
    public class AccountService : ServiceBase<Account>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task AddAsync(Account account)
        {
            var validator = new AccountValidator();
            await validator.ValidateAndThrowAsync(account);

            await _accountRepository.AddAsync(account);
            await _accountRepository.SaveChangesAsync();
        }

        public Task<Account> GetByIdAsync(Guid id)
        {
            return _accountRepository.GetByIdAsync(id);
        }
    }
}
