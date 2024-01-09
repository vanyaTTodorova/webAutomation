using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject1.PageObjects;

namespace TestProject1.Tests
{
    [TestFixture]
    public class WeatherForecastTests
    {
        private IWebDriver driver;
        private HomePage homePage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.sinoptik.bg/sofia-bulgaria-100727011?location");

            homePage = new HomePage(driver);
            homePage.AcceptCookies("CP4HX0AP4HX0AAHABBENAiEsAP_gAEPAAAIwGMwHIAFAAWAA0ACAAFYAOAA6ACAAFQALQAZAA0ACKAEwALYAYYBAAEDAIMAhABFADgAKQAmkBR4CpAFXALhAXKAukBeYDGQLzgGQAKAAsACoAHAAQAAyABoAEwALYAhAFHgKkAXmAAAA.f_wACHgAAAAA");

        }

        [Test]
        public void TestWeatherForecast()
        {
            homePage.SearchCity("София");
            var weatherForecastPage = homePage.SelectAutoCompleteOption("София");

            weatherForecastPage.AssertCityName("София");
            weatherForecastPage.ClickTenDayForecast();
            weatherForecastPage.CheckDayAndDateVisibility();
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
