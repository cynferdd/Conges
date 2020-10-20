using Shared.Core.DomainModeling;
using System;

namespace AccountManagement.Domain
{
    public abstract class Account : Entity<int>
    {
        protected Account(int id, string name)
            :base(id) 
        {
            Name = name;
        }


        public string Name { get; set; }

        public DateTime? ArchiveDate { get; set; }

        
    }
}
