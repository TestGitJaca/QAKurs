using System;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using HomePage = TestQA.PageObjects.HomePage;
using System.Linq;
using UsefulFunctions = TestQA.PageObjects.UsefulFunctions;
using System.Collections.ObjectModel;

namespace TestQA.PageObjects
{
    class RegistrationPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public string TestData_Email = UsefulFunctions.RandomEmail();
        public string TestData_String = UsefulFunctions.RandomString();

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        private IWebElement GetElement(By by)
        {
            IWebElement element;
            try
            {
                element = this.driver.FindElement(by);
            }
            catch (Exception)
            {
                element = null;
            }
            return element;
        }

        private SelectElement GetSelect(By by)
        {
            IWebElement element;
            SelectElement select;
            try
            {
                wait.Until(EC.ElementIsVisible(by));
                element = this.driver.FindElement(by);
                select = new SelectElement(element);
            }
            catch (Exception)
            {
                select = null;
            }
            return select;
        }
        public IWebElement FirstName
        {
            get
            {
                return this.GetElement(By.Name("ime"));
            }
        }

        public IWebElement LastName
        {
            get
            {
                return this.GetElement(By.Name("prezime"));
            }
        }

        public IWebElement NickName
        {
            get
            {
                return this.GetElement(By.Name("korisnicko"));
            }
        }
        public IWebElement Email
        {
            get
            {
                return this.GetElement(By.Name("email"));
            }
        }
        public IWebElement Phone
        {
            get
            {
                return this.GetElement(By.Name("telefon"));
            }
        }
        public SelectElement Country
        {
            get
            {
                return this.GetSelect(By.Name("zemlja"));
            }
        }

        public SelectElement City
        {
            get
            {
                return this.GetSelect(By.Name("grad"));
            }
        }
        public IWebElement Ulica
        {
            get
            {
                return this.GetElement(By.XPath("//div[@id='address']//input"));
            }
        }
        public IWebElement GenderMale
        {
            get
            {
                return this.GetElement(By.Id("pol_m"));
            }
        }
        public IWebElement GenderFemale
        {
            get
            {
                return this.GetElement(By.Id("pol_z"));
            }
        }
        public IWebElement News
        {
            get
            {
                return this.GetElement(By.Name("obavestenja"));
            }
        }
        public IWebElement Promotion
        {
            get
            {
                return this.GetElement(By.Name("promocije"));
            }
        }
        public IWebElement RegisterButton
        {
            get
            {
                return this.GetElement(By.Name("register"));
            }
        }
        public IWebElement SuccessAlert
        {
            get
            {
                wait.Until(EC.ElementIsVisible(By.TagName("td")));
                return this.GetElement(By.CssSelector(".alert-success.alert"));
            }
        }
        public void Gender(int number)
        {
            if (number == 1)
            {
                GenderFemale.Click();
            }
            else if (number == 2)
            {
                GenderMale.Click();
            }

        }

        public void RegisterUser(string firstName, string lastName, string nickName, string phone, string country, string city, string ulica, int gender)
        {
            
            FirstName.SendKeys(firstName + TestData_String);
            LastName.SendKeys(lastName + TestData_String);
            NickName.SendKeys(nickName);
            Email.SendKeys(TestData_Email);
            Phone.SendKeys(phone);
            Country.SelectByText(country);
            City.SelectByText(city);
            Ulica.SendKeys(ulica);
            Gender(gender);
            News.Click();
            Promotion.Click();
            RegisterButton.Click();


        }







    }
}
    

