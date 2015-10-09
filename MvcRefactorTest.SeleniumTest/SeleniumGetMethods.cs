using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class SeleniumGetMethods
    {
        /// <summary>
        /// Get Text
        /// </summary>
        /// <param name="PropertiesCollection.driver"></param>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// <param name="elementType"></param>
        /// <returns></returns>
        public static string GetText(string element, PropertyType elementType)
        {
            switch (elementType)
            {
                case PropertyType.Id:
                    return PropertiesCollection.driver.FindElement(By.Id(element)).GetAttribute("value");
                case PropertyType.Name:
                    return PropertiesCollection.driver.FindElement(By.Name(element)).GetAttribute("value");
                default:
                    return string.Empty;
            }
        }

        public static string GetTextFromDropDownList(string element, PropertyType elementType)
        {
            switch (elementType)
            {
                case PropertyType.Id:
                    return new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
                case PropertyType.Name:
                    return new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
                default:
                    return string.Empty;
            }
        }
    }
}