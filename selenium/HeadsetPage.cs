using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace selenium
{
    public class HeadsetPage
    {
        private IWebDriver _driver;
        public HeadsetPage(IWebDriver driver)
        {
            _driver = driver;
        }

        [FindsBy(How = How.XPath,
            Using = "div[contains(text(), 'Arctis Pro Wireless')][./span[normalize-space() = 'White']]")]
        private IWebElement OneModelOfHeadset { get; }

        public void OneModelOfHeadsetClick()
        {
            OneModelOfHeadset.Click();
        }
    }
}
