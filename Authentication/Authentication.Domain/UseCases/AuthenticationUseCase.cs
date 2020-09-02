using Authentication.Domain.PrimaryPorts;
using Authentication.Domain.SecondaryPorts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.UseCases
{
    public class AuthenticationUseCase : IAuthenticationUseCase
    {
        private readonly ITokenRepository _tokenRepository;
        public AuthenticationUseCase(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        public async Task<bool> IsValidAsync(AuthenticationToken token, DateTime now)
        {
            var expirationDate = await _tokenRepository.GetExpirationDateAsync(token);
            return expirationDate != null && now < expirationDate;
        }
    }
}
