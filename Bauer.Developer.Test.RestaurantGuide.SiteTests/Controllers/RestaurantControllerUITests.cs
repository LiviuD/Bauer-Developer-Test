using Bauer.Developer.Test.RestaurantGuide.Domain;
using Bauer.Developer.Test.RestaurantGuide.Domain.ValidationAttributes;
using Bauer.Developer.Test.RestaurantGuide.Site.Models;
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
                //TODO: is better that this url is kept as a TestContext variables
                this.baseURL = "http://localhost:19139";   //default URL just to get started with
            }
        }

        [TestMethod]
        [TestCategory("Selenium")]
        [Owner("Chrome")]
        public void WhenDisplayThePhoneNumberInBrowserInEditTheRequiredFormatIsApplied()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(this.baseURL + "/Restaurant/Edit/1");//TODO: is better that this url is kept as a TestContext variables
            var value = driver.FindElementById("PhoneNumberFormated").GetAttribute("value");
            var phoneNumberValidator = new AustralianPhoneNumber();
            if (!phoneNumberValidator.IsValid(value))
            {
                Assert.Fail("The phone number is not a valid Australian one");
            }
            if(!(value.IndexOf(" ") == 4 && value.LastIndexOf(" ") == 9))
                Assert.Fail("The phone number is not properly formated for display");
        }

        [TestMethod]
        [TestCategory("Selenium")]
        [Owner("Chrome")]
        public void WhenDisplayThePhoneNumberInBrowserInHomePageTheRequiredFormatIsApplied()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(this.baseURL);//TODO: is better that this url is kept as a TestContext variables
            var phoneElements = driver.FindElementsByClassName("phone");//TODO: is better that this class name is kept as a TestContext variables
            if (phoneElements == null || phoneElements.Count == 0)
                Assert.Fail("There are no phones on the page");
            foreach(var phoneElement in phoneElements)
            {
                var value = phoneElement.Text;
                var phoneNumberValidator = new AustralianPhoneNumber();
                if (!phoneNumberValidator.IsValid(value))
                {
                    Assert.Fail($"The phone number {value} is not a valid Australian one");
                }
                if (!(value.IndexOf(" ") == 4 && value.LastIndexOf(" ") == 9))
                    Assert.Fail($"The phone number {value} is not properly formated for display");
            }
        }

        [TestMethod]
        public void WhenDisplayThePhoneNumberTheRequiredFormatIsApplied()
        {
            var restaurant = new Restaurant();
            restaurant.Name = "Test restaurant";
            restaurant.PhoneNumber = "262488871";
            restaurant.Id = 1;
            restaurant.PostCode = "1111";
            restaurant.Rating = 1;
            restaurant.State = "NSW";
            restaurant.Suburb = "Test one";
            restaurant.AddressLine1 = "Address 1";
            restaurant.AddressLine2 = "Address 2";
            restaurant.Chef = "Test Chef";
            restaurant.CuisineId = 1;

            var restaurantModel = new RestaurantModel(restaurant);
            Assert.IsTrue(restaurantModel.PhoneNumberFormated == "(02) 6248 8887");
        }
    }
}