using OpenQA.Selenium;

namespace IC_TimeMaterialPage.Pages
{
    class HomePage
    {
        public static void goToTM(IWebDriver driver)
        {
            //Clicking Administration button
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            //Clicking Time&Materials button
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
        }

        public static void goToEmployees(IWebDriver driver)
        {
            //Clicking Administration button
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            //Clicking Employees button
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a")).Click();
        }
    }
}
