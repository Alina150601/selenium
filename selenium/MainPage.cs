using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace selenium
{
    public class MainPage
    {
        private const string MainPagePath = "https://steelseries.com/";

        private IWebDriver _driver;
        private Actions actions;
        private WebDriverWait wait;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            actions = new Actions(_driver);
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a.courtesy-navigation__sign-up")]
        [CacheLookup]
        private IWebElement SignUpButton { get; set; }

        [FindsBy(How = How.LinkText, Using = " Mousepads ")]
        [CacheLookup]
        private IWebElement MousepadsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Mice')]")]
        [CacheLookup]
        private IWebElement MiceButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Headsets')]")]
        [CacheLookup]
        private IWebElement HeadsetsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Software')]")]
        [CacheLookup]
        private IWebElement SoftwareButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='sc-leadgen']")]
        [CacheLookup]
        private IWebElement Alert { get; set; }

        public void GoToMainPage()
        {
            _driver.Navigate().GoToUrl(MainPagePath);
        }

        public void CloseAlert()
        {
            wait.Until(d => Alert.Displayed);
            var closeCross = _driver.FindElement(By.XPath("//*[@id='sc-leadgen']/div/div[2]"));
            actions.MoveToElement(closeCross).Build().Perform();
            closeCross.Click();
        }
        public void WirelessMiceClick()
        {
            actions.MoveToElement(MiceButton).Build().Perform();
            var wirelessButton = _driver.FindElement(By.XPath("/html/body/header/nav[2]/div[1]/ul/li[2]/ul/li[2]/a/span"));
            actions.MoveToElement(wirelessButton).Build().Perform();
            wirelessButton.Click();
        }

        public void SignUpButtonClick()
        {
            //wait.Until(ExpectedConditions.ElementToBeClickable(SignUpButton));
            SignUpButton.Click();
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

        public void MousepadsButtonClick()
        {
            MousepadsButton.Click();
        }
    }
}
