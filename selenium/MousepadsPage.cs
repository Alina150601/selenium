using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace selenium
{
    public class MousepadsPage
    {
        private IWebDriver _driver;
        Actions actions;
        public MousepadsPage(IWebDriver driver)
        {
            _driver = driver;
            actions = new Actions(_driver);
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'QcK Prism Cloth')][./span[normalize-space() = 'XL']]")]
        private IWebElement ArrowLeft { get; }

        [FindsBy(How = How.XPath, Using = "//div[@id='tooltip_t3q5w6d2of']/div[@class='tooltip__inner']")]
        private IWebElement Tooltop { get; }

        public void ArrowLeftClick()
        {
            actions.MoveToElement(ArrowLeft).Build().Perform();
            ArrowLeft.Click();
        }

        public string TooltopText()
        {
            return Tooltop.Text;
        }
    }
}