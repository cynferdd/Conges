﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.4.0.0
//      SpecFlow Generator Version:3.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AccountManagement.Acceptance.Test.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class AuthentificationFeature : object, Xunit.IClassFixture<AuthentificationFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Archivage.feature"
#line hidden
        
        public AuthentificationFeature(AuthentificationFeature.FixtureData fixtureData, AccountManagement_Acceptance_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("fr-FR"), "Features", "Authentification", "  Quand un compte n\'est plus désiré, on doit pouvoir l\'archiver", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Archivage de compte inexistant")]
        [Xunit.TraitAttribute("FeatureTitle", "Authentification")]
        [Xunit.TraitAttribute("Description", "Archivage de compte inexistant")]
        [Xunit.TraitAttribute("Category", "ArchivageCompte")]
        public virtual void ArchivageDeCompteInexistant()
        {
            string[] tagsOfScenario = new string[] {
                    "ArchivageCompte"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Archivage de compte inexistant", null, tagsOfScenario, argumentsOfScenario);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
  testRunner.Given("un compte qui n\'existe pas", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Etant donné ");
#line hidden
#line 7
  testRunner.When("on l\'archive", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line hidden
#line 8
  testRunner.Then("on recoit un code Http NotFound", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Archivage de compte déjà archivé")]
        [Xunit.TraitAttribute("FeatureTitle", "Authentification")]
        [Xunit.TraitAttribute("Description", "Archivage de compte déjà archivé")]
        public virtual void ArchivageDeCompteDejaArchive()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Archivage de compte déjà archivé", null, tagsOfScenario, argumentsOfScenario);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 11
 testRunner.Given("un compte qui existe", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Etant donné ");
#line hidden
#line 12
 testRunner.And("ce compte est déjà archivé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
#line 13
 testRunner.When("on l\'archive", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line hidden
#line 14
 testRunner.Then("on recoit un code Http Ok", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
#line 15
 testRunner.And("le compte est archivé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
#line 16
 testRunner.And("la date d\'archivage reste la même", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Archivage de compte non archivé")]
        [Xunit.TraitAttribute("FeatureTitle", "Authentification")]
        [Xunit.TraitAttribute("Description", "Archivage de compte non archivé")]
        public virtual void ArchivageDeCompteNonArchive()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Archivage de compte non archivé", null, tagsOfScenario, argumentsOfScenario);
#line 18
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 19
 testRunner.Given("un compte qui existe", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Etant donné ");
#line hidden
#line 20
 testRunner.And("ce compte n\'est pas archivé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
#line 21
 testRunner.When("on l\'archive", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line hidden
#line 22
 testRunner.Then("on recoit un code Http Ok", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
#line 23
 testRunner.And("le compte est archivé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
#line 24
 testRunner.And("la date d\'archivage est modifiée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.4.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                AuthentificationFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                AuthentificationFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
