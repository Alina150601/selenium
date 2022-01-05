using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace selenium
{
    public class Tests
    {
        private WebDriver _driver;
        private WebDriverWait _wait;
        private Actions _actions;

        [SetUp]
        public void StartBrowser()
        {
            _driver = new ChromeDriver();
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            _driver.Manage().Window.Maximize();
        }


        [Test]
        public void SignUpTest()
        {
            var mainPage = new MainPage(_driver, _actions, _wait);
            mainPage.GoToMainPage();
            mainPage.CloseAlert();
            mainPage.SignUpButtonClick();
            var signUpPage = new SignUpPage(_driver);
            signUpPage.FillForm();
            Assert.IsTrue(signUpPage.SignUpText.Text != null);
            Assert.Pass();
        }

        [Test]
        public void TooltipTest()
        {
            var mainPage = new MainPage(_driver, _actions, _wait);
            mainPage.GoToMainPage();
            mainPage.CloseAlert();
            mainPage.MousepadsButtonClick();
            var mousepadsPage = new MousepadsPage(_driver, _actions, _wait);
            mousepadsPage.ArrowRightClick();
            var tooltopText = mousepadsPage.TooltopText();
            Assert.AreEqual("XL", tooltopText);
        }

        [Test]
        public void Filtering()
        {
            var mainPage = new MainPage(_driver, _actions, _wait);
            mainPage.GoToMainPage();
            mainPage.CloseAlert();
            mainPage.WirelessMiceClick();
            var micePage = new MicePage(_driver, _actions, _wait);
            micePage.GripStyleFingertipClick();
            micePage.CheckNotDisplayedElement();
            micePage.SortingButtonClick();
            Assert.IsTrue(micePage.CheckSortLowerToHigh());
            var firstNumberOfItems = micePage.GetNumberOfItems();
            micePage.RemoveWirelessFilter();
            var secondNumberOfItems = micePage.GetNumberOfItems();
            Assert.IsTrue(int.Parse(firstNumberOfItems) < int.Parse(secondNumberOfItems));
            Assert.AreEqual("Price (low to high)", micePage.CheckSortingPriceLowToHigh());
        }

        [Test]
        public void WatchProductFilm()
        {
            var mainPage = new MainPage(_driver, _actions, _wait);
            mainPage.GoToMainPage();
            mainPage.CloseAlert();
            mainPage.PcHeadsetsClick();
            var headsetPage = new HeadsetPage(_driver, _wait);
            headsetPage.OneModelOfHeadsetClick();
            var arctisProWireless = new ArctisProWireless(_driver, _wait);
            arctisProWireless.WatchFIlmClick();
            arctisProWireless.PlayButtonClick();
            Thread.Sleep(2000);
            Assert.AreNotEqual("0:00", arctisProWireless.CheckVideoPlayed());
        }

        [Test]
        public void DownloadSoftware()
        {
            var mainPage = new MainPage(_driver, _actions, _wait);
            mainPage.GoToMainPage();
            mainPage.CloseAlert();
            mainPage.EngineSoftwareClick();
            var softwareEngine = new SoftwareEngine(_driver);
            Assert.IsTrue(softwareEngine.CheckFileDownloaded("SteelSeriesGG12.2.0Setup.exe"));
        }

        // [TearDown]
        // public void CloseBrowser()
        // {
        //     _driver.Quit();
        // }
    }
}
