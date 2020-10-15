using AccountManagement.Domain.PrimaryPort;
using AccountManagement.Domain.SecondaryPort;
using System;
using System.Collections.Generic;
using System.Text;
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
        public async Task ArchiveAsync(int id)
        {
            throw new NotImplementedException();
            //await accountRepository.ArchiveAsync(id);
        }
    }
}
