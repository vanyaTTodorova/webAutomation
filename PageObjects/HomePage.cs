using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject1.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        // Locators
        private By searchField = By.Id("searchField");
        private By consentBanner = By.XPath("//img[contains(@src,'980%D1%85620_transition_grabo_winter_2023.jpg')]");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void AcceptCookies(string consentValue)
        {
            Cookie consentCookie = new Cookie("euconsent-v2", consentValue, "www.sinoptik.bg", "/", DateTime.Now.AddDays(1));
            driver.Manage().Cookies.AddCookie(consentCookie);
            driver.Navigate().Refresh();
        }

        public void SearchCity(string city)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(searchField));
            wait.Until(ExpectedConditions.ElementToBeClickable(searchField));
            driver.FindElement(searchField).Click();
            driver.FindElement(searchField).SendKeys(city);
        }

        public WeatherForecastPage SelectAutoCompleteOption(string optionText)
        {
            var autoCompleteOptions = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[contains(@class, 'autocomplete-w1')]/div[contains(@class, 'autocomplete')]/a")));
            foreach (var option in autoCompleteOptions)
            {
                if (option.Text.Contains(optionText))
                {
                    option.Click();
                    break;
                }
            }
            return new WeatherForecastPage(driver);
        }

    }
}
