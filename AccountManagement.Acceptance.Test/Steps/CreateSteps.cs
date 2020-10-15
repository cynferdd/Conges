using AccountManagement.Domain;
using AccountManagement.Domain.PrimaryPort;
using AccountManagement.Domain.SecondaryPort;
using AccountManagement.Domain.UseCase;
using AccountManagement.Web;
using AccountManagement.Web.Controllers;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using NFluent;
using NSubstitute;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AccountManagement.Acceptance.Test.Steps
{
    [Binding]
    public class CreateSteps
    {
        private Account futureAccount;
        private LeaveAccount existingAccount;
        private IActionResult result;
        private IAccountRepository repository;

        [Given(@"un compte que l on souhaite créer avec un id (.*)")]
        public void SoitUnCompteQueLOnSouhaiteCreerAvecUnId(int id)
        {
            this.futureAccount = new LeaveAccount()
            {
                Id = id
            };
        }
        
        [Given(@"un autre compte déjà existant avec un id (.*)")]
        public void SoitUnAutreCompteDejaExistantAvecUnId(int id)
        {
            this.existingAccount = new LeaveAccount()
            {
                Id = id,
                Name = "existant"
            };
        }
        
        [Given(@"un compte que l on souhaite créer avec pour nom '(.*)'")]
        public void SoitUnCompteQueLOnSouhaiteCreerAvecPourNom(string name)
        {
            this.futureAccount = new LeaveAccount()
            {
                Id = 3,
                Name = name
            };
        }
        
        [Given(@"un autre compte déjà existant avec pour nom '(.*)'")]
        public void SoitUnAutreCompteDejaExistantAvecPourNom(string name)
        {
            this.futureAccount = new NoLeaveAccount()
            {
                Id = 4,
                Name = name
            };
        }
        
        [Given(@"un compte NoLeave non existant")]
        public void SoitUnCompteNoLeaveNonExistant()
        {
            this.futureAccount = new NoLeaveAccount()
            {
                Id = 10,
                Name = "télétravail"
            };
        }
        
        [Given(@"un compte Leave non existant")]
        public void SoitUnCompteLeaveNonExistant()
        {
            this.futureAccount = new LeaveAccount()
            {
                Id = 11,
                Name = "SickLeave",
                AcquisitionStart = new DateTime(2020, 01, 01),
                AcquisitionEnd = new DateTime(2020, 12, 31),
                AmountGainedPerFrequency = 2,
                Frequency = Frequency.Day

            };
        }
        
        [When(@"on veut créer le compte")]
        public async Task QuandOnVeutCreerLeCompte()
        {
            this.repository = Substitute.For<IAccountRepository>();
            this.repository.GetAsync(Arg.Any<int>()).Returns(this.existingAccount);
            
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
    }
}
