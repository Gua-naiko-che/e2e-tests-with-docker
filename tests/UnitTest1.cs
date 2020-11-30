namespace tests
{
    using OpenQA.Selenium;
    using Xunit;
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            using var driver = Helpers.CreateDriver();
            driver.Navigate().GoToUrl(Helpers.AppRootUrl);
            By titleSelector = By.CssSelector("h1");
            IWebElement title = driver.FindElement(titleSelector);
            Assert.Equal("Welcome", title.Text);
        }
    }
}
