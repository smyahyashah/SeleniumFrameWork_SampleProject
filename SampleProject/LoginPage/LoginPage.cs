using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace SampleProject
{
    public class LoginPage : BasePage
    {
      
        public static void Login(string user, string pass, string url)
        {
            
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Login");

            OpenUrl(url);
            Write(By.Id("username"), user);
            Write(By.Id("password"), pass);
            Click(By.Id("login"));
            Thread.Sleep(2000);
            Assertion("Welcome to Adactin Group of Hotels", By.XPath("/html/body/table[2]/tbody/tr[1]/td[1]"));
        }
    }
}
