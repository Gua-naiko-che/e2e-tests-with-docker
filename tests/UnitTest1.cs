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
                driver.Navigate().GoToUrl("https://localhost:5001/");
                By titleSelector = By.CssSelector("h1");
                IWebElement title = driver.FindElement(titleSelector);
                Assert.Equal("Welcome", title.Text);
            }
        }
    }
}
