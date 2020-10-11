﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.SecondaryPort
{
    public interface IAccountRepository
    {
        Task<IReadOnlyCollection<Account>> GetAsync();
    }
}