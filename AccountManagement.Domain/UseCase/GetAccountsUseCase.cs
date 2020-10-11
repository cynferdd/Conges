using AccountManagement.Domain.PrimaryPort;
using AccountManagement.Domain.SecondaryPort;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        

    }
}
