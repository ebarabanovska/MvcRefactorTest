using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    enum PropertyType
    {
        Id,
        Name,
        LinkedText,
        CssName,
        ClassName
    }
    
    class PropertiesCollection
    { 
        /// <summary>
        /// Gets or sets the driver.
        /// </summary>
        /// <value>The driver.</value>
        public static IWebDriver driver { get ; set ; }
    }
}