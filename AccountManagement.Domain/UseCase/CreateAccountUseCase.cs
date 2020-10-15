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
            throw new NotImplementedException();
        }
    }
}
