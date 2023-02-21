using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SampleProject
{
    [TestClass]
    public class ExecutionPage
    {
        #region Setup and Cleanup

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }


        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            ExtentReport.LogReport("TestCaseReporting");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            ExtentReport.extentReports.Flush();
        }

        [TestInitialize()]
        public void TestInit()
        {
            //Adding TestCase to ExtentReport
            ExtentReport.exParentTest = ExtentReport.extentReports.CreateTest(TestContext.TestName);
            BasePage.SeleniumInit();
        }

        [TestCleanup()]
        public void TestCleanUp()
        {
            BasePage.driver.Close();
        }
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            LoginPage.Login("yahyatester", "yahyatester", "https://adactinhotelapp.com/");
        }
    }
}
