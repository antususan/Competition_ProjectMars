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
    public class EducationPage:CommonDriver
    {
        private IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        private IWebElement collegeTextBox => driver.FindElement(By.XPath("//input[@placeholder='College/University Name']"));
        private IWebElement selectCountry => driver.FindElement(By.XPath("//select[@name='country']"));
        private IWebElement selectTitle => driver.FindElement(By.XPath("//select[@name='title']"));
        private IWebElement degreeTextBox => driver.FindElement(By.XPath("//input[@name='degree']"));
        private IWebElement selectYear => driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
        private IWebElement addButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement UniversityName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

        private IWebElement countryName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement deleteEducationButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i"));

        private IWebElement titleName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"));

        private IWebElement degree => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]"));

        private IWebElement year => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]"));

        private IWebElement cancelButton => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[2]"));

        private IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i"));

        private IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]"));

        public void ResetEducationRow()
        {
            Thread.Sleep(2000);
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr")).Count;

            for (int i = 0; i < rowCount; i++)
            {
                Thread.Sleep(2000);
                deleteEducationButton.Click();

            }
        }

        public void CreateEducationRecordUsingValidData(string UniversityName, string Country, string Title, string Degree, string Yearofgraduation)
        {

            addNewButton.Click();
            collegeTextBox.SendKeys(UniversityName);
            SelectElement countryDropDown = new SelectElement(selectCountry);
            countryDropDown.SelectByValue(Country);

            SelectElement titleDropDown = new SelectElement(selectTitle);
            titleDropDown.SelectByValue(Title);

            degreeTextBox.SendKeys(Degree);
            //SelectElement yearOfGraduation = new SelectElement(driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")));
            SelectElement yearOfGraduation = new SelectElement(selectYear);
            yearOfGraduation.SelectByValue(Yearofgraduation);
            addButton.Click();

        }
        public string AssertUniversityName()
        {

            Thread.Sleep(1000);
            return UniversityName.Text;
        }
        public string AssertCountryName()
        {
            Thread.Sleep(1000);
            return countryName.Text;
        }
        public string AssertTitleName()
        {
            Thread.Sleep(1000);
            return titleName.Text;
        }

        public string AssertDegreeName()
        {
            Thread.Sleep(1000);
            return degree.Text;
        }

        public string AssertYear()
        {
            Thread.Sleep(1000);
            return year.Text;
        }

        private IWebElement popUpMessage => driver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
        public string PopUpMessage()
        {
            //Wait.Waittobevisible(driver, "xpath", "//*[@class='ns-box-inner']",2 );
            return popUpMessage.Text;


        }

        public void CreateEducationUsingExistingData(string UniversityName, string Country, string Title, string Degree, string Yearofgraduation)
        {
            addNewButton.Click();
            Thread.Sleep(2000);
            collegeTextBox.SendKeys(UniversityName);
            SelectElement countryDropDown = new SelectElement(selectCountry);
            countryDropDown.SelectByValue(Country);

            SelectElement titleDropDown = new SelectElement(selectTitle);
            titleDropDown.SelectByValue(Title);

            degreeTextBox.SendKeys(Degree);
            //SelectElement yearOfGraduation = new SelectElement(driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")));
            SelectElement yearOfGraduation = new SelectElement(selectYear);
            yearOfGraduation.SelectByValue(Yearofgraduation);
            addButton.Click();
        }

        public void createEducationWithDifferentYear(string UniversityName, string Country, string Title, string Degree, string Yearofgraduation)
        {
            addNewButton.Click();
            Thread.Sleep(3000);
            collegeTextBox.SendKeys(UniversityName);
            SelectElement countryDropDown = new SelectElement(selectCountry);
            countryDropDown.SelectByValue(Country);

            SelectElement titleDropDown = new SelectElement(selectTitle);
            titleDropDown.SelectByValue(Title);

            degreeTextBox.SendKeys(Degree);
            //SelectElement yearOfGraduation = new SelectElement(driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")));
            SelectElement yearOfGraduation = new SelectElement(selectYear);
            yearOfGraduation.SelectByValue(Yearofgraduation);
            addButton.Click();
        }

        public void createEducationWithInvalidData(string UniversityName, string Country, string Title, string Degree, string Yearofgraduation)
        {
            addNewButton.Click();
            collegeTextBox.SendKeys(UniversityName);
            SelectElement countryDropDown = new SelectElement(selectCountry);
            countryDropDown.SelectByValue(Country);
            SelectElement titleDropDown = new SelectElement(selectTitle);
            titleDropDown.SelectByValue(Title);
            degreeTextBox.SendKeys(Degree);
            //SelectElement yearOfGraduation = new SelectElement(driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")));
            SelectElement yearOfGraduation = new SelectElement(selectYear);
            yearOfGraduation.SelectByValue(Yearofgraduation);
            addButton.Click();

        }
        public void CancelButton()
        {
            cancelButton.Click();
        }
        public void UpdateAnExistingEducationData(string UniversityName, string Country, string Title, string Degree, string Yearofgraduation)
        {
            Thread.Sleep(2000);
            editButton.Click();
            collegeTextBox.Clear();
            collegeTextBox.SendKeys(UniversityName);
            SelectElement countryDropDown = new SelectElement(selectCountry);
            countryDropDown.SelectByValue(Country);
            SelectElement titleDropDown = new SelectElement(selectTitle);
            titleDropDown.SelectByValue(Title);
            degreeTextBox.Clear();
            degreeTextBox.SendKeys(Degree);
            //SelectElement yearOfGraduation = new SelectElement(driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")));
            SelectElement yearOfGraduation = new SelectElement(selectYear);
            yearOfGraduation.SelectByValue(Yearofgraduation);
            updateButton.Click();

        }
        public void DeleteEducationData(string UniversityName, string Country, string Title, string Degree, string Yearofgraduation)
        {
            addNewButton.Click();
            collegeTextBox.SendKeys(UniversityName);
            SelectElement countryDropDown = new SelectElement(selectCountry);
            countryDropDown.SelectByValue(Country);
            SelectElement titleDropDown = new SelectElement(selectTitle);
            titleDropDown.SelectByValue(Title);
            degreeTextBox.SendKeys(Degree);
            //SelectElement yearOfGraduation = new SelectElement(driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")));
            SelectElement yearOfGraduation = new SelectElement(selectYear);
            yearOfGraduation.SelectByValue(Yearofgraduation);
            addButton.Click();
            Thread.Sleep(2000);
        }
        public void DeleteButton()
        {
            deleteEducationButton.Click();
            Thread.Sleep(2000);
        }



    }
}
