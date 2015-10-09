using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    
    class LoginPageObject
    {
        public LoginPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Name, Using = "btnLogin")]
        public IWebElement btnLogin { get; set; }

        public HomePageObject Login(string initial, string firstName)
        {
            try
            {
                //populate username
                txtUserName.SendKeys(initial);

                //populate password
                txtPassword.SendKeys(firstName);

                //initiate click
                btnLogin.Click();
            }
            catch { }
            return new HomePageObject();
        }
    }
}