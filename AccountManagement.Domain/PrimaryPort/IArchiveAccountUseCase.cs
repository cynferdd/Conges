﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.PrimaryPort
{
    public interface IArchiveAccountUseCase
    {
        Task ArchiveAsync(int id);
    }
}
