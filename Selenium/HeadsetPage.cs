using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Selenium
{
    public class HeadsetPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public HeadsetPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(_driver, this);
        }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Arctis Pro Wireless')][./span[normalize-space() = 'White']]")]
        private IWebElement OneModelOfHeadset { get; set; }

        public void OneModelOfHeadsetClick()
        {
            _wait.Until(d => OneModelOfHeadset.Displayed);
            OneModelOfHeadset.Click();
        }
    }
}
