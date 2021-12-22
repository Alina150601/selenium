using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace selenium
{
    public class MicePage
    {
        private IWebDriver _driver;
        Actions actions;

        public MicePage(IWebDriver driver)
        {
            _driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//span[@class='constraint__label'][text()='Fingertip']")]
        private IWebElement GripStyleFingertip { get; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Aerox 3 Wireless 2022 Edition')]")]
        private IWebElement NotDisplayedElement { get; }

        [FindsBy(How = How.Id, Using = "js-sorting-select")]
        private IWebElement SortingRudioButton { get; }

        [FindsBy(How = How.Id, Using = "//*[@id='js-sorting-select']/option[@value='price-low-to-high']")]
        private IWebElement SortByPriceLowToHigh { get; }

        [FindsBy(How = How.XPath, Using = "//*[@class='catalog-list-product__current-price']")]
        private List<IWebElement> PriceElements = new List<IWebElement>(); //question. FindsBy -> elementSSS

        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Remove filter for Connectivity Wired']")]
        private IWebElement RemoveConnectivityWiredFilter { get; }

        [FindsBy(How = How.XPath, Using = "//h1/div[contains(text(),'items')]")]
        private IWebElement NumberOfItems { get; }


        public void GripStyleFingertipClick()
        {
            GripStyleFingertip.Click();
        }

        public bool CheckNotDisplayedElement()
        {
            return !NotDisplayedElement.Displayed;
        }

        public void SortingRudioButtonClick()
        {
            SortingRudioButton.Click();
        }

        public void SortByPriceLowToHighClick()
        {
            SortByPriceLowToHigh.Click();
        }

        public bool CheckSortLowerToHigh()
        {
            var listOfPrice = _driver.FindElements(By.XPath("//*[@class='catalog-list-product__current-price']"));
            var resultOfSort = false;
            return resultOfSort;
        }

        public void RemoveConnectivityWiredFilterClick()
        {
            RemoveConnectivityWiredFilter.Click();
        }

        public int GetNumberOfItems()
        {
            return int.Parse(NumberOfItems.Text);
        }
    }
}
