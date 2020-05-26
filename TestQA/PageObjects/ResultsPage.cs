using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace TestQA.PageObjects
{
    class ResultsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public UInt64 FemaleUsers
        {
            get
            {
                ReadOnlyCollection<IWebElement> rows = null;
                try
                {
                    rows = this.driver.FindElements(By.XPath("//td[@class='gender'][text()='Z']"));
                }
                catch (Exception)
                {

                }
                return Convert.ToUInt64(rows.Count);
            }
        }

        public UInt64 MaleUsers
        {
            get
            {
                ReadOnlyCollection<IWebElement> rows = null;
                try
                {
                    rows = this.driver.FindElements(By.XPath("//td[@class='gender'][text()='M']"));
                }
                catch (Exception)
                {

                }
                return Convert.ToUInt64(rows.Count);
            }
        }

    }
}
