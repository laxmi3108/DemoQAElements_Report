using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using DemoQASite;
using System.Collections.ObjectModel;

namespace DemoQAElement_Report
{
    [TestClass]
    public class UnitTest1 : Selenium_Base
    {
        public static ExtentTest Test;

        public static ExtentReports Extent;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            Extent = new ExtentReports();

            var HtmlReporter = new ExtentHtmlReporter(@"E:\TestReportResults\DemoQAElementReport" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");

            Extent.AttachReporter(HtmlReporter);
        }

        [Test, Order(1)]
        public void TextBoxTest()
        {
            Test = null;
            Test = Extent.CreateTest("TextBox").Info("TextBoxTesting");
            try
            {
                open("https://demoqa.com/elements");
                wait(500);

                click(FindID("item-0"));
                wait(2000);

                string name = "Laxmi Gorai";
                string email = "laxmi31@gmail.com";
                string cadd = "kolkata";
                string padd = "Durgapur";

                sendKeys(FindID("userName"), name);
                wait(2000);

                sendKeys(FindID("userEmail"), email);
                wait(2000);

                sendKeys(FindID("currentAddress"), cadd);
                wait(2000);

                sendKeys(FindID("permanentAddress"), padd);
                wait(2000);

                scrollPage(0, 200);

                click(FindID("submit"));
                wait(2000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }

        }

        [Test, Order(2)]
        public void CheckBoxTest()
        {
            Test = null;
            Test = Extent.CreateTest(" CheckBox").Info(" CheckBoxTesting");
            try
            {
                click(FindID("item-1"));
                wait(2000);

                ExpandBtn(Driver);
                wait(2000);
                CollapseBtn(Driver);
                wait(2000);

                click(FindXPath("//*[text()='Home']"));
                wait(2000);
                ExpandBtn(Driver);
                wait(2000);

                click(FindXPath("//*[text()='Desktop']"));
                wait(2000);
                ExpandBtn(Driver);
                wait(2000);

                click(FindXPath("//*[text()='Notes']"));
                wait(2000);

                click(FindXPath("//*[text()='Commands']"));
                wait(2000);

                click(FindAllBy(By.XPath("//button[@title='Toggle']"))[1]);
                wait(2000);

                click(FindXPath("//*[text()='Angular']"));
                wait(2000);

                click(FindXPath("//*[text()='Angular']"));
                wait(2000);

                click(FindAllBy(By.XPath("//button[@title='Toggle']"))[3]);
                wait(2000);

                click(FindAllBy(By.XPath("//button[@title='Toggle']"))[4]);
                wait(2000);

                ExpandBtn(Driver);
                wait(2000);
                scrollPage(0, 300);
                wait(2000);

                click(FindXPath("//*[text()='Private']"));
                wait(2000);

                click(FindAllBy(By.XPath("//button[@title='Toggle']"))[4]);
                wait(2000);

                CollapseBtn(Driver);
                wait(2000);

                click(FindXPath("//*[text()='Home']"));
                wait(2000);


                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(3)]
        public void RadioButtonTest()
        {
            Test = null;
            Test = Extent.CreateTest("RadioButton").Info("RadioButtonTesting");
            try
            {
                click(FindID("item-2"));
                wait(2000);

                click(FindXPath("//label[@for='yesRadio']"));
                wait(2000);

                click(FindXPath("//label[@for='impressiveRadio']"));
                wait(2000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(4)]
        public void WebTableTest()
        {
            Test = null;
            Test = Extent.CreateTest("WebTable").Info("WebTableTesting");
            try
            {
                click(FindID("item-3"));
                wait(2000);

                string[] fname = { "Laxmi", "Mina", "Suravi", "Riya", "Piu", "Shreya", "Piya", "Kiya" };
                string[] lname = { "Gorai", "Shaw", "Singh", "Mondal", "Shaoo", "Kar", "Karmakar", "Chell" };
                string[] emailid = { "laxmi123@gmail.com", "mina123@gmail.com", "suravi123@gmail.com", "riya123@gmail.com", "piu123@gmail.com", "shreya123@gmail.com", "piya123@gmail.com", "kiya123@gmail.com" };
                string[] age = { "22", "20", "18", "25", "29", "24", "32", "31" };
                string[] salary = { "400000", "20000", "5000", "40000", "355000", "57000", "29000", "450000" };
                string[] dept = { "testing", "CSE", "IT", "ECE", "ME", "TEST", "DEV", "CSE/IT" };


                for (int i = 0; i < fname.Length; i++)
                {
                    click(FindXPath("//*[text()='Add']"));
                    wait(2000);

                    sendKeys(FindID("firstName"), fname[i]);
                    wait(2000);
                    sendKeys(FindID("lastName"), lname[i]);
                    wait(2000);
                    sendKeys(FindID("userEmail"), emailid[i]);
                    wait(2000);
                    sendKeys(FindID("age"), age[i]);
                    wait(2000);
                    sendKeys(FindID("salary"), salary[i]);
                    wait(2000);
                    sendKeys(FindID("department"), dept[i]);
                    wait(2000);
                    //Driver.FindElement(By.Id("department")).SendKeys(Keys.Enter);
                    click(FindID("submit"));
                    wait(2000);
                }

                string editfname = "Mina";
                click(FindID("edit-record-1"));
                wait(2000);
                clearAndSendKeys(FindID("firstName"), editfname);
                wait(2000);
                click(FindID("submit"));
                wait(2000);

                click(FindID("delete-record-1"));
                wait(2000);

                string search = "Laxmi";
                sendKeys(FindID("searchBox"), search);
                wait(2000);
                click(FindClass("input-group-text"));
                wait(2000);
                clear(FindID("searchBox"));
                wait(2000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(5)]
        public void ButtonTest()
        {
            Test = null;
            Test = Extent.CreateTest("Button").Info("ButtonTesting");
            try
            {
                scrollPage(0, 300);
                wait(500);

                click(FindID("item-4"));
                wait(2000);

                click(FindXPath("//*[text()='Click Me']"));
                wait(2000);
                doubleClick(FindID("doubleClickBtn"));
                wait(2000);
                contextClick(FindID("rightClickBtn"));
                wait(2000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(6)]
        public void LinksTest()
        {
            Test = null;
            Test = Extent.CreateTest("Links").Info("LinksTesting");
            try
            {
                scrollPage(0, 500);
                wait(500);

                click(FindID("item-5"));
                wait(2000);

                click(FindID("simpleLink"));
                wait(2000);
                switchToWindow(1);
                close();
                wait(2000);
                switchToWindow(0);

                click(FindID("dynamicLink"));
                wait(2000);

                switchToWindow(1);
                close();
                wait(2000);
                switchToWindow(0);
                scrollPage(0, 400);
                wait(2000);

                click(FindID("created"));
                wait(2000);
                click(FindID("no-content"));
                wait(2000);
                click(FindID("moved"));
                wait(2000);
                click(FindID("bad-request"));
                wait(2000);
                click(FindID("unauthorized"));
                wait(2000);
                click(FindID("forbidden"));
                wait(2000);
                click(FindID("invalid-url"));
                wait(2000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(7)]
        public void BrokenLinksImgTest()
        {
            Test = null;
            Test = Extent.CreateTest("BrokenLinksImg").Info("BrokenLinksImg");
            try
            {
                scrollPage(0, 500);
                wait(500);

                click(FindID("item-6"));
                wait(2000);

                ReadOnlyCollection<IWebElement> elements = FindAllBy(By.TagName("img"));

                IWebElement validImage = elements[2];
                IWebElement brokenImage = elements[3];

                Console.WriteLine("Valid Image Response : " + testForValidImage(getAttribute(validImage, "src")));
                Console.WriteLine("Broken Image Response : " + testForValidLink(getAttribute(brokenImage, "src")));

                wait(500);

                Console.WriteLine("Valid Link Response : " + testForValidLink(getAttribute(FindXPath("//a[text()='Click Here for Valid Link']"), "href")));
                Console.WriteLine("Broken Link Response : " + testForValidLink(getAttribute(FindXPath("//a[text()='Click Here for Broken Link']"), "href")));

                wait(3000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(8)]
        public void UploadDownloadTest()
        {
            Test = null;
            Test = Extent.CreateTest("UploadDownload").Info("UploadDownloadTesting");
            try
            {
                scrollPage(0, 500);
                wait(500);

                click(FindID("item-7"));
                wait(2000);

                click(FindID("downloadButton"));
                wait(2000);

                sendKeys(FindID("uploadFile"), @"C:\picture\crp3 (2).jpeg");
                wait(2000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        [Test, Order(8)]
        public void Dynamic_PropertiesTest()
        {
            Test = null;
            Test = Extent.CreateTest("Dynamic_Properties").Info("Dynamic_PropertiesTesting");
            try
            {
                scrollPage(0, 500);
                wait(500);

                click(FindID("item-8"));
                wait(7000);

                close();
                wait(2000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }


        public void ExpandBtn(IWebDriver Driver)
        {
            click(FindClass("rct-option-expand-all"));
        }

        public void CollapseBtn(IWebDriver Driver)
        {
            click(FindClass("rct-option-collapse-all"));
        }

        [OneTimeTearDown]
        public void CloseChrome()
        {
            Driver.Close();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            Extent.Flush();
        }
    }
}
