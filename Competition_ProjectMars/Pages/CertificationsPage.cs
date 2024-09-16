using MarsCompetition.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetition.Pages
{
    public class CertificationsPage:CommonDriver
    {
        private IWebElement addNewCerButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        private IWebElement certificateOrAwardTextBox => driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']"));
        private IWebElement certifiedFromTextBox => driver.FindElement(By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']"));
        private IWebElement selectCertifiedYear => driver.FindElement(By.XPath("//select[@name='certificationYear']"));
        private IWebElement addCertButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        private IWebElement certificateName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement fromName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));

        private IWebElement certifiedYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]"));
        private IWebElement deleteCertificateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]/i"));
        private IWebElement certificateCancelButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[2]"));

        private IWebElement editCerButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i"));
        private IWebElement updateCerButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]"));


        public void ResetCertificateRow()
        {
            Thread.Sleep(1000);
            int rowCount = driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr")).Count;

            for (int i = 0; i < rowCount; i++)
            {
                Thread.Sleep(1000);
                deleteCertificateButton.Click();
            }
        }
        public void CreateCertificateWithValidData(string certificate, string from, string year)
        {
            //Thread.Sleep(2000);
            addNewCerButton.Click();
            certificateOrAwardTextBox.SendKeys(certificate);
            certifiedFromTextBox.SendKeys(from);
            SelectElement yearDropDown = new SelectElement(selectCertifiedYear);
            yearDropDown.SelectByValue(year);
            addCertButton.Click();
        }
        public string AssertCertificate()
        {
            Thread.Sleep(3000);
            return certificateName.Text;
        }
        public string AssertFrom()
        {
            Wait.Waittobevisible(driver, "Xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]", 2);
            return fromName.Text;
        }
        public string AssertCertifiedYear()
        {
            Wait.Waittobevisible(driver, "xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]", 2);
            return certifiedYear.Text;
        }

        private IWebElement popUpMessage => driver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
        public string PopUpMessage()
        {
            //Wait.Waittobevisible(driver, "xpath", "//*[@class='ns-box-inner']",2 );
            return popUpMessage.Text;


        }

        public void CreateCertificateWithExistingData(string certificate, string from, string year)
        {
            //Thread.Sleep(2000);
            addNewCerButton.Click();
            Thread.Sleep(1000);
            certificateOrAwardTextBox.SendKeys(certificate);
            certifiedFromTextBox.SendKeys(from);
            SelectElement yearDropDown = new SelectElement(selectCertifiedYear);
            yearDropDown.SelectByValue(year);
            addCertButton.Click();
            // Thread.Sleep(2000);
        }
        public void CreateCertificateWithDifferentYear(string certificate, string from, string year)
        {
            addNewCerButton.Click();
            Thread.Sleep(1000);
            certificateOrAwardTextBox.SendKeys(certificate);
            certifiedFromTextBox.SendKeys(from);
            SelectElement yearDropDown = new SelectElement(selectCertifiedYear);
            yearDropDown.SelectByValue(year);
            addCertButton.Click();
        }
        public void CreateCertificateWithInvalidData(string certificate, string from, string year)
        {
            addNewCerButton.Click();
            certificateOrAwardTextBox.SendKeys(certificate);
            certifiedFromTextBox.SendKeys(from);
            SelectElement yearDropDown = new SelectElement(selectCertifiedYear);
            yearDropDown.SelectByValue(year);
            addCertButton.Click();
        }

        public void CerCancelButton()
        {
            Thread.Sleep(1000);
            certificateCancelButton.Click();
        }
        public void UpdateAnExistingCertificationData(string certificate, string from, string year)
        {
            Thread.Sleep(4000);
            editCerButton.Click();
            certificateOrAwardTextBox.Clear();
            certificateOrAwardTextBox.SendKeys(certificate);
            certifiedFromTextBox.Clear();
            certifiedFromTextBox.SendKeys(from);
            SelectElement yearDropDown = new SelectElement(selectCertifiedYear);
            yearDropDown.SelectByValue(year);
            updateCerButton.Click();


        }
        public void DeleteCertificationData(string certificate, string from, string year)
        {

            addNewCerButton.Click();
            certificateOrAwardTextBox.SendKeys(certificate);
            certifiedFromTextBox.SendKeys(from);
            SelectElement yearDropDown = new SelectElement(selectCertifiedYear);
            yearDropDown.SelectByValue(year);
            addCertButton.Click();
            Thread.Sleep(4000);
        }
        public void DeleteCerButton()
        {
            deleteCertificateButton.Click();
            Thread.Sleep(2000);

        }

    }
}
