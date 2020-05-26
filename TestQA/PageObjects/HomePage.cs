using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using RegistrationPage = TestQA.PageObjects.RegistrationPage;

namespace TestQA.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void GoToPage()
        {
            this.driver.Navigate().GoToUrl("http://test.qa.rs/");
        }

        public IWebElement ClickLInk
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[@href='/list']"));
                }
                catch (Exception)
                {
                    element = null;
                }

                return element;
            }
        }

        public ResultsPage ClickOnLink()
        {
            this.ClickLInk?.Click();
            wait.Until(EC.ElementIsVisible(By.TagName("table")));
            return new ResultsPage(this.driver);
        }

        public IWebElement ClickRegister
        {
            get
            {
                IWebElement element;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.XPath("//div[@id='registerLinkPlaceholder']/a")));
                    element = this.driver.FindElement(By.XPath("//a[@href='/new']"));
                }
                catch (Exception)
                {
                    element = null;
                }

                return element;
            }
        }

        public RegistrationPage ClickRegistarLink()
        {
            this.ClickRegister?.Click();
            wait.Until(EC.ElementIsVisible(By.Name("register")));
            return new RegistrationPage(this.driver);
        }


    }
}