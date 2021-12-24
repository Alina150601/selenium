using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace selenium
{
    public class SoftwareEngine
    {
        private IWebDriver _driver;

        public SoftwareEngine(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath,
            Using = "//div[@class='engine-download__buttons']/a/span[text()='Download for Windows 8.1 or newer']")]
        private IWebElement DownloadForWindows { get; set; }

        public void DownloadForWindowsClick()
        {
            DownloadForWindows.Click();
        }
    }
}
