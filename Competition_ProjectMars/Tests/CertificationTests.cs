using AventStack.ExtentReports;
using MarsCompetition.Pages;
using MarsCompetition.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetition.Tests
{
    [TestFixture]
    public class CertificationTests : CommonDriver
    {
        ProfilePage profilePageObj;
        JsonHelper jsonHelperObj;

        [Test, Order(1)]
        public void CreateCertificateWithValidData()
        {
            test = extent.CreateTest("CreateCertificateWithValidData").Info("Test 1- CreateCertificateWithValidData Started");
            profilePageObj = new ProfilePage();
            profilePageObj.GoToCertificationsTab();
            //Thread.Sleep(1000);
            profilePageObj.ResetCertificateRow();

            string AddCertificateWithValidDataPath = "D:\\Test Analyst\\ProjectMars\\ProjectMars_Competition\\MarsCompetition\\JsonDatas\\CertificationsDatas\\AddCertificateWithValidData.json";
            jsonHelperObj = new JsonHelper(AddCertificateWithValidDataPath);
            var AddCertificateWithValidData = jsonHelperObj.ReadAddCertificateWithValidData();
            foreach (var item in AddCertificateWithValidData)
            {
                profilePageObj.CreateCertificateWithValidData(item.Certificate, item.From, item.Year);
                
                string certificate = profilePageObj.AssertCertificate();
                string from = profilePageObj.AssertFrom();
                string year = profilePageObj.AssertCertifiedYear();

                Assert.That(certificate == item.Certificate, "Certificate Name is not added sucessfully");
                Assert.That(from == item.From, "Certified from is not added successfully");
                Assert.That(year == item.Year, "Certified Year is not added sucessfully");
            }
            string screenshotPath = TakeScreenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "Test-1 Passed");

        }
        [Test, Order(2)]

        public void CreateCertificatewithExistingData()
        {
            test = extent.CreateTest("CreateCertificatewithExistingData").Info("Test 2- CreateCertificatewithExistingData Started");
            profilePageObj = new ProfilePage();
            profilePageObj.GoToCertificationsTab();
            //Thread.Sleep(1000);
            profilePageObj.ResetCertificateRow();

            string AddCertificateWithExistingDataPath = "D:\\Test Analyst\\ProjectMars\\ProjectMars_Competition\\MarsCompetition\\JsonDatas\\CertificationsDatas\\AddCertificateWithExistingData.json";
            jsonHelperObj = new JsonHelper(AddCertificateWithExistingDataPath);
            var AddCertificateWithExistingData = jsonHelperObj.ReadAddCertificateWithExistingData();
            foreach (var item in AddCertificateWithExistingData)
            {
                profilePageObj.CreateCertificateWithExistingData(item.Certificate, item.From, item.Year);
                profilePageObj.CreateCertificateWithExistingData(item.Certificate, item.From, item.Year);

               Thread.Sleep(3000);
                string popupmessage = profilePageObj.PopUpMessage();
               
                //Thread.Sleep(80000);
                Assert.That(popupmessage == item.PopUpMessage, "Certification with Existing Data added Successfully");
            }
            string screenshotPath = TakeScreenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "Test-2 Passed");

        }
        [Test, Order(3)]
        public void CreateCertificateWithDifferentYear()
        {
            test = extent.CreateTest("CreateCertificateWithDifferentYear").Info("Test 3- CreateCertificateWithDifferentYear Started");
            profilePageObj = new ProfilePage();
            profilePageObj.GoToCertificationsTab();
            //Thread.Sleep(1000);
            profilePageObj.ResetCertificateRow();

            string AddCertificateWithDifferentYearDataPath = "D:\\Test Analyst\\ProjectMars\\ProjectMars_Competition\\MarsCompetition\\JsonDatas\\CertificationsDatas\\AddCertificateWithDifferentYear.json";
            jsonHelperObj = new JsonHelper(AddCertificateWithDifferentYearDataPath);
            var AddCertificateWithDifferentYearData = jsonHelperObj.ReadAddCertificateWithDifferentYearData();
            foreach (var item in AddCertificateWithDifferentYearData)
            {
                profilePageObj.CreateCertificateWithDifferentYear(item.Certificate, item.From, item.Year);
                profilePageObj.CreateCertificateWithDifferentYear(item.CertificateNew, item.FromNew, item.YearNew);

                Thread.Sleep(4000);
                string popupmessage = profilePageObj.PopUpMessage();

                Assert.That(popupmessage == item.PopUpMessage, "Certification with Existing Data added Successfully");
            }
            string screenshotPath = TakeScreenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "Test-3 Passed");

        }

        [Test, Order(4)]
        public void CreateCertificateWithInvalidData()
        {
            test = extent.CreateTest("CreateCertificateWithInvalidData").Info("Test 4- CreateCertificateWithInvalidData Started");

            profilePageObj = new ProfilePage();
            profilePageObj.GoToCertificationsTab();
            //Thread.Sleep(1000);
            profilePageObj.ResetCertificateRow();

            string AddCertificateWithInvalidDataPath = "D:\\Test Analyst\\ProjectMars\\ProjectMars_Competition\\MarsCompetition\\JsonDatas\\CertificationsDatas\\AddCertificateWithInvalidData.json";
            jsonHelperObj = new JsonHelper(AddCertificateWithInvalidDataPath);
            var AddCertificateWithInvalidData = jsonHelperObj.ReadAddCertificateWithInvalidData();
            foreach (var item in AddCertificateWithInvalidData)
            {
                profilePageObj.CreateCertificateWithDifferentYear(item.Certificate, item.From, item.Year);
                //profilePageObj.CreateCertificateWithDifferentYear(item.CertificateNew, item.FromNew, item.YearNew);

                Thread.Sleep(2000);
                string popupmessage = profilePageObj.PopUpMessage();

                Assert.That(popupmessage == item.PopUpMessage, "Certification with Existing Data added Successfully");
                profilePageObj.CerCancelButton();
            }
            string screenshotPath = TakeScreenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "Test-4 Passed"); 
        }
        [Test, Order(5)]
        public void EditExistingCertificationData()
        {
            test = extent.CreateTest("EditExistingCertificationData").Info("Test 5- EditExistingCertificationData Started");

            profilePageObj = new ProfilePage();
            profilePageObj.GoToCertificationsTab();
            //Thread.Sleep(1000);
            profilePageObj.ResetCertificateRow();

            string UpdateCertificationDataPath = "D:\\Test Analyst\\ProjectMars\\ProjectMars_Competition\\MarsCompetition\\JsonDatas\\CertificationsDatas\\UpdateAnExistingCertificationData.json";
            jsonHelperObj = new JsonHelper(UpdateCertificationDataPath);
            var UpdateCertificationData = jsonHelperObj.ReadUpdateCertificationData();
            foreach (var item in UpdateCertificationData)
            {
                profilePageObj.CreateCertificateWithValidData(item.Certificate, item.From, item.Year);
                profilePageObj.UpdateAnExistingCertificationData(item.CertificateNew, item.FromNew, item.YearNew);
                Thread.Sleep(2000);
                string certificate = profilePageObj.AssertCertificate();
                string from = profilePageObj.AssertFrom();
                string year = profilePageObj.AssertCertifiedYear();

                Assert.That(certificate == item.CertificateNew, "Certificate Name is not updated sucessfully");
                Assert.That(from == item.FromNew, "Certified from is not updated sucessfully");
                Assert.That(year == item.YearNew, "Certified Year is not updated sucessfully");
            }
            string screenshotPath = TakeScreenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "Test-5 Passed");

        }
        [Test, Order(6)]
        public void DeleteCertificationData()
        {
            test = extent.CreateTest("DeleteCertificationData").Info("Test 6- DeleteCertificationData Started");

            profilePageObj = new ProfilePage();
            profilePageObj.GoToCertificationsTab();
            //Thread.Sleep(1000);
            profilePageObj.ResetCertificateRow();

            string DeleteCertificationDataPath = "D:\\Test Analyst\\ProjectMars\\ProjectMars_Competition\\MarsCompetition\\JsonDatas\\CertificationsDatas\\DeleteCertificationData.json";
            jsonHelperObj = new JsonHelper(DeleteCertificationDataPath);
            var DeleteCertificationData = jsonHelperObj.ReadDeleteCertificationData();
            foreach (var item in DeleteCertificationData)
            {
                profilePageObj.DeleteCertificationData(item.Certificate, item.From, item.Year);
                profilePageObj.DeleteCerButton();
                string popupmessage = profilePageObj.PopUpMessage();
                Thread.Sleep(2000);
                Assert.That(popupmessage == item.PopUpMessage, "Record has not been deleted Sucessfully");
            }
            string screenshotPath = TakeScreenshot(driver);
            test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            test.Log(Status.Pass, "Test-6 Passed");

        }
       

    }
}




