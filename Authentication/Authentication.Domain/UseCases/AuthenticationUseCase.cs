using Authentication.Domain.PrimaryPorts;
using Authentication.Domain.SecondaryPorts;
using Shared.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.UseCases
{
    public class AuthenticationUseCase : IAuthenticationUseCase
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly ICredentialsRepository _credentialsRepository;

        public AuthenticationUseCase(ITokenRepository tokenRepository, ICredentialsRepository credentialsRepository)
        {
            _tokenRepository = tokenRepository;
            _credentialsRepository = credentialsRepository;
        }

        public async Task<AuthenticationToken> ConnectAsync(string login, string password)
        {
            var user = await _credentialsRepository.GetUserAsync(login);
            throw new NotFoundException<string>(login);
        }

        public async Task<bool> IsValidAsync(AuthenticationToken token, DateTime now)
        {
            var expirationDate = await _tokenRepository.GetExpirationDateAsync(token);
            return expirationDate != null && now < expirationDate;
        }

    }
}
