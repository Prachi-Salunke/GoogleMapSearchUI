using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;

/*This file is designed to set up the WebDriver configuration. It allows you to select any browser 
  from the provided options and also supports running Chrome in headless mode.*/
namespace GoogleMapsUITests.Drivers
{
    public class WebDriverSetup
    {
        public IWebDriver CreateDriver()
        {
            IWebDriver driver;

            // Change the browser type here to switch between browsers
            string browserType = "chrome"; // can be "chrome", "firefox", "edge"

            switch (browserType.ToLower())
            {
                case "firefox":
                    driver = new FirefoxDriver(Environment.CurrentDirectory);
                    break;
                case "edge":
                    driver = new EdgeDriver(Environment.CurrentDirectory);
                    break;
                case "chrome":
                default:
                    var options = new ChromeOptions();
                    // options.AddArgument("--headless"); // Runs Chrome in headless mode
                    /// options.AddArgument("--disable-gpu"); // Disables GPU hardware acceleration
                    // driver = new ChromeDriver(options);
                    driver = new ChromeDriver(Environment.CurrentDirectory);

                    break;
            }

            // Common setup for all browsers
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}