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
            var accounts = await _context.Set<DbAccount>().Where(acc => acc.ArchiveDate == null).ToListAsync();
            return accounts.Select(account => account.ToDomain()).ToList();
        }

        

        public async Task<Account?> GetAsync(AccountId id)
        {
            var account = await _context.Set<DbAccount>().FirstOrDefaultAsync(acc => acc.ArchiveDate == null && acc.Id == (int)id);
            return account?.ToDomain();
        }

        public async Task<bool> IdExists(AccountId id)
        {
            return await _context.Set<DbAccount>().AnyAsync(a => a.Id == (int)id);
            
        }

        public async Task<bool> NameExists(AccountName name)
        {
            return await _context.Set<DbAccount>().AnyAsync(a => a.Name == (string)name);
        }

        public async Task SaveAsync(Account account)
        {
            var dbAccount =
                await _context.Set<DbAccount>().FirstOrDefaultAsync(a => a.Id == (int) account.Id);
            if (dbAccount is null)
            {
                dbAccount = new DbAccount();
                await _context.AddAsync(dbAccount);
            }

            dbAccount.UpdateFromDomain(account);
            
            await _context.SaveChangesAsync();
        }
    }
}