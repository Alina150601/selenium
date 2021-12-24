using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace selenium
{
    public class HeadsetPage
    {
        private IWebDriver _driver;
        public HeadsetPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath,
            Using = "div[contains(text(), 'Arctis Pro Wireless')][./span[normalize-space() = 'White']]")]
        private IWebElement OneModelOfHeadset { get; set; }

        public void OneModelOfHeadsetClick()
        {
            OneModelOfHeadset.Click();
        }
    }
}
