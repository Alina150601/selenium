using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace selenium
{
    public class MousepadsPage
    {
        private IWebDriver _driver;
        private Actions _actions;
        private WebDriverWait _wait;

        public MousepadsPage(IWebDriver driver, Actions actions, WebDriverWait wait)
        {
            _driver = driver;
            _actions = actions;
            _wait = wait;
            PageFactory.InitElements(_driver, this);
        }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'QcK Prism Cloth')][./span[normalize-space() = 'XL']]/../div[@class='catalog-list-product__related-text']")]
        private IWebElement ModelOfMousepad { get; set; }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//div[@class='tooltip'][3]")]
        private IWebElement Tooltop { get; set; }

        public void ArrowRightClick()
        {
            HoverOver(ModelOfMousepad);
            _wait.Until(d => d.FindElement(By.XPath("//div[contains(text(), 'QcK Prism Cloth')][./span[normalize-space() = 'XL']]/../../..//div[@class='glide__arrows']")).Displayed);
            HoverOver(_driver.FindElement(By.XPath("//div[contains(text(), 'QcK Prism Cloth')][./span[normalize-space() = 'XL']]/../../..//div[@class='glide__arrows']")));
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//div[contains(text(), 'QcK Prism Cloth')][./span[normalize-space() = 'XL']]/../../..//div[@class='glide__arrows']")))).Click();
        }

        public string TooltopText()
        {
            HoverOver(Tooltop);
            return Tooltop.Text;
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
