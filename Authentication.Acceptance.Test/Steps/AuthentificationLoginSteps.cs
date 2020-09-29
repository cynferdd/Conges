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
    public class AuthentificationLoginSteps
    {
        private string _login;
        private string _password;
        private int _nbTentativesConnexions = 0;
        private User _user = null;
        private ICredentialsRepository _credentialRepository;

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
            this._nbTentativesConnexions = 3;
        }
        
        [When(@"on se connecte")]
        public async Task QuandOnSeConnecte()
        {

            
            if (_login == _validLogin)
            {
                _user = new User()
                {
                    Login = _login,
                    Password = _validPassword,
                    NbTentativesConnexions = _nbTentativesConnexions
                };
            }
            _credentialRepository = AuthenticationUtility.BuildCredentialsRepository(_user);
            var controller =
                new AuthenticationController(
                    new AuthenticationUseCase(
                        AuthenticationUtility.BuildTokenRepository(new DateTime(2049, 05, 17)),
                        _credentialRepository));

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
                _nbTentativesConnexions++;
            }
        }
        [Then(@"l'utilisateur a été sauvegardé")]
        public void AlorsLUtilisateurAEteSauvegarde()
        {
            _credentialRepository
                .Received()
                .SaveUserAsync(_user);
        }

        [Then(@"le nombre de connexion est à (.*)")]
        public void AlorsLeNombreDeConnexionEstA(int p0)
        {
            Check.That(_user.NbTentativesConnexions).Equals(p0);
        }

        [Then(@"le compte est bloqué")]
        public void AlorsLeCompteEstBloque()
        {
            Check.That(_user.EstCompteBloque);
        }


        [Then(@"on recoit un token d'authentification valide")]
        public void AlorsOnRecoitUnTokenDAuthentificationValide()
        {
            Check.That(_actual).IsInstanceOf<OkObjectResult>();
        }
        
        [Then(@"on ne recoit pas de token d'authentification")]
        public void AlorsOnNeRecoitPasDeTokenDAuthentification()
        {
            Check.That(_actual).IsInstanceOf<NotFoundResult>();
        }
        
        [Then(@"on reçoit un BadRequest Mot de passe erroné et le compte devient bloqué")]
        public void AlorsOnRecoitUnBadRequestMotDePasseErroneEtLeCompteDevientBloque()
        {
            Check.That(_actual).IsInstanceOf<BadRequestObjectResult>();
            var result = (BadRequestObjectResult)_actual;
            Check.That(result.Value).Equals("Mot de passe erroné");

            Check.That(_user.EstCompteBloque);
            
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
