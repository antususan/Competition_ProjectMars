using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MarsCompetition.Utilities
{
    public class ExtentHelper
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        public static void ExtentStart()
        {
            if(extent == null) 
            {
                extent = new ExtentReports();
                string reportPath = @"D:\Test Analyst\ProjectMars\NewCompetitionTask_ProjectMars\Competition_ProjectMars\Competition_ProjectMars\ExtentReports\Reports.html";
                var htmlReporter = new ExtentHtmlReporter(reportPath);
                extent.AttachReporter(htmlReporter);

            }
        }
        public string TakeScreenshot(IWebDriver driver)
        {
            string directoryPath = @"D:\Test Analyst\ProjectMars\NewCompetitionTask_ProjectMars\Competition_ProjectMars\Competition_ProjectMars\ExtentReports";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            // Capture screenshot
            string screenshotPath = Path.Combine(directoryPath, $"screenshot_{DateTime.Now:yyyyMMddHHmmssfff}.png");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotPath);
            return screenshotPath;

        }

       
    }
}
