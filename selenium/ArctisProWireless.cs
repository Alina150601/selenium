using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace selenium
{
    public class ArctisProWireless
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ArctisProWireless(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(_driver, this);
        }

        [CacheLookup]
        [FindsBy(How = How.PartialLinkText, Using = "Watch product film")]
        private IWebElement WatchFIlmButton { get; set; }

        // [CacheLookup]
        // [FindsBy(How = How.XPath, Using = "//div[@class='ytp-cued-thumbnail-overlay']/div[@class='ytp-cued-thumbnail-overlay-image']")]
        // private IWebElement PlayButton { get; set; }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//*[@class='ytp-play-button ytp-button']")]
        private IWebElement PlayButton { get; set; }


        public void WatchFIlmClick()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(WatchFIlmButton));
            WatchFIlmButton.Click();
        }

        public void PlayButtonClick()
        {
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//*[@class='mfp-iframe']")));
            Thread.Sleep(3000);
            var playButton = _driver.FindElement(By.XPath("//*[@class='ytp-play-button ytp-button']"));
            _wait.Until(d => playButton);
            playButton.Click();
        }

        public string CheckVideoPlayed()
        {
            var currentTime = _driver.FindElement(By.ClassName("ytp-time-current"));
            return currentTime.Text;
        }
    }
}
