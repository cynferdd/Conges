using AccountManagement.Domain.PrimaryPort;
using AccountManagement.Domain.SecondaryPort;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UseCase
{
    public class CreateAccountUseCase : ICreateAccountUseCase
    {
        private readonly IAccountRepository accountRepository;

        public CreateAccountUseCase(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task CreateAsync(Account account)
        {
            var existingAccountFromId = await this.accountRepository.GetAsync(account.Id);
            if (existingAccountFromId != null)
            {
                throw new InvalidOperationException();
            }

            var existingAccountFromName = await this.accountRepository.GetAsync(account.Name);
            if (existingAccountFromName != null)
            {
                throw new InvalidOperationException();
            }
            await accountRepository.SaveAsync(account);
        }
    }
}
