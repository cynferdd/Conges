using AccountManagement.Domain.PrimaryPort;
using AccountManagement.Domain.SecondaryPort;
using System;
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
            var idExists = await this.accountRepository.IdExists(account.Id);
            if (!idExists)
            {
                throw new InvalidOperationException();
            }

            var nameExists = await this.accountRepository.NameExists(account.Name);
            if (!nameExists)
            {
                throw new InvalidOperationException();
            }
            await accountRepository.SaveAsync(account);
        }
    }
}
