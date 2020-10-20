using System;
using System.Threading.Tasks;

namespace Authentication.Domain.PrimaryPorts
{
    public interface IAuthenticationUseCase
    {
        Task<bool> IsValidAsync(AuthenticationToken token, DateTime now);
        Task<AuthenticationToken> ConnectAsync(string login, string password);
    }
}
