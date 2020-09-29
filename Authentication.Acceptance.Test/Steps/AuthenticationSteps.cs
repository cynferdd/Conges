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

namespace Authentication.Acceptance.Test.Steps
{
    [Binding]
    public class AuthenticationSteps
    {
        private DateTime _expirationDate;
        private DateTime _now;
        private IActionResult _actual;

        [Given(@"the token has an expiration date set to (.*)/(.*)/(.*)")]
        public void GivenTheTokenHasAnExpirationDateSetTo(int day, int month, int year)
        {
            _expirationDate = new DateTime(year, month, day);
        }
        
        [Given(@"today's date is (.*)/(.*)/(.*)")]
        public void GivenTodaySDateIs(int day, int month, int year)
        {
            _now = new DateTime(year, month, day);
        }
        
        [When(@"we check the authentication")]
        public async Task WhenWeCheckTheAuthentication()
        {
            var controller =
                new AuthenticationController(
                    new AuthenticationUseCase(
                        AuthenticationUtility.BuildTokenRepository(_expirationDate),
                        AuthenticationUtility.BuildCredentialsRepository(null)));
            await ProcessGetAsync(controller);
        }

        private async Task ProcessGetAsync(AuthenticationController controller)
        {
            _actual = await controller.GetAsync(Guid.Empty.ToString(), _now);
        }

        [Then(@"we receive an Ok http code")]
        public void ThenWeReceiveAnHttpCode()
        {
            Check.That(_actual).IsInstanceOf<OkResult>();
        }

        

    }
}
