using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace selenium
{
    public class ArctisProWireless
    {
        private IWebDriver _driver;

        public ArctisProWireless(IWebDriver driver)
        {
            _driver = driver;
        }

        [FindsBy(How = How.LinkText, Using = "Watch product film  ")]
        private IWebElement WatchFIlmButton { get; }

        [FindsBy(How = How.XPath, Using = "//button[@aria-label = 'Смотреть']")]
        private IWebElement PlayButton { get; }

        [FindsBy(How = How.ClassName, Using = "ytp-time-current")]
        private IWebElement CurrentTime { get; }


        public void WatchFIlmClick()
        {
            WatchFIlmButton.Click();
        }

        public void PlayButtonClick()
        {
            PlayButton.Click();
        }

        public string CheckVideoPlayed()
        {
            return CurrentTime.Text;
        }
    }
}
