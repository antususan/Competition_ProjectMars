using MarsCompetition.Pages;
using MarsCompetition.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace MarsCompetition.Tests
{

    [TestFixture]
    public class EducationTests : CommonDriver
    {
        ProfilePage profilePageObj;
        JsonHelper jsonHelperObj;
        EducationPage educationPageObj;

        public EducationTests()
        {
            educationPageObj = new EducationPage();
            profilePageObj = new ProfilePage();
        }

        [Test, Order(1)]
        public void CreateEducationWithValidData()
        {
            
            test = extent.CreateTest("CreateEducationWithValidData").Info("Test 1- CreateEducationWithValidData Started");
           
              
            
            profilePageObj.GoToEducationTab();
            educationPageObj.ResetEducationRow();
            string AddEducationUsingValidDataPath = "D:\\Test Analyst\\ProjectMars\\NewCompetitionTask_ProjectMars\\Competition_ProjectMars\\Competition_ProjectMars\\JsonDatas\\EducationDatas\\AddEducationUsingValidDatas.json";
            jsonHelperObj = new JsonHelper(AddEducationUsingValidDataPath);
            var AddEducationWithValidData = jsonHelperObj.ReadAddEducationUsingValidData();
            foreach (var item in AddEducationWithValidData)
            {
                educationPageObj.CreateEducationRecordUsingValidData(item.UniversityName, item.Country, item.Title, item.Degree, item.Yearofgraduation);
                string uniName = educationPageObj.AssertUniversityName();
                string country = educationPageObj.AssertCountryName();
                string title = educationPageObj.AssertTitleName();
                string degree = educationPageObj.AssertDegreeName();
                string year = educationPageObj.AssertYear();
                Assert.That(uniName == item.UniversityName, "University Name is not added sucessfully");
                Assert.That(country == item.Country, "Country is not added successfully");
                Assert.That(title == item.Title, "Title is not added sucessfully");
                Assert.That(degree == item.Degree, "Degree is not added sucessfully");
                Assert.That(year == item.Yearofgraduation, "Year is not added sucessfully");
            }
            string screenshotPath = TakeScreenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "Test-1 Passed");
        }

        [Test, Order(2)]
        public void CreateEducationwithExistingData()
        {
            test = extent.CreateTest("CreateEducationwithExistingData").Info("Test 2- CreateEducationwithExistingData Started");
           
            profilePageObj.GoToEducationTab();
            educationPageObj.ResetEducationRow();
            string AddEducationwithExisitingDataPath = "D:\\Test Analyst\\ProjectMars\\NewCompetitionTask_ProjectMars\\Competition_ProjectMars\\Competition_ProjectMars\\JsonDatas\\EducationDatas\\Add EducationUsingExistingData.json";
            jsonHelperObj = new JsonHelper(AddEducationwithExisitingDataPath);
            var AddEducationWithExistingData = jsonHelperObj.ReadAddEducationUsingExistingData();

            foreach (var item in AddEducationWithExistingData)
            {
                //profilePageObj.ResetEducationRow();
                educationPageObj.CreateEducationUsingExistingData(item.UniversityName, item.Country, item.Title, item.Degree, item.Yearofgraduation);
                educationPageObj.CreateEducationUsingExistingData(item.UniversityName, item.Country, item.Title, item.Degree, item.Yearofgraduation);
                Thread.Sleep(2000);
                string popupmessage = educationPageObj.PopUpMessage();
                Thread.Sleep(4000);
                Assert.That(popupmessage == item.PopUpMessage, "Education with Existing Data added Successfully");
            }
            string screenshotPath = TakeScreenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "Test-2 Passed");

        }
        [Test, Order(3)]

        public void CreateEducationWithDifferentYear()
        {
            test = extent.CreateTest("CreateEducationWithDifferentYear").Info("Test 3- CreateEducationWithDifferentYear Started");
            
            profilePageObj.GoToEducationTab();
            educationPageObj.ResetEducationRow();
            string AddEducationWithDifferentYearDataPath = "D:\\Test Analyst\\ProjectMars\\NewCompetitionTask_ProjectMars\\Competition_ProjectMars\\Competition_ProjectMars\\JsonDatas\\EducationDatas\\AddEducationWithDifferentYear.json";
            jsonHelperObj = new JsonHelper(AddEducationWithDifferentYearDataPath);
            var AddEducationWithDifferentYearData = jsonHelperObj.ReadAddEducationUsingDifferentYearData();
            foreach (var item in AddEducationWithDifferentYearData)
            {
                educationPageObj.createEducationWithDifferentYear(item.UniversityName, item.Country, item.Title, item.Degree, item.Yearofgraduation);
                educationPageObj.createEducationWithDifferentYear(item.UniversityNameNew, item.CountryNew, item.TitleNew, item.DegreeNew, item.YearofgraduationNew);
                Thread.Sleep(5000);
                string popupmessage = educationPageObj.PopUpMessage();
                Wait.Waittobevisible(driver, "xpath", "//*[@class='ns-box-inner']", 2);
                Assert.That(popupmessage == item.PopUpMessage, "Education With Different Year added Successfully");

            }
            string screenshotPath = TakeScreenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "Test-3 Passed");
        }

        [Test, Order(4)]

        public void CreateEducationWithInvalidData()
        {
            test = extent.CreateTest("CreateEducationWithInvalidData").Info("Test 4- CreateEducationWithInvalidData Started");
           
            profilePageObj.GoToEducationTab();
            educationPageObj.ResetEducationRow();
            string AddEducationWithInvalidDataPath = "D:\\Test Analyst\\ProjectMars\\NewCompetitionTask_ProjectMars\\Competition_ProjectMars\\Competition_ProjectMars\\JsonDatas\\EducationDatas\\AddEducationUsingInvalidDatas.json";
            jsonHelperObj = new JsonHelper(AddEducationWithInvalidDataPath);
            var AddEducationWithInvalidData = jsonHelperObj.ReadAddEducationUsingDifferentYearData();

            foreach (var item in AddEducationWithInvalidData)
            {
                //profilePageObj.ResetEducationRow();
                educationPageObj.createEducationWithInvalidData(item.UniversityName, item.Country, item.Title, item.Degree, item.Yearofgraduation);
                string popupmessage = educationPageObj.PopUpMessage();
                Thread.Sleep(5000);
                Assert.That(popupmessage == item.PopUpMessage, "Education With Invalid Data added Successfully");
                Thread.Sleep(2000);
                educationPageObj.CancelButton();
            }
            string screenshotPath = TakeScreenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "Test-4 Passed");
        }

        [Test, Order(5)]
        public void EditExistingEducationData()
        {
            test = extent.CreateTest("EditExistingEducationData").Info("Test 5- EditExistingEducationData Started");
           
            profilePageObj.GoToEducationTab();
            educationPageObj.ResetEducationRow();
            string UpdateAnExistingEducationDataPath = "D:\\Test Analyst\\ProjectMars\\NewCompetitionTask_ProjectMars\\Competition_ProjectMars\\Competition_ProjectMars\\JsonDatas\\EducationDatas\\UpdateAnExistingEducationData.json";
            jsonHelperObj = new JsonHelper(UpdateAnExistingEducationDataPath);
            var UpdateAnExistingEducationData = jsonHelperObj.ReadUpdateAnExisitngEducationData();
            foreach (var item in UpdateAnExistingEducationData)
            {
                educationPageObj.CreateEducationRecordUsingValidData(item.UniversityName, item.Country, item.Title, item.Degree, item.Yearofgraduation);
                educationPageObj.UpdateAnExistingEducationData(item.UniversityNameNew, item.CountryNew, item.TitleNew, item.DegreeNew, item.YearofgraduationNew);
                
                string uniName = educationPageObj.AssertUniversityName();
                string country = educationPageObj.AssertCountryName();
                string title = educationPageObj.AssertTitleName();
                string degree = educationPageObj.AssertDegreeName();
                string year = educationPageObj.AssertYear();
                Assert.That(uniName == item.UniversityNameNew, "University Name is not updated sucessfully");
                Assert.That(country == item.CountryNew, "Country is not updated successfully");
                Assert.That(title == item.TitleNew, "Title is not updated sucessfully");
                Assert.That(degree == item.DegreeNew, "Degree is not updated sucessfully");
                Assert.That(year == item.YearofgraduationNew, "Year is not updated sucessfully");
                //Thread.Sleep(2000);
            }
            string screenshotPath = TakeScreenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "Test-5 Passed");

        }
        [Test, Order(6)]
        public void DeleteEducation()
        {
            test = extent.CreateTest("DeleteEducation").Info("Test 6- DeleteEducation Started");
            
            profilePageObj.GoToEducationTab();
            educationPageObj.ResetEducationRow();
            string DeleteEducationDataPath = "D:\\Test Analyst\\ProjectMars\\NewCompetitionTask_ProjectMars\\Competition_ProjectMars\\Competition_ProjectMars\\JsonDatas\\EducationDatas\\DeleteEducationData.json";
            jsonHelperObj = new JsonHelper(DeleteEducationDataPath);
            var DeleteEducationDatas = jsonHelperObj.ReadDeleteEducationData();
            foreach (var item in DeleteEducationDatas)
            {
                educationPageObj.DeleteEducationData(item.UniversityName, item.Country, item.Title, item.Degree, item.Yearofgraduation);
                educationPageObj.DeleteButton();
                
                string popupmessage = educationPageObj.PopUpMessage();
                Thread.Sleep(4000);
                Assert.That(popupmessage == item.PopUpMessage, "Record has not been deleted Sucessfully");
            }
            string screenshotPath = TakeScreenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "Test-6 Passed");

        }
    }
}



