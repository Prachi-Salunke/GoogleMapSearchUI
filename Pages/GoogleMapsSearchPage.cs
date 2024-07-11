using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Microsoft.CodeAnalysis;
using System.Net;
namespace GoogleMapTest.Pages
{
    public class GoogleMapsSearchPage
    {

        private IWebDriver driver;
        private const string Url = "https://www.google.com/maps";

        public GoogleMapsSearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By SearchBox = By.Name("q");
        By SearchButton =By.Id("searchbox-searchbutton");
        By DirectionsButton = By.XPath("//button[@id='hArJGc']");
        By StartingPointInput = By.XPath("//div[@id='directions-searchbox-0']//input");
        By DestinationInput = By.XPath("//div[@id='directions-searchbox-1']//input");
        By errorMsg =By.XPath("//*[contains(text(), 'Make sure your search is spelled correctly.')]");

             


        public void Navigate()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void SearchForAddress(string address)
        {
           
            driver.FindElement(SearchBox).SendKeys(address);
            driver.FindElement(SearchButton).Click();
        }


        public bool IsCenteredOnLocation(string location)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
               
                string expectedAddress = location;
                bool isAddressPresent;
                string pageSource = driver.PageSource;
                if(isAddressPresent = pageSource.Contains(expectedAddress))
                 return true; 
                
           else
                return false;
                }
        public bool IsCenteredOnUpdatedLocation(string location)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            string expectedAddress = location;
            bool isAddressPresent;
            string pageSource = driver.PageSource;
            if (isAddressPresent = pageSource.Contains(expectedAddress))
                return true;

            else
                return false;
        }


        public string GetPageLanguage()
        {
            return driver.FindElement(By.TagName("html")).GetAttribute("lang");
        }
        public void NavigateAsPerLang(string language)
        {
            driver.Navigate().GoToUrl($"https://www.google.com/maps?hl={language}");
        }
        public void GetDirections(string from, string to)
        {
            driver.FindElement(DirectionsButton).Click();
            Thread.Sleep(10000);
            driver.FindElement(StartingPointInput).SendKeys(from);
            driver.FindElement(StartingPointInput).SendKeys(Keys.Enter);
            driver.FindElement(DestinationInput).SendKeys(to);
            driver.FindElement(DestinationInput).SendKeys(Keys.Enter);
        }
        public bool AreDirectionsDisplayedCorrectly()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(driver => driver.FindElement(By.Id("section-directions-trip-0")).Displayed);
                Thread.Sleep(10000);
                return true;

            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }


        public bool IsErrorMessageDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Console.WriteLine(driver.PageSource);
           driver.FindElements(errorMsg);
             return true;
            

        }
            
        }
    }

