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
        private WebDriverWait _wait;

        public MousepadsPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            PageFactory.InitElements(_driver, this);
        }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'QcK Prism Cloth')][./span[normalize-space() = 'XL']]/../div[@class='catalog-list-product__related-text']")]
        private IWebElement ModelOfMousepad { get; set; }

        public void ArrowRightClick()
        {
            var javascript = (IJavaScriptExecutor) _driver;
            HoverOver(ModelOfMousepad);
            javascript.ExecuteScript("window.scrollBy(0,150)", "");
            HoverOver(ModelOfMousepad);
            _wait.Until(d => d.FindElement(By.XPath("//div[contains(text(), 'QcK Prism Cloth')][./span[normalize-space() = 'XL']]/../../..//div[@class='glide__arrows']")).Displayed);
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//div[contains(text(), 'QcK Prism Cloth')][./span[normalize-space() = 'XL']]/../../..//div[@class='glide__arrows']/button[@class='glide__arrow glide__arrow--right']")))).Click();
        }

        public string TooltipText()
        {
            _wait.Until(d => d.FindElement(By.XPath("//div[@class='tooltip'][2]/div[@class='tooltip__inner']")).Displayed);
            return _driver.FindElement(By.XPath("//div[@class='tooltip'][2]/div[@class='tooltip__inner']")).Text;
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
