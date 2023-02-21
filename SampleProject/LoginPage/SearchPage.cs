using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace SampleProject
{
    public class SearchPage : BasePage
    {
      
        public static void Search()
        {
            
            ExtentReport.exChildTest = ExtentReport.exParentTest.CreateNode("Login");
                
            
            Assertion("Welcome to Adactin Group of Hotels", By.XPath("/html/body/table[2]/tbody/tr[1]/td[1]"));
        }
    }
}
