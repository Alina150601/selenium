using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace selenium
{
    public class ArctisProWireless
    {
        private IWebDriver _driver;

        public ArctisProWireless(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Watch product film  ")]
        private IWebElement WatchFIlmButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@aria-label = 'Смотреть']")]
        private IWebElement PlayButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "ytp-time-current")]
        private IWebElement CurrentTime { get; set; }


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
