using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    class SeleniumSetMethods
    {
        /// <summary>
        /// Entered Text
        /// </summary>
        /// <param name="PropertiesCollection.driver"></param>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// <param name="elementType"></param>
        public static void EnterText(string element, string value, PropertyType elementType)
        {
            switch (elementType)
            {
                case PropertyType.Id:
                    PropertiesCollection.driver.FindElement(By.Id(element)).SendKeys(value);
                    break;
                case PropertyType.Name:
                    PropertiesCollection.driver.FindElement(By.Name(element)).SendKeys(value);                    
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Click 
        /// </summary>
        /// <param name="PropertiesCollection.driver"></param>
        /// <param name="element"></param>
        /// <param name="elementType"></param>
        public static void Click(string element, PropertyType elementType)
        {
            switch (elementType)
            {
                case PropertyType.Id:
                    PropertiesCollection.driver.FindElement(By.Id(element)).Click();
                    break;
                case PropertyType.Name:
                    PropertiesCollection.driver.FindElement(By.Name(element)).Click();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Select DropDown value
        /// </summary>
        /// <param name="PropertiesCollection.driver"></param>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// <param name="elementType"></param>
        public static void SelectDropDown(string element, string value, PropertyType elementType)
        { 
            switch (elementType)
            {
                case PropertyType.Id:
                    new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).SelectByText(value);
                    break;
                case PropertyType.Name:
                    new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).SelectByText(value);
                    break;
                default:
                    break;
            }
        }
    }
}