using AccountManagement.Domain.PrimaryPort;
using AccountManagement.Domain.SecondaryPort;
using Shared.Core.Exceptions;
using System;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UseCase
{
    public class ArchiveAccountUseCase : IArchiveAccountUseCase
    {
        private readonly IAccountRepository accountRepository;

        public ArchiveAccountUseCase(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public async Task ArchiveAsync(AccountId id)
        {
            var account = await accountRepository.GetAsync(id);
            if (account is null)
            {
                throw new NotFoundException<AccountId>(id);
            }
            if (account.ArchiveDate is null)
            {
                account.ArchiveDate = DateTime.Now;
                await accountRepository.SaveAsync(account);
            }
            
        }
    }
}
