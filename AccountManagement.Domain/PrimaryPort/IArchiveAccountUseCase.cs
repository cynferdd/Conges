﻿using System.Threading.Tasks;

namespace AccountManagement.Domain.PrimaryPort
{
    public interface IArchiveAccountUseCase
    {
        Task ArchiveAsync(AccountId id);
    }
}
