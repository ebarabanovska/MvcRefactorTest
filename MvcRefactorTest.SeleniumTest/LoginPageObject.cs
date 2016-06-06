using System;

using MvcRefactorTest.SeleniumTest;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTest
{
    internal class LoginPageObject
    {
        public LoginPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }

        [FindsBy(How = How.Name, Using = "btnLogin")]
        public IWebElement BtnLogin { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement TxtUserName { get; set; }

        public HomePageObject Login(string initial, string firstName)
        {
            try
            {
                // populate username
                this.TxtUserName.SendKeys(initial);

                // populate password
                this.TxtPassword.SendKeys(firstName);

                // initiate click
                this.BtnLogin.Click();
            }
            catch (Exception)
            {
                // ignored
            }

            return new HomePageObject();
        }
    }
}