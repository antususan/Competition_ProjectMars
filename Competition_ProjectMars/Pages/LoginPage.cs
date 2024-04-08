using MarsCompetition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetition.Pages
{
    public class LoginPage:CommonDriver
    {
        private IWebDriver webDriver;
        public LoginPage()
        {
            webDriver = driver;
        }
        private IWebElement signInButton => webDriver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private IWebElement emailTextBox => webDriver.FindElement(By.Name("email"));
        private IWebElement passwordTextBox => webDriver.FindElement(By.Name("password"));
        private IWebElement loginButton => webDriver.FindElement(By.XPath("//button[contains(text(),'Login')]"));

        public void LoginActions( string EmailId, string Password)
        {
            //driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl("http://localhost:5000/");
            signInButton.Click();
            emailTextBox.SendKeys(EmailId);
            Wait.Waittobevisible(driver, "Name", "password", 5);
            passwordTextBox.SendKeys(Password);
            loginButton.Click();
        }

    }
}
