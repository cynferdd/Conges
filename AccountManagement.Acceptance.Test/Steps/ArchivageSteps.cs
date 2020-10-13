using System;
using TechTalk.SpecFlow;

namespace AccountManagement.Acceptance.Test.Steps
{
    [Binding]
    public class AuthentificationSteps
    {
        [Given(@"un compte qui n'existe pas")]
        public void SoitUnCompteQuiNExistePas()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"un compte qui existe")]
        public void SoitUnCompteQuiExiste()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"ce compte est déjà archivé")]
        public void SoitCeCompteEstDejaArchive()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"ce compte n'est pas archivé")]
        public void SoitCeCompteNEstPasArchive()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"on l'archive")]
        public void QuandOnLArchive()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"on recoit un code Http NotFound")]
        public void AlorsOnRecoitUnCodeHttpNotFound()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"on recoit un code Http Ok")]
        public void AlorsOnRecoitUnCodeHttpOk()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Le compte est archivé")]
        public void AlorsLeCompteEstArchive()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"la date d'archivage reste la même")]
        public void AlorsLaDateDArchivageResteLaMeme()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"le compte est archivé")]
        public void AlorsLeCompteEstArchive()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"la date d'(.*)'heure actuelle")]
        public void AlorsLaDateDHeureActuelle(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
