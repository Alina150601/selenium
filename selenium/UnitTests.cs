using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium
{
    public class Tests
    {
        WebDriver _driver;

        [SetUp]
        public void StartBrowser()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void SignUpTest()
        {
            var mainPage = new MainPage(_driver);
            mainPage.GoToMainPage();
            mainPage.CloseAlert();
            mainPage.SignUpButtonClick();
            var signUpPage = new SignUpPage(_driver);
            signUpPage.mailField.SendKeys("alina.barc@gmail.com");
            signUpPage.passwordField.SendKeys("qwer1234");
            signUpPage.passwordConfirmField.SendKeys("qwer1234");
            signUpPage.privacyPolicyCheckBoxClick();
            Assert.IsTrue(signUpPage.SignUpText.Text != null);
            Assert.Pass();
        }

        [Test]
        public void TooltipTest()
        {
            var mainPage = new MainPage(_driver);
            mainPage.GoToMainPage();
            mainPage.MousepadsButtonClick();
            var mousepadsPage = new MousepadsPage(_driver);
            mousepadsPage.ArrowLeftClick();
            var tooltopText = mousepadsPage.TooltopText();
            Assert.AreEqual("XL", tooltopText);
        }

        [Test]
        public void Filtering()
        {
            var mainPage = new MainPage(_driver);
            mainPage.GoToMainPage();
            mainPage.WirelessMiceClick();
            var micePage = new MicePage(_driver);
            micePage.GripStyleFingertipClick();
            micePage.CheckNotDisplayedElement();
            micePage.SortingRudioButtonClick();
            micePage.SortByPriceLowToHighClick();
            //5.	Check that mices are ordered correctly by price
            var firstNumberOfItems = micePage.GetNumberOfItems();
            micePage.RemoveConnectivityWiredFilterClick();
            var secondNumberOfItems = micePage.GetNumberOfItems();
            var resultOfDeletedFilter = firstNumberOfItems < secondNumberOfItems;
            Assert.IsTrue(resultOfDeletedFilter);
            //8.	Check that sorting is still by “Price (low to high)
        }

        [Test]
        public void WatchProductFilm()
        {
            var mainPage = new MainPage(_driver);
            mainPage.GoToMainPage();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            mainPage.PcHeadsetsClick();
            var headsetPage = new HeadsetPage(_driver);
            headsetPage.OneModelOfHeadsetClick();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            var arctisProWireless = new ArctisProWireless(_driver);
            arctisProWireless.WatchFIlmClick();
            arctisProWireless.PlayButtonClick();
            Thread.Sleep(2000);
            Assert.AreNotEqual("0:00", arctisProWireless.CheckVideoPlayed());
        }

        [Test]
        public void DownloadSoftware()
        {
            var mainPage = new MainPage(_driver);
            mainPage.GoToMainPage();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            mainPage.EngineSoftwareClick();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            var softwareEngine = new SoftwareEngine(_driver);
            softwareEngine.DownloadForWindowsClick();
            //???4.	Check installer is downloaded successfully
        }
    }
}
