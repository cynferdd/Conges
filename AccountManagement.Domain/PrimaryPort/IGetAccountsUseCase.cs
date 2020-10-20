using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManagement.Domain.PrimaryPort
{
    public interface IGetAccountsUseCase
    {
        Task<IReadOnlyCollection<Account>> GetAsync();

        Task<Account?> GetAsync(int accountId);
    }
}
