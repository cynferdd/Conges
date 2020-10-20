using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManagement.Domain.SecondaryPort
{
    public interface IAccountRepository
    {
        Task<IReadOnlyCollection<Account>> GetAsync();

        Task<Account?> GetAsync(AccountId id);

        Task<bool> IdExists(AccountId id);
        Task<bool> NameExists(string name);
        
        Task SaveAsync(Account account);
    }
}
