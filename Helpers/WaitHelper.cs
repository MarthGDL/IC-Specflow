using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace IC_TimeMaterialPage.Helpers
{
    class WaitHelper
    {
        static void Main() { }
        public static void WaitClickble(IWebDriver driver, string locator)
        {
            var Wait = new WebDriverWait(driver, new TimeSpan(0,0,5));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
        }
    }
}
