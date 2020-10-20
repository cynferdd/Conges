using Authentication.Domain.PrimaryPorts;
using Authentication.Domain.SecondaryPorts;
using Shared.Core.Exceptions;
using System;
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
            CheckNullParameter(login, "Login");

            CheckNullParameter(password, "Mot de passe");

            var user = await _credentialsRepository.GetUserAsync(login);

            if (user is null)
            {
                throw new NotFoundException<string>(login);
            }

            if (user.EstCompteBloque)
            {
                throw new AccessViolationException();
            }

            if (password != user.Password)
            {
                user.NbTentativesConnexions++;
                await _credentialsRepository.SaveUserAsync(user);
                throw new ArgumentException("Mot de passe erroné");
            }

            user.NbTentativesConnexions = 0;
            await _credentialsRepository.SaveUserAsync(user);
            return new AuthenticationToken(Guid.NewGuid());
            
        }

        private static void CheckNullParameter(string parameter, string parameterName)
        {
            if (parameter is null || parameter == "")
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public async Task<bool> IsValidAsync(AuthenticationToken token, DateTime now)
        {
            var expirationDate = await _tokenRepository.GetExpirationDateAsync(token);
            return expirationDate != null && now < expirationDate;
        }

    }
}
