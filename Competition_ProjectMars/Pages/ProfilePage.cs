
using MarsCompetition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics.Metrics;
using static System.Collections.Specialized.BitVector32;

namespace MarsCompetition.Pages
{
    public class ProfilePage:CommonDriver
    {
     

        private IWebElement educationTab => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
        private IWebElement certificationsTab => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
      
        public void GoToEducationTab()
        {
            //Wait.Waittobevisible(driver, "Xpath", "/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 2);
            Thread.Sleep(1000);
            educationTab.Click();
        }
        public void GoToCertificationsTab()
        {
           Thread.Sleep(2000);
           certificationsTab.Click();
        }
       
      
       

        //Certificate Tab 
        
        
    }
}
