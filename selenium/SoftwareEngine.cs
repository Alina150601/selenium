using System;
using System.IO;
using System.Linq;
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

        [CacheLookup]
        [FindsBy(How = How.XPath, Using = "//*[@class='button button--solid button--white js-gg-download-button']")]
        private IWebElement DownloadForWindows { get; set; }

        public void DownloadForWindowsClick()
        {
            DownloadForWindows.Click();
        }

        public  bool CheckFileDownloaded(string filename)
        {
            var exist = false;
            var Path = String.Empty;
            try
            {
                if (Environment.GetEnvironmentVariable("USERPROFILE") == null)
                {
                    throw new InvalidOperationException("Environment variable 'USERPROFILE' is not found");
                }
                Path = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            }
            catch (Exception)
            {
                Path = "/Users/malinka/Downloads/";
            }
            var filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if(p.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                        thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                        thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                        thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        exist = true;
                    File.Delete(p);
                    break;
                }
            }
            return exist;
        }
    }
}
