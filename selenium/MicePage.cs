using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace selenium
{
    public class MicePage
    {
        private IWebDriver _driver;
        private Actions _actions;
        private WebDriverWait _wait;

        public MicePage(IWebDriver driver, Actions actions, WebDriverWait wait)
        {
            _driver = driver;
            _actions = actions;
            _wait = wait;
            PageFactory.InitElements(_driver, this);
        }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//span[@class='constraint__label'][text()='Fingertip']")]
        private IWebElement GripStyleFingertip { get; set; }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Aerox 3 Wireless 2022 Edition')]")]
        private IWebElement NotDisplayedElement { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "js-sorting-select")]
        private IWebElement SortingRudioButton { get; set; }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//*[@id='js-sorting-select']/option[@value='price-low-to-high']")]
        private IWebElement SortByPriceLowToHigh { get; set; }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Remove filter for Connectivity Wireless']")]
        private IWebElement RemoveWirelessFilterButton { get; set; }

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//*[@class='catalog-list-product__current-price']")]
        private IWebElement CatalogPrices { get; set; }


        public void GripStyleFingertipClick()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(GripStyleFingertip)).Click();
        }

        public bool CheckNotDisplayedElement() => NotDisplayedElement == null || !NotDisplayedElement.Displayed;

        public void SortingButtonClick()
        {
            _wait.Until(d => SortingRudioButton.Displayed);
            SortingRudioButton.Click();
            _wait.Until(d => SortByPriceLowToHigh.Displayed);
            SortByPriceLowToHigh.Click();
        }


        public bool CheckSortLowerToHigh()
        {
            _ = _driver.Manage().Timeouts().ImplicitWait;
            Thread.Sleep(3000);
            _wait.Until(ExpectedConditions.ElementToBeClickable(
                _driver.FindElement(By.XPath("//*[@class='catalog-list-product__current-price']"))));
            var priceWebElements = _driver.FindElements(By.XPath("//*[@class='catalog-list-product__current-price']"));
            var priceWebElsText = priceWebElements
                .Select(e => e.Text)
                .ToList();

            var priceStrings = new List<string>();
            foreach (var priceWebElText in priceWebElsText)
            {
                var allowedSymbols = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', '.' };

                var allowedCharsOnly = priceWebElText
                    .Where(c => allowedSymbols.Contains(c))
                    .ToList();

                var stringWithAllowedCharsOnly = new string(allowedCharsOnly.ToArray());

                var stringsWithDotInsteadOfComma = stringWithAllowedCharsOnly.Replace(',', '.');

                priceStrings.Add(stringsWithDotInsteadOfComma);
            }

            var prices = priceStrings
                .Select(str => double.Parse(str))
                .ToList();
            var orderedPrices = prices
                .OrderBy(x => x)
                .ToList();

            return prices.SequenceEqual(orderedPrices);
        }

        public void RemoveWirelessFilter()
        {
            _wait.Until(d => RemoveWirelessFilterButton.Displayed);
            RemoveWirelessFilterButton.Click();
            Thread.Sleep(2000);
        }

        public string GetNumberOfItems()
        {
            _ = _driver.Manage().Timeouts().ImplicitWait;
            var regex = new Regex(@"[0-9]");
            var numberOfItems = _driver.FindElement(By.XPath("//div[@class='faceted-product-list__result-count']"));
            var textOfItemChars = numberOfItems.Text.SkipWhile(c => c != '(').ToArray();
            var textOfItem = new string(textOfItemChars);
            var matches = regex.Matches(textOfItem);
            var answer = "";
            if (matches.Count <= 0) return answer;
            foreach (Match match in matches)
            {
                answer += match;
            }

            return answer;
        }

        public string CheckSortingPriceLowToHigh()
        {
            var selectElem = _driver.FindElement(By.Id("js-sorting-select"));
            var oSelect = new SelectElement(selectElem);
            return oSelect.SelectedOption.Text;
        }
    }
}
