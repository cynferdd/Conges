using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AccountManagement.Infra
{
    public class AccountManagementContextFactory: IDesignTimeDbContextFactory<AccountManagementContext>
    {
        public AccountManagementContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        @"..\AccountManagement.Web"))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Hexagonal");
            var optionsBuilder = new DbContextOptionsBuilder<AccountManagementContext>();
            optionsBuilder.UseSqlServer(connectionString);
            
            return new AccountManagementContext(optionsBuilder.Options);
        }
    }
}