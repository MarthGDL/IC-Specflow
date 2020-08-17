using System;
using System.Threading;
using IC_TimeMaterialPage.Helpers;
using IC_TimeMaterialPage.Test;
using NUnit.Framework;
using OpenQA.Selenium;

namespace IC_TimeMaterialPage.Pages
{
    class TMPage
    {
        public static void checkIfTM(IWebDriver driver)
        {
            if (driver.Url != "http://horse-dev.azurewebsites.net/TimeMaterial") 
            {
                if (driver.Url == "http://horse-dev.azurewebsites.net/")
                {
                    HomePage.goToTM(driver);
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
        
        public static void CreateTM(IWebDriver driver)
        {
            //Clicking Create button
            driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();

            //Entering Time details
            //string time_code = "Dbot";
            driver.FindElement(By.Id("Code")).SendKeys(TestData.formValidation);
            driver.FindElement(By.Id("Description")).SendKeys("Time Automatically Created on 08/08/2020");

            /////////////////////////////////////Selecting drop down option////////////////////////////////////////////

            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]")).Click();

            //Clicking Price fieldbox (Because it is using a Kendo format) and then entering string into it
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            driver.FindElement(By.XPath("//*[@id='Price']")).SendKeys("2020");

            //Clicking the save button and waiting 1s
            driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();

            //////////////////////////Validating that the creation was successfull////////////////////////////

            //Clicking the "Go to last" button
            WaitHelper.WaitClickble(driver, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]");
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();

            //Asigning the Text of the last element in the last page to a string variable 
            String textvalue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]")).Text;////*[@id="tmsGrid"]/div[3]/table/tbody/tr[1]/td[5]/a[1]

            //Comparing the Text to the time_code variable
            if (textvalue == TestData.formValidation)
            {
                Console.WriteLine(TestData.formValidation + " found, Creation Test passed!");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine(TestData.formValidation + " not found, Creation Test failed...");
                Assert.Fail();
            }
        }

        public static void EditTM(IWebDriver driver)
        {
            //Clicking the "Go to last" button
            WaitHelper.WaitClickble(driver, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]");
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();

            //Clicking EDIT in the last element in the grid and wait
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]")).Click();

            //Get the code of the element and modify it (after waiting for the page loading)
            WaitHelper.WaitClickble(driver, "//*[@id='Code']");
            String time_code_edit = driver.FindElement(By.Id("Code")).Text;
            driver.FindElement(By.Id("Code")).SendKeys("Ed");

            //Clicking the save button and wait
            driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();

            //////////////////////////Validating that the edit was successfull////////////////////////////

            //Clicking the "Go to last" button after a wait
            WaitHelper.WaitClickble(driver, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]");
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();

            //Asigning the Text of the last element in the last page to a string variable 
            string textvalue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]")).Text;////*[@id="tmsGrid"]/div[3]/table/tbody/tr[1]/td[5]/a[1]

            //Comparing the Text to the time_code variable
            if (textvalue != time_code_edit)
            {
                Console.WriteLine(time_code_edit + " is different from "+ textvalue + ", Edit Test passed!");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine(time_code_edit + " isn't different from " + textvalue + ", Edit Test failed...");
                Assert.Fail();
            }
        }

        public static void DeleteTM(IWebDriver driver)
        {
            //Clicking the "Go to last" button after a wait
            WaitHelper.WaitClickble(driver, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]");
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();

            //Asigning the last element delete button to a variable
            IWebElement deletedTextvalue = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));

            //Clicking DELETE in the last element in the grid
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]")).Click();

            //Creating a new driver to the alert message and Clicking YES in the alert message, after we use a delay
            driver.SwitchTo().Alert().Accept();
            WaitHelper.WaitClickble(driver, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]");

            //////////////////////////Validating that the delete was successfull////////////////////////////


            //Comparing the Text to the time_code variable
            if (driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]")) != deletedTextvalue)
            {
                Console.WriteLine("Previous element not found, Delete Test passed!");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Previous element found, Delete Test failed...");
                Assert.Fail();
            }
        }
    }
}
