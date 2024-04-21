using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using MarsCompetition.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetition.Utilities
{
    public class CommonDriver:ExtentHelper
    {
        public static IWebDriver driver;

        [SetUp]
        public void SetUp()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            string loginDataPath = "D:\\Test Analyst\\ProjectMars\\ProjectMars_Competition\\MarsCompetition\\JsonDatas\\LoginDatas\\LoginData.json";
            JsonHelper jsonHelperObj = new JsonHelper(loginDataPath);
            // List<Login> login = new List<Login>();
            LoginPage loginpageObj=  new LoginPage(); 
            var login = jsonHelperObj.ReadLoginData();
             
            foreach (var item in login)
            {
                loginpageObj.LoginActions(item.EmailId, item.Password);
            }

        }

        [OneTimeSetUp]
        
        public void OneTimeSetUp()
        {
            ExtentHelper.ExtentStart();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        [TearDown]
        public void CloseTestRun()
        {

            driver.Quit();

        }

    }
}
