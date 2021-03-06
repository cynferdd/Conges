﻿using AccountManagement.Domain.PrimaryPort;
using AccountManagement.Domain.SecondaryPort;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Core.Exceptions;

namespace AccountManagement.Domain.UseCase
{
    public class GetAccountsUseCase : IGetAccountsUseCase
    {
        private readonly IAccountRepository accountRepository;

        public GetAccountsUseCase(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public async Task<IReadOnlyCollection<Account>> GetAsync()
        {
            return await accountRepository.GetAsync();
        }

        public async Task<Account> GetAsync(AccountId accountId)
        {
            var account = await accountRepository.GetAsync(accountId);
            if (account is null)
            {
                throw new NotFoundException<AccountId>(accountId);
            }

            return account;
        }
    }
}
