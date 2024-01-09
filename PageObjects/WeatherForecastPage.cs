using OpenQA.Selenium;
using NUnit.Framework;

namespace TestProject1.PageObjects
{
    public class WeatherForecastPage
    {
        private IWebDriver driver;

        // Locators
        private By currentCity = By.XPath("//div[@class='currentCityHeading']/h1[@class='currentCity']");
        private By tenDayForecastLink = By.XPath("(//a[contains(text(), '10-дневна')])[1]");
        private By wf10dayRightContent = By.ClassName("wf10dayRightContent");

        public WeatherForecastPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AssertCityName(string expectedCityName)
        {
            var element = driver.FindElement(currentCity);
            string actualText = element.Text;
            Assert.That(actualText, Is.EqualTo(expectedCityName));
        }

        public void ClickTenDayForecast()
        {
            driver.FindElement(tenDayForecastLink).Click();
        }

        public void CheckDayAndDateVisibility()
        {
            var container = driver.FindElement(wf10dayRightContent);
            var dayElements = container.FindElements(By.ClassName("wf10dayRightDay"));
            var dateElements = container.FindElements(By.ClassName("wf10dayRightDate"));

            foreach (var dayElement in dayElements)
            {
                Assert.IsTrue(dayElement.Displayed, "A day element is not visible.");
            }

            foreach (var dateElement in dateElements)
            {
                Assert.IsTrue(dateElement.Displayed, "A date element is not visible.");
            }
        }
    }
}
