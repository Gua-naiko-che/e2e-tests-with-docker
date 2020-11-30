namespace tests
{
    using System;
    using System.IO;
    using System.Reflection;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Xunit;
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            bool inDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
            var driverFileName = inDocker ? "chromedriver" : "chromedriver.exe";
            var appRootUrl = inDocker ? "http://webapp:80/" : "https://localhost:5001/";
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), driverFileName);
            var options = new ChromeOptions();
            if (inDocker)
            {
                options.AddArgument("--headless");
                options.AddArgument("--no-sandbox");
            }

            using var driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl(appRootUrl);
            By titleSelector = By.CssSelector("h1");
            IWebElement title = driver.FindElement(titleSelector);
            Assert.Equal("Welcome", title.Text);
        }
    }
}
