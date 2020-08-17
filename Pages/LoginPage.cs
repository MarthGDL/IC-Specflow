using System;
using IC_TimeMaterialPage.Test;
using OpenQA.Selenium;

namespace IC_TimeMaterialPage.Pages
{
    class LoginPage
    {
        public static void logIn(IWebDriver driver)
        {
            //Going to TurnUp log-in page and maximazing window
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/");
            driver.Manage().Window.Maximize();

            //Entering log-in credentials
            driver.FindElement(By.Id("UserName")).SendKeys(TestData.loginUser);
            driver.FindElement(By.Id("Password")).SendKeys(TestData.loginPassword);

            //Clicking log-in button
            driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]")).Click();

            //Find an element after log-in
            IWebElement dropdown_greeting_menu = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            //Validate if the element is there
            if (dropdown_greeting_menu.Text == "Hello "+ TestData.loginUser + "!")
            {
                Console.WriteLine("Login Test passed!");
            }
            else
            {
                Console.WriteLine("Login Test failed...");
            }
        }

    }
}
