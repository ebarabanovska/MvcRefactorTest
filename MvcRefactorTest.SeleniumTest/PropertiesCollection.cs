using OpenQA.Selenium;

namespace MvcRefactorTest.SeleniumTest
{
    internal enum PropertyType
    {
        Id, 

        Name, 

        LinkedText, 

        CssName, 

        ClassName
    }

    internal static class PropertiesCollection
    {
        /// <summary>
        ///     Gets or sets the driver.
        /// </summary>
        /// <value>The driver.</value>
        public static IWebDriver Driver { get; set; }
    }
}