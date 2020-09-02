using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.SecondaryPorts
{
    public interface ITokenRepository
    {
        Task<DateTime?> GetExpirationDateAsync(AuthenticationToken token);
    }
}
