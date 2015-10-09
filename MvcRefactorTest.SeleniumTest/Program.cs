using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
        }
    }

    public class UnitTestApp
    {
        [SetUp]
        public void Initialize()
        {
            //create reference for the chrome browser
            PropertiesCollection.driver = new ChromeDriver();

            PropertiesCollection.driver.Navigate().GoToUrl("http://localhost:56750/Account/Login");
            Console.WriteLine("Opened URL");
        }

        [Test]
        public void ExecuteSetTest()
        {
            //Title
            SeleniumSetMethods.SelectDropDown("TitleId", "Mr.", PropertyType.Id);

            //Initial
            SeleniumSetMethods.EnterText("Initial", "Execute Automation", PropertyType.Name);

            //Click
            SeleniumSetMethods.Click("Save", PropertyType.Name);
        }

        [Test]
        public void ExecuteGetTest()
        {
            //Set Title
            SeleniumSetMethods.SelectDropDown("TitleId", "Mr.", PropertyType.Id);

            //Set Initial
            SeleniumSetMethods.EnterText("Initial", "Execute Automation", PropertyType.Name);

            //Get Title
            Console.WriteLine("The value from my Title is: " + SeleniumGetMethods.GetTextFromDropDownList("TitleId", PropertyType.Id));

            //Get Initial
            Console.WriteLine("The value from my Initial is: " + SeleniumGetMethods.GetText("Initial", PropertyType.Name));
        }
        
        [Test]
        [Category("RunOnlyThis")]
        public void ExecuteLogin()
        {
            //Login to application
            LoginPageObject pageLogin = new LoginPageObject();
            HomePageObject homePage = pageLogin.Login("execute", "automation");

            //Initialize th Page By calling the refference
            //homePage.FillUserForm("Test", "Execute", "Automation");
        }

        [Test]
        public void NextTest()
        {
            //find the element
            IWebElement element = PropertiesCollection.driver.FindElement(By.Name("q"));

            //perform opration
            element.SendKeys("executeoperation");
            Console.WriteLine("Executed Test");
        }

        [TearDown]
        public void CleanUp()
        {
            PropertiesCollection.driver.Close();
            Console.WriteLine("Closed the browser");
        }
    }
}