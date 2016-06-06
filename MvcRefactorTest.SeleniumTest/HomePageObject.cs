using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MvcRefactorTest.SeleniumTest
{
    internal class HomePageObject
    {
        public HomePageObject()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }

        [FindsBy(How = How.Name, Using = "Login")]
        public IWebElement BtnLogin { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement TxtUserName { get; set; }
    }
}