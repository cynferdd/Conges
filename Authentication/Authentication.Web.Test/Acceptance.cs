using Authentication.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using NFluent;
using System;
using System.Net;
using Xunit;

namespace Authentication.Web.Test
{
    public class Acceptance
    {
        [Fact]
        public void ShouldReturn410HttpCode_WhenUserNotAuthenticated()
        {
            var controller = new AuthenticationController();

            var actual = controller.Get(Guid.NewGuid().ToString());

            Check.That(actual).IsInstanceOf<UnauthorizedResult>();
        }
    }
}
