using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace selenium
{
    public class SignUpPage
    {
        // var driver = new ChromeDriver();
        // var mainPage = new MainPage(driver);
        // mainPage.wirelessMiceClick();
        // var another = new SignInPage(driver);
        private IWebDriver _driver;

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
    }
}
