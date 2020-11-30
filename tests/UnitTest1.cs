namespace tests
{
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
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "chromedriver");
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            using var driver = new ChromeDriver(service, options);

            driver.Navigate().GoToUrl("http://webapp:80");
            By titleSelector = By.CssSelector("h1");
            IWebElement title = driver.FindElement(titleSelector);
            Assert.Equal("Welcome", title.Text);
        }
    }
}
