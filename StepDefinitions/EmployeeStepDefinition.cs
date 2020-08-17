using IC_TimeMaterialPage.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TurnsUp.Other
{
    [Binding]
    public sealed class EmployeeStepDefinition
    {
        public static IWebDriver driver;

        [Given(@"I have log-in")]
        public void GivenIHaveLog_In()
        {
            LoginPage.logIn(driver);
        }

        [Given(@"I'm in the ""(.*)"" page")]
        public void GivenIMInThePage(string page)
        {
            switch (page) {
                default:
                    EmployeePage.checkIfEmployee(driver);
                    break;
            }
        }

        [When(@"I click the create button")]
        public void WhenIClickTheCreateButton()
        {
            EmployeePage.CreateEmployee(driver);
        }

        [Then(@"I should be able to see the Employee in the portal list")]
        public void ThenIShouldBeAbleToSeeTheEmployeeInThePortalList()
        {
            EmployeePage.CreateEmployee(driver);
        }

    }
}
