using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Selenium
{
    public class SignUpPage
    {
        private IWebDriver _driver;
        private WebDriverWait wait;
        public SignUpPage(WebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "id_email")]
        [CacheLookup]
        public IWebElement mailField { get; set; }

        [FindsBy(How = How.Id, Using = "id_password1")]
        [CacheLookup]
        public IWebElement passwordField { get; set; }

        [FindsBy(How = How.Id, Using = "id_password2")]
        [CacheLookup]
        public IWebElement passwordConfirmField { get; set; }

        [FindsBy(How = How.Id, Using = "id_accepted_privacy_policy")]
        [CacheLookup]
        public IWebElement privacyPolicyCheckBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "navigation-user__name")]
        [CacheLookup]
        public IWebElement SignUpText { get; set; }

        public void privacyPolicyCheckBoxClick()
        {
            privacyPolicyCheckBox.Click();
        }

        public void FillForm()
        {
            wait.Until(_=>mailField.Displayed);
            mailField.SendKeys("alina.barc@gmail.com");
            passwordField.SendKeys("qwer1234");
            passwordConfirmField.SendKeys("qwer1234");
            privacyPolicyCheckBoxClick();
        }
    }
}
