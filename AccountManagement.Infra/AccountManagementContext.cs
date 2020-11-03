using System;
using AccountManagement.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infra
{
    public class AccountManagementContext : DbContext
    {
        public AccountManagementContext(DbContextOptions options)
            :base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DbAccountConfiguration());

        }
    }
}