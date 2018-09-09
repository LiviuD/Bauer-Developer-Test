using Bauer.Developer.Test.RestaurantGuide.Domain.ValidationAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;

namespace Bauer.Developer.Test.RestaurantGuide.Site.Controllers.Tests
{
    [TestClass()]
    public class RestaurantControllerUITest
    {
        private string baseURL = "http://localhost:19139";
        private RemoteWebDriver driver;
        private string browser;
        public TestContext TestContext { get; set; }
        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {   //Set the browswer from a build
            browser = this.TestContext.Properties["browser"] != null ? this.TestContext.Properties["browser"].ToString() : "chrome";
            switch (browser)
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                //case "PhantomJS":
                //    driver = new PhantomJSDriver();
                //    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
            if (this.TestContext.Properties["Url"] != null) //Set URL from a build
            {
                this.baseURL = this.TestContext.Properties["Url"].ToString();
            }
            else
            {
                this.baseURL = "http://localhost:19139";   //default URL just to get started with
            }
        }

        [TestMethod]
        [TestCategory("Selenium")]
        [Owner("Chrome")]
        public void WhenDisplayThePhoneNumberTheRequiredFormatIsApplied()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(this.baseURL + "/Restaurant/Edit/1");
            var value = driver.FindElementById("PhoneNumberFormated").GetAttribute("value");
            var phoneNumberValidator = new AustralianPhoneNumber();
            if (!phoneNumberValidator.IsValid(value))
            {
                Assert.Fail("The phone number is not a valid Australian one");
            }
            if(!(value.IndexOf(" ") == 4 && value.LastIndexOf(" ") == 9))
                Assert.Fail("The phone number is not properly formated for display");
        }
    }
}