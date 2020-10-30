using AccountManagement.Domain;
using AccountManagement.Domain.PrimaryPort;
using AccountManagement.Domain.SecondaryPort;
using AccountManagement.Domain.UseCase;
using AccountManagement.Web;
using AccountManagement.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using NFluent;
using NSubstitute;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AccountManagement.Acceptance.Test.Steps
{
    [Binding]
    [Scope(Tag="CreationCompte")]
    public class CreateSteps
    {
        private Account futureAccount;
        private NoLeaveAccount existingAccountFromId;
        private IActionResult result;
        private IAccountRepository repository;
        private NoLeaveAccount existingAccountFromName;

        [Given(@"un compte que l on souhaite créer avec un id (.*)")]
        public void SoitUnCompteQueLOnSouhaiteCreerAvecUnId(int id)
        {
            this.futureAccount = new NoLeaveAccount(new AccountId(id), new AccountName("compte"));
        }
        
        [Given(@"un autre compte déjà existant avec un id (.*)")]
        public void SoitUnAutreCompteDejaExistantAvecUnId(int id)
        {
            this.existingAccountFromId = new NoLeaveAccount(new AccountId(id), new AccountName("existant"));
        }
        
        [Given(@"un compte que l on souhaite créer avec pour nom '(.*)'")]
        public void SoitUnCompteQueLOnSouhaiteCreerAvecPourNom(string name)
        {
            this.futureAccount = new NoLeaveAccount(new AccountId(3), new AccountName(name));
        }
        
        [Given(@"un autre compte déjà existant avec pour nom '(.*)'")]
        public void SoitUnAutreCompteDejaExistantAvecPourNom(string name)
        {
            this.existingAccountFromName = new NoLeaveAccount(new AccountId(4), new AccountName(name));
        }
        
        [Given(@"un compte NoLeave non existant")]
        public void SoitUnCompteNoLeaveNonExistant()
        {
            this.futureAccount = new NoLeaveAccount(new AccountId(10), new AccountName("télétravail"));
        }
        
        [Given(@"un compte Leave non existant")]
        public void SoitUnCompteLeaveNonExistant()
        {
            this.futureAccount = new LeaveAccount(
                new AccountId(11),
                new AccountName("SickLeave"), 
                new Period(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)),
                new Period(new DateTime(2020, 01, 01), new DateTime(2020, 12, 31)),
                2, 
                Frequency.Day);
        }
        
        [When(@"on veut créer le compte")]
        public async Task QuandOnVeutCreerLeCompte()
        {
            this.repository = Substitute.For<IAccountRepository>();
            this.repository.GetAsync(Arg.Any<AccountId>()).Returns(this.existingAccountFromId);

            this.repository.IdExists(Arg.Any<AccountId>()).Returns((existingAccountFromId != null));
            
            this.repository.NameExists(Arg.Any<AccountName>()).Returns((existingAccountFromName != null));

            var createUseCase = new CreateAccountUseCase(repository);

            var accountController = new AccountController(Substitute.For<IGetAccountsUseCase>(), Substitute.For<IArchiveAccountUseCase>(), createUseCase);
            var accountToCreate = AccountDto.FromDomain(this.futureAccount);
            this.result = await accountController.CreateAsync(accountToCreate);
        }
        
        [Then(@"on recoit un code Http BadRequest")]
        public void AlorsOnRecoitUnCodeHttpBadRequest()
        {
            Check.That(result).IsInstanceOf<BadRequestResult>();
        }
        
        [Then(@"il est bien enregistré")]
        public void AlorsIlEstBienEnregistre()
        {
            repository
                .Received()
                .SaveAsync(this.futureAccount);
        }
        
        [Then(@"on recoit un code Http Ok")]
        public void AlorsOnRecoitUnCodeHttpOkPourLaCreation()
        {
            Check.That(result).IsInstanceOf<OkResult>();
        }

    }
}
