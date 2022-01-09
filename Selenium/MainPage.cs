using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Selenium
{
    public class MainPage
    {
        private const string MainPagePath = "https://steelseries.com/";

        private IWebDriver _driver;
        private Actions _actions;
        private WebDriverWait _wait;

        public MainPage(IWebDriver driver, Actions actions, WebDriverWait wait)
        {
            _driver = driver;
            _actions = actions;
            _wait = wait;
            PageFactory.InitElements(_driver, this);
        }

        [CacheLookup]
        [FindsBy(How = How.CssSelector, Using = "a.courtesy-navigation__sign-up")]
        private IWebElement SignUpButton { get; set; }

        [CacheLookup]
        [FindsBy(How = How.LinkText, Using = "Mousepads")]
        private IWebElement MousepadsButton { get; set; }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Mice')]")]
        private IWebElement MiceButton { get; set; }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Headsets')]")]
        private IWebElement HeadsetsButton { get; set; }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//button[normalize-space(text()) = 'Software']")]
        private IWebElement SoftwareButton { get; set; }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//*[@id='sc-leadgen']")]
        private IWebElement Alert { get; set; }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//ul[@class='category-navigation__sub-list navigation-dropdown__list']//span[@class='category-navigation__sub-text' and normalize-space(text()) = 'Wireless']")]
        private IWebElement WirelessButton { get; set; }

        public void GoToMainPage()
        {
            _driver.Navigate().GoToUrl(MainPagePath);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }

        public void CloseAlert()
        {
            _wait.Until(d => Alert.Displayed);
            var closeCross = _driver.FindElement(By.XPath("//*[@id='sc-leadgen']/div/div[2]"));
            _actions.MoveToElement(closeCross).Build().Perform();
            closeCross.Click();
        }

        public void WirelessMiceClick()
        {
            _actions.MoveToElement(MiceButton).Build().Perform();
            HoverOver(WirelessButton);
            WirelessButton.Click();
        }

        public void SignUpButtonClick()
        {
            SignUpButton.Click();
        }

        public void PcHeadsetsClick()
        {
            HoverOver(HeadsetsButton);
            var HeadsetsPCButton = _driver.FindElement(By.XPath(
                "//nav[@class='category-navigation is-expanded']//span[contains(text(),'PC')]"));
            _wait.Until(ExpectedConditions.ElementToBeClickable(HeadsetsButton));
            HeadsetsPCButton.Click();
        }

        public void EngineSoftwareClick()
        {
            SoftwareButton.Click();
            _wait.Until(d => d.FindElement(By.XPath("//li[@class='category-navigation__item']/a[normalize-space(text()) = 'Engine']"))).Click();
        }

        public void MousepadsButtonClick()
        {
            MousepadsButton.Click();
        }

        public void HoverOver(IWebElement webElement)
        {
            var action = new Actions(_driver);
            _wait.Until(drv =>
            {
                action.MoveToElement(webElement);
                action.Build().Perform();
                return true;
            });
        }
    }
}
