using Authentication.Domain;
using Authentication.Domain.SecondaryPorts;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Acceptance.Test.Steps
{
    public static class AuthenticationUtility
    {
        public static ITokenRepository BuildTokenRepository(DateTime? expirationDate)
        {
            var repository = Substitute.For<ITokenRepository>();
            repository
                .GetExpirationDateAsync(Arg.Any<AuthenticationToken>())
                .Returns(expirationDate);
            return repository;
        }

        public static ICredentialsRepository BuildCredentialsRepository(User user)
        {
            var repository = Substitute.For<ICredentialsRepository>();
            repository
                .GetUserAsync(Arg.Any<string>())
                .Returns(user);
            
            return repository;
        }
    }
}
