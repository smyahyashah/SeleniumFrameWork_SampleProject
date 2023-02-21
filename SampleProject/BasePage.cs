using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace SampleProject
{
    
    public class BasePage
    {
        public static IWebDriver driver;

        //Opening Chrome
        public static void SeleniumInit()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            driver = new ChromeDriver(options);
        }

        //Write Action
        public static void Write(By by, string user)
        {
            try
            {
                driver.FindElement(by).SendKeys(user);
                TakeScreenshot(Status.Pass, "Write " + user);
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Write Failed: " + ex.ToString());
                Assert.Fail();
            }
        }

        //Click Action
        public static void Click(By by)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenshot(Status.Pass, "Click");
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Click Failed: " + ex.ToString());
                Assert.Fail();
            }
        }

        //Opening URL
        public static void OpenUrl(string url)
        {
            try
            {
                driver.Url = url;
                TakeScreenshot(Status.Pass, "Open url: " + url);
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Open Url Failed: " + ex.ToString());
                Assert.Fail();
            }
        }

        //Asserting
        public static void Assertion(string expectedText, By by)
        {
            string actualText = GetElement(by);
            Assert.AreEqual(expectedText, actualText);

        }

        //Geting Webpage text elements
        public static string GetElement(By by)
        {
            string text;
            try
            {
                text = driver.FindElement(by).Text;
            }
            catch
            {
                try
                {
                    text = driver.FindElement(by).GetAttribute("value");
                }
                catch
                {
                    text = driver.FindElement(by).GetAttribute("innerHTML");
                }
            }
            return text;
        }

        //Taking Screenshots for extent report
        public static void TakeScreenshot(Status status, string stepDetail)
        {
            string path = @"C:\ExtentReports\TestExecutionReports\" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");

            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            image.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            ExtentReport.exChildTest.Log(status, stepDetail, MediaEntityBuilder
                .CreateScreenCaptureFromPath(path + ".png").Build());
        }
    }
}

