using Authentication.Domain;
using Authentication.Domain.SecondaryPorts;
using Authentication.Domain.UseCases;
using Authentication.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using NFluent;
using NSubstitute;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Authentication.Web.Test
{
    public class Acceptance
    {
        public static TheoryData<DateTime?> UnauthorizedExpirationDate = new TheoryData<DateTime?>
        {
            (DateTime?)null,
            DateTime.Now.AddDays(-3)
        };

        [Theory]
        [MemberData(nameof(UnauthorizedExpirationDate))]
        public async Task ShouldReturn410HttpCode_WhenUserNotAuthenticated(DateTime? expiration)
        {
            var controller =
                new AuthenticationController(
                    new AuthenticationUseCase(
                        BuildRepository(expiration)));

            var actual = await controller.GetAsync(Guid.NewGuid().ToString(), new DateTime(2020, 09, 02));

            Check.That(actual).IsInstanceOf<UnauthorizedResult>();
        }

        [Fact]
        public async Task ShouldReturn200HttpCode_WhenUserCorrectlyAuthenticated()
        {
            var controller = 
                new AuthenticationController(
                    new AuthenticationUseCase(
                        BuildRepository(new DateTime(2020, 09, 07))));

            var actual = await controller.GetAsync(Guid.Empty.ToString(), new DateTime(2020, 09, 02));

            Check.That(actual).IsInstanceOf<OkResult>();
        }

        private static ITokenRepository BuildRepository(DateTime? expirationDate)
        {
            var repository = Substitute.For<ITokenRepository>();
            repository
                .GetExpirationDateAsync(Arg.Any<AuthenticationToken>())
                .Returns(expirationDate);
            return repository;
        }
    }
}
