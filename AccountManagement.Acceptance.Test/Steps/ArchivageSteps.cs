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
    public class AuthentificationSteps
    {
        private Account existingAccount;
        private int accountId;
        private IAccountRepository repository;
        private IActionResult result;
        private DateTime? archiveDateBeforeSave;

        [Given(@"un compte qui n'existe pas")]

        public void SoitUnCompteQuiNExistePas()
        {
            this.accountId = 0;
            this.existingAccount = null;
        }
        
        [Given(@"un compte qui existe")]
        public void SoitUnCompteQuiExiste()
        {
            this.accountId = 1;
            this.existingAccount = new LeaveAccount
            {
                Id = 1,
                Name = "nom"
            };

        }
        
        [Given(@"ce compte est déjà archivé")]
        public void SoitCeCompteEstDejaArchive()
        {
            this.existingAccount.ArchiveDate = new DateTime(2020, 10, 01);
        }
        
        [Given(@"ce compte n'est pas archivé")]
        public void SoitCeCompteNEstPasArchive()
        {
            this.existingAccount.ArchiveDate = null;
        }
        
        [When(@"on l'archive")]
        public async Task QuandOnLArchive()
        {
            this.repository = Substitute.For<IAccountRepository>();
            this.repository.GetAsync(this.accountId).Returns(this.existingAccount);
            this.archiveDateBeforeSave = this.existingAccount?.ArchiveDate;
            var archiveUseCase = new ArchiveAccountUseCase(repository);

            var accountController = new AccountController(Substitute.For<IGetAccountsUseCase>(), archiveUseCase, Substitute.For<ICreateAccountUseCase>());
            this.result = await accountController.ArchiveAsync(this.accountId);
            
        }
        
        [Then(@"on recoit un code Http NotFound")]
        public void AlorsOnRecoitUnCodeHttpNotFound()
        {
            Check.That(result).IsInstanceOf<NotFoundResult>();
        }
        
        [Then(@"on recoit un code Http Ok")]
        public void AlorsOnRecoitUnCodeHttpOk()
        {
            Check.That(result).IsInstanceOf<OkResult>();
        }
        
                
        [Then(@"la date d'archivage reste la même")]
        public void AlorsLaDateDArchivageResteLaMeme()
        {
            Check.That(this.archiveDateBeforeSave).IsEqualTo(existingAccount.ArchiveDate);
        }
        
        [Then(@"le compte est archivé")]
        public void AlorsLeCompteEstArchive()
        {
            Check.That(existingAccount.ArchiveDate).IsNotNull();
        }
        


        [Then(@"la date d'archivage est modifiée")]
        public void AlorsLaDateDArchivageEstModifiee()
        {
            Check.That(this.archiveDateBeforeSave).IsNotEqualTo(existingAccount.ArchiveDate);
            repository
                .Received()
                .SaveAsync(this.existingAccount);
        }


    }
}
