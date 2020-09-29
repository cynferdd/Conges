using Authentication.Domain;
using Authentication.Domain.UseCases;
using Authentication.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using NFluent;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Authentication.Acceptance.Test.Steps
{
    [Binding]
    public class AuthentificationLoginSteps
    {
        private string _login;
        private string _password;
        private bool _estCompteBloque = false;
        

        private IActionResult _actual;
        private const string _validLogin = "UtilisateurExistant";
        private const string _validPassword = "MotDePasseValide";

        [Given(@"un login existant")]
        public void SoitUnLoginExistant()
        {
            this._login = _validLogin;
        }
        
        [Given(@"un mot de passe valide correspondant")]
        public void SoitUnMotDePasseValideCorrespondant()
        {
            this._password = _validPassword;
        }
        
        [Given(@"un login inexistant")]
        public void SoitUnLoginInexistant()
        {
            this._login = "UtilisateurInexistant";
        }
        
        [Given(@"un mot de passe aléatoire")]
        public void SoitUnMotDePasseAleatoire()
        {
            this._password = "MotDePasseAléatoire";
        }
        
        [Given(@"un mot de passe erroné")]
        public void SoitUnMotDePasseErrone()
        {
            this._password = "MotDePasseErrone";
        }
        
        [Given(@"un login vide")]
        public void SoitUnLoginVide()
        {
            this._login = "";
        }
        
        [Given(@"un mot de passe vide")]
        public void SoitUnMotDePasseVide()
        {
            this._password = "";
        }
        
        [Given(@"le compte est bloqué")]
        public void SoitLeCompteEstBloque()
        {
            this._estCompteBloque = true;
        }
        
        [When(@"on se connecte")]
        public async Task QuandOnSeConnecte()
        {
            var user = new User()
            {
                Login = _validLogin,
                Password = _validPassword
            };
            var controller =
                new AuthenticationController(
                    new AuthenticationUseCase(
                        AuthenticationUtility.BuildTokenRepository(new DateTime(2049, 05, 17)),
                        AuthenticationUtility.BuildCredentialsRepository(user)));

            var authenticationDto = new AuthenticationDto() 
            { 
                Login = this._login,
                Password = this._password
            };

            this._actual = await controller.ConnectAsync(authenticationDto);
        }
        
        [When(@"on se connecte (.*) fois")]
        public async Task QuandOnSeConnecteFois(int p0)
        {
            for (int i = 0; i < p0; i++)
            {
                await QuandOnSeConnecte();
            }
        }
        
        [Then(@"on recoit un token d'authentification valide")]
        public void AlorsOnRecoitUnTokenDAuthentificationValide()
        {
            Check.That(_actual).IsInstanceOf<OkResult>();
        }
        
        [Then(@"on ne recoit pas de token d'authentification")]
        public void AlorsOnNeRecoitPasDeTokenDAuthentification()
        {
            Check.That(_actual).IsInstanceOf<NotFoundResult>();
        }
        
        [Then(@"on ne recoit pas de token d'authentification et le compte est bloqué")]
        public void AlorsOnNeRecoitPasDeTokenDAuthentificationEtLeCompteEstBloque()
        {
            Check.That(_actual).IsInstanceOf<NotFoundResult>();
            // ???
            // Profit
        }

        [Then(@"on reçoit un NotFound")]
        public void AlorsOnRecoitUnNotFound()
        {
            Check.That(_actual).IsInstanceOf<NotFoundResult>();
        }

        [Then(@"on reçoit un BadRequest Mot de passe erroné")]
        public void AlorsOnRecoitUnBadRequestMotDePasseErrone()
        {
            Check.That(_actual).IsInstanceOf<BadRequestObjectResult>();
            var result = (BadRequestObjectResult)_actual;
            Check.That(result.Value).Equals("Mot de passe erroné");
            
        }

        [Then(@"on reçoit un BadRequest login obligatoire")]
        public void AlorsOnRecoitUnBadRequestLoginObligatoire()
        {
            Check.That(_actual).IsInstanceOf<BadRequestObjectResult>();
            var result = (BadRequestObjectResult)_actual;
            Check.That(result.Value).Equals("Login obligatoire");
        }

        [Then(@"on reçoit un BadRequest mot de passe obligatoire")]
        public void AlorsOnRecoitUnBadRequestMotDePasseObligatoire()
        {
            Check.That(_actual).IsInstanceOf<BadRequestObjectResult>();
            var result = (BadRequestObjectResult)_actual;
            Check.That(result.Value).Equals("Mot de passe obligatoire");
        }

        [Then(@"on reçoit un BadRequest compte est bloqué")]
        public void AlorsOnRecoitUnBadRequestCompteEstBloque()
        {
            Check.That(_actual).IsInstanceOf<BadRequestObjectResult>();
            var result = (BadRequestObjectResult)_actual;
            Check.That(result.Value).Equals("Compte bloqué");
        }

    }
}
