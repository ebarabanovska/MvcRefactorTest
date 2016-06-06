using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MvcRefactorTest.SeleniumTest
{
    internal static class SeleniumSetMethods
    {
        /// <summary>
        ///     Enter Text.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="value">Value to be set.</param>
        /// <param name="elementType">Element Type.</param>
        public static void EnterText(string element, string value, PropertyType elementType)
        {
            switch (elementType)
            {
                case PropertyType.Id:
                    PropertiesCollection.Driver.FindElement(By.Id(element)).SendKeys(value);
                    break;
                case PropertyType.Name:
                    PropertiesCollection.Driver.FindElement(By.Name(element)).SendKeys(value);
                    break;
            }
        }

        /// <summary>
        ///     Click.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="elementType">Element Type.</param>
        public static void Click(string element, PropertyType elementType)
        {
            switch (elementType)
            {
                case PropertyType.Id:
                    PropertiesCollection.Driver.FindElement(By.Id(element)).Click();
                    break;
                case PropertyType.Name:
                    PropertiesCollection.Driver.FindElement(By.Name(element)).Click();
                    break;
            }
        }

        /// <summary>
        ///     Select DropDown.
        /// </summary>
        /// <param name="element">Element to be selected.</param>
        /// <param name="value">Value to be set.</param>
        /// <param name="elementType">Element Type.</param>
        public static void SelectDropDown(string element, string value, PropertyType elementType)
        {
            switch (elementType)
            {
                case PropertyType.Id:
                    new SelectElement(PropertiesCollection.Driver.FindElement(By.Id(element))).SelectByText(value);
                    break;
                case PropertyType.Name:
                    new SelectElement(PropertiesCollection.Driver.FindElement(By.Name(element))).SelectByText(value);
                    break;
            }
        }
    }
}