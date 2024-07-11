using GoogleMapTest.Pages;
using OpenQA.Selenium;
using NUnit.Framework;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Gherkin.Model;
using static System.Net.Mime.MediaTypeNames;
using RazorEngine;
using System.Net;

namespace GoogleMapTest.StepDefinitions
{
    [Binding]
    public sealed class GoogleMapsSearchSteps
    {
        private IWebDriver driver;

        GoogleMapsSearchPage googleMapsSearchPage;


    public GoogleMapsSearchSteps(IWebDriver driver)
    {
        this.driver = driver;
    }

    [Given(@"I am on the Google Maps page")]
        public void GivenIAmOnTheGoogleMapsPage()
        {
            googleMapsSearchPage = new GoogleMapsSearchPage(driver);
            googleMapsSearchPage.Navigate();
        }

       
        [Given(@"I am on the Google Maps page with language ""([^""]*)""")]
        public void GivenIAmOnTheGoogleMapsPageWithLanguage(string language)
        {
            googleMapsSearchPage = new GoogleMapsSearchPage(driver);
            googleMapsSearchPage.NavigateAsPerLang(language);
        }


        [When(@"I search for ""(.*)"" on map")]
        public void WhenISearchFor(string address)
        {
            Thread.Sleep(10000);
            googleMapsSearchPage.SearchForAddress(address);
        }

        [When(@"I enter invalid ""([^""]*)"" on map")]
        public void WhenIEnterInvalidOnMap(string coordinates)
        {
            Thread.Sleep(10000);
            googleMapsSearchPage.SearchForAddress(coordinates);
        }


        [Then(@"The application should locate ""(.*)"" on map")]
        public void ThenTheApplicationShouldLocateOnMap(string location)
        {
            Assert.IsTrue(googleMapsSearchPage.IsCenteredOnLocation(location)); 
                }



        [Then(@"an appropriate message should be displayed")]
        public void ThenAnAppropriateMessageShouldBeDisplayed()
        {
            Assert.IsTrue(googleMapsSearchPage.IsErrorMessageDisplayed());
        }


        [Then(@"the page should be displayed in ""(.*)""")]
        public void ThenThePageShouldBeDisplayedIn(string expectedLanguage)
        {
            Assert.AreEqual(expectedLanguage, googleMapsSearchPage.GetPageLanguage());
            }


        [When(@"I get directions from ""([^""]*)"" to ""([^""]*)""")]
        public void WhenIGetDirectionsFromTo(string from, string to)
        {
            googleMapsSearchPage.GetDirections(from, to);
        }

        [Then(@"the directions should be displayed correctly")]
        public void ThenTheDirectionsShouldBeDisplayedCorrectly()
        {

            Assert.IsTrue(googleMapsSearchPage.AreDirectionsDisplayedCorrectly());
           
        }

        [Then(@"The application should correctly locate ""([^""]*)"" on map")]
        public void ThenTheApplicationShouldCorrectlyLocateOnMap(string p0)
        {
            Thread.Sleep(10000);
            Assert.IsTrue(googleMapsSearchPage.IsCenteredOnUpdatedLocation(p0));
        }


    }


}
