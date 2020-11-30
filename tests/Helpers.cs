namespace tests
{
    using System;
    using System.IO;
    using System.Reflection;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public static class Helpers
    {
        public static string AppRootUrl => InDocker ? "http://webapp:80/" : "https://localhost:5001/";
        public static IWebDriver CreateDriver()
        {
            var driverFileName = InDocker ? "chromedriver" : "chromedriver.exe";
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), driverFileName);
            var options = new ChromeOptions();
            if (InDocker)
            {
                options.AddArgument("--headless");
                options.AddArgument("--no-sandbox");
            }

            return new ChromeDriver(service, options);
        }
        private static bool InDocker => Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
    }
}
