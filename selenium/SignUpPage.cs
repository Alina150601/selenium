using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace selenium
{
    public class SignUpPage
    {
        // var driver = new ChromeDriver();
        // var mainPage = new MainPage(driver);
        // mainPage.wirelessMiceClick();
        // var another = new SignInPage(driver);
        public IWebDriver _driver;
        public SignUpPage(WebDriver driver)
        {
            _driver = driver;
        }

        [FindsBy(How = How.Id, Using = "id_email")]
        public IWebElement mailField { get; }

        [FindsBy(How = How.Id, Using = "id_password1")]
        public IWebElement passwordField{ get; }

        [FindsBy(How = How.Id, Using = "id_password2")]
        public IWebElement passwordConfirmField{ get; }

        [FindsBy(How = How.Id, Using = "id_accepted_privacy_policy")]
        public IWebElement privacyPolicyCheckBox{ get; }

        [FindsBy(How = How.ClassName, Using = "navigation-user__name")]
        public IWebElement SignUpText{ get; }

        public void privacyPolicyCheckBoxClick()
        {
            privacyPolicyCheckBox.Click();
        }

    }
}
