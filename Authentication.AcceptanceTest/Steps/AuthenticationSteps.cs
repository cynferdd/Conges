using Authentication.Domain;
using Authentication.Domain.SecondaryPorts;
using Authentication.Domain.UseCases;
using Authentication.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using NFluent;
using NSubstitute;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Authentication.AcceptanceTest.Steps
{
    [Binding]
    public class AuthenticationSteps
    {
        private DateTime _expirationDate;
        private DateTime _now;
        private IActionResult _actual;

        [Given(@"que l'on a un token avec une date d'expiration au (.*)/(.*)/(.*)")]
        public void SoitQueLExpirationAu(int jour, int mois, int année)
        {
            _expirationDate = new DateTime(année, mois, jour);
        }
        
        [Given(@"que la date du jour est le (.*)/(.*)/(.*)")]
        public void SoitQueLaDateDuJourEstLe(int jour, int mois, int année)
        {
            _now = new DateTime(année, mois, jour);
        }
        
        [When(@"on vérifie l'authentification")]
        public async Task QuandOnVerifieLAuthentification()
        {
            var controller =
                new AuthenticationController(
                    new AuthenticationUseCase(
                        BuildRepository(_expirationDate)));

            _actual = await controller.GetAsync(Guid.Empty.ToString(), _now);
        }
        
        [Then(@"on recoit un code Http Ok")]
        public void AlorsOnRecoitUnCodeHttpOk()
        {
            Check.That(_actual).IsInstanceOf<OkResult>();
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
