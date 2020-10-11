using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.PrimaryPort
{
    public interface IGetAccountsUseCase
    {
        Task<IReadOnlyCollection<Account>> GetAsync();
    }
}
