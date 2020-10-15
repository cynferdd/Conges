using System;

namespace AccountManagement.Domain
{
    public abstract class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? ArchiveDate { get; set; }
    }
}
