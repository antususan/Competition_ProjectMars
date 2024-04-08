
using MarsCompetition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics.Metrics;
using static System.Collections.Specialized.BitVector32;

namespace MarsCompetition.Pages
{
    public class ProfilePage:CommonDriver
    {
        private IWebDriver webDriver;
        public ProfilePage()
        {
            webDriver = driver;
        }

        private IWebElement educationTab => webDriver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
        private IWebElement certificationsTab => webDriver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
        private IWebElement addNewButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        private IWebElement collegeTextBox => webDriver.FindElement(By.XPath("//input[@placeholder='College/University Name']"));
        private IWebElement selectCountry => webDriver.FindElement(By.XPath("//select[@name='country']"));
        private IWebElement selectTitle => webDriver.FindElement(By.XPath("//select[@name='title']"));
        private IWebElement degreeTextBox => webDriver.FindElement(By.XPath("//input[@name='degree']"));
        private IWebElement selectYear => webDriver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
        private IWebElement addButton => webDriver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement UniversityName => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

        private IWebElement countryName => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));                                       
        private IWebElement deleteEducationButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i"));

        private IWebElement titleName => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"));

        private IWebElement degree => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]"));

        private IWebElement year => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]"));

        private IWebElement cancelButton => webDriver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[2]"));

        private IWebElement editButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i"));

        private IWebElement updateButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]"));
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

        private IWebElement popUpMessage => webDriver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
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


        //Certificate Tab 
        
        private IWebElement addNewCerButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        private IWebElement certificateOrAwardTextBox => webDriver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']"));
        private IWebElement certifiedFromTextBox => webDriver.FindElement(By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']"));
        private IWebElement selectCertifiedYear => webDriver.FindElement(By.XPath("//select[@name='certificationYear']"));
        private IWebElement addCertButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        private IWebElement certificateName => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
        private IWebElement fromName => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));

        private IWebElement certifiedYear => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]"));
        private IWebElement deleteCertificateButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]/i"));
        private IWebElement certificateCancelButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[2]"));

        private IWebElement editCerButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i"));
        private IWebElement updateCerButton => webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]"));


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
        public void CreateCertificateWithValidData(string certificate,string from,string year)
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

        public void CreateCertificateWithExistingData(string certificate,string from,string year)
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
        public void CreateCertificateWithDifferentYear(string certificate,string from,string year)
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
