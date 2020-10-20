using System;
using System.Threading.Tasks;

namespace Authentication.Domain.SecondaryPorts
{
    public interface ITokenRepository
    {
        Task<DateTime?> GetExpirationDateAsync(AuthenticationToken token);
    }
}
