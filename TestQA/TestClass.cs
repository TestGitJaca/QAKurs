using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TestQA.PageObjects;
using HomePage = TestQA.PageObjects.HomePage;
using ResultsPage = TestQA.PageObjects.ResultsPage;
using UsefulFunctions = TestQA.PageObjects.UsefulFunctions;
using RegistrationPage = TestQA.PageObjects.RegistrationPage;

namespace TestQA
{
    class TestClass
    {
        private IWebDriver driver;


        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }


        [Test]
        [Category("qa.rs")]
        public void TestQaListFemale()
        {
            ResultsPage lista;
            HomePage naslovna = new HomePage(driver);
            naslovna.GoToPage();
            lista = naslovna.ClickOnLink();

            Assert.GreaterOrEqual(lista.FemaleUsers, 20);
        }

        [Test]
        [Category("qa.rs")]
        public void TestQaListMale()
        {
            ResultsPage lista;
            HomePage naslovna = new HomePage(driver);
            naslovna.GoToPage();
            lista = naslovna.ClickOnLink();
            Assert.GreaterOrEqual(lista.MaleUsers, 10);
        }

        [Test]
        [Category("register.rs")]
        public void RegistrationUser()
        {

            HomePage naslovna = new HomePage(driver);
            naslovna.GoToPage();
            naslovna.ClickRegistarLink();
            RegistrationPage registar = new RegistrationPage(driver);
            registar.RegisterUser("User", "New", "John", "12345-589", "Serbia", "Novi Sad", "Main Street", 1);
            if (registar.SuccessAlert.Displayed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Test failed - user is not registered.");
            }
                  }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        //    IWebElement body = FindElement(driverFirefox, By.TagName("body"));
        //        if (body.Text.Contains("Videos"))
        //        {
        //            Assert.Pass();
        //        } else
        //        {
        //            Assert.Fail("Test failed - no videos present.");
        //        }
        //}

    }
}