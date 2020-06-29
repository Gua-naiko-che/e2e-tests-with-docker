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
            string driverDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            using (var driver = new ChromeDriver(driverDirectory))
            {
                driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Climate_apocalypse");
                By titleSelector = By.CssSelector("#firstHeading");
                IWebElement title = driver.FindElement(titleSelector);
                Assert.Equal("Climate apocalypse", title.Text);
            }

        }
    }
}
