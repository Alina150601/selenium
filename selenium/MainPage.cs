using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace selenium
{
    public class MainPage
    {
        private IWebDriver _driver;
        Actions actions;
        public const string MainPagePath = "https://steelseries.com/";

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            actions = new Actions(_driver);
        }

        [FindsBy(How = How.XPath, Using = "a.courtesy-navigation__sign-up")]
        public IWebElement SignUpButton { get; }

        [FindsBy(How = How.LinkText, Using = " Mousepads ")]
        public IWebElement MousepadsButton { get; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Mice')]")]
        public IWebElement MiceButton{ get; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Headsets')]")]
        public IWebElement HeadsetsButton{ get; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Software')]")]
        public IWebElement SoftwareButton{ get; }

        public void WirelessMiceClick()
        {
            actions.MoveToElement(MiceButton).Build().Perform();
            _driver.FindElement(By.XPath("//*[contains(text(),'Wireless')]")).Click();
        }

        public void PcHeadsetsClick()
        {
            actions.MoveToElement(HeadsetsButton).Build().Perform();
            _driver.FindElement(By.XPath("//*[contains(text(),'PC')]")).Click();
        }

        public void EngineSoftwareClick()
        {
            actions.MoveToElement(SoftwareButton).Build().Perform();
            SoftwareButton.Click();
            _driver.FindElement(By.LinkText(" Engine ")).Click();
        }

        public void SignUpButtonClick()
        {
            SignUpButton.Click();
        }
    }
}
