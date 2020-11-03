using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Domain;
using AccountManagement.Domain.SecondaryPort;
using AccountManagement.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infra.SecondaryAdapters
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountManagementContext _context;

        public AccountRepository(AccountManagementContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyCollection<Account>> GetAsync()
        {
            var accounts = await _context.Set<DbAccount>().ToListAsync();
            return accounts.Select(account => account.ToDomain()).ToList();
        }

        

        public async Task<Account?> GetAsync(AccountId id)
        {
            var account = await _context.Set<DbAccount>().FindAsync((int)id);
            return account.ToDomain();
        }

        public async Task<bool> IdExists(AccountId id)
        {
            return await _context.Set<DbAccount>().AnyAsync(a => a.Id == (int)id);
            
        }

        public async Task<bool> NameExists(AccountName name)
        {
            return await _context.Set<DbAccount>().AnyAsync(a => a.Name == (string)name);
        }

        public Task SaveAsync(Account account)
        {
            // todo : FromDomain
            // todo : création avec "candidat de compte"
            // todo : 2 signatures pour SaveAsync (uncreated account => juste un map, add et saveAsync) (Account => find dbAccount, map champs et save)
            throw new System.NotImplementedException();
        }
    }
}