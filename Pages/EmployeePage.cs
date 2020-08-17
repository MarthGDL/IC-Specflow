using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IC_TimeMaterialPage.Test;
using NUnit.Framework;
using OpenQA.Selenium;

namespace IC_TimeMaterialPage.Pages
{
    class EmployeePage
    {
        public static void checkIfEmployee(IWebDriver driver)
        {
            if (driver.Url != "http://horse-dev.azurewebsites.net/User")
            {
                if (driver.Url == "http://horse-dev.azurewebsites.net/")
                {
                    HomePage.goToEmployees(driver);
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        public static void CreateEmployee(IWebDriver driver)
        {
            //Clicking Create button
            driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();

            //Fill "Name" fieldbox
            driver.FindElement(By.XPath("//*[@id='Name']")).SendKeys(TestData.formValidation);

            //Fill "UserName" fieldbox
            driver.FindElement(By.XPath("//*[@id='Username']")).SendKeys(TestData.formValidation);

            //Fill "Password" fieldbox
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys(TestData.loginPassword);

            //Fill "RetypePassword" fieldbox
            driver.FindElement(By.XPath("//*[@id='RetypePassword']")).SendKeys(TestData.loginPassword);

            //Click "Save" button
            driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();

        }

        public static void CheckEmployee(IWebDriver driver)
        {
            //Not Implemented
        }
    }
}
