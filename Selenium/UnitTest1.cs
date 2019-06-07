using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Selenium
{
    [TestClass]
    public class UnitTest1
    {
       FirefoxDriver firefox;

        public UnitTest1()
        {
            this.firefox = new FirefoxDriver();
        }

        // это тест.
        [TestMethod]
        public void TestFindYandex()
        {
            firefox.Navigate().GoToUrl("https://yandex.ru/");
            firefox.FindElement(By.Id("text")).SendKeys("Алгту");
            firefox.FindElement(By.XPath("//button[@type='submit']")).Click();
           
        }
        [TestMethod]
        public void TestRegEmail()
        {
            firefox.Navigate().GoToUrl("https://yandex.ru/");
            firefox.FindElement(By.ClassName("desk-notif-card__login-mail-promo")).Click();
            firefox.FindElement(By.Id("firstname")).SendKeys("Иванов");
            firefox.FindElement(By.Id("lastname")).SendKeys("Иванов");
            firefox.FindElement(By.Id("login")).SendKeys("Ivanoinavon");
            firefox.FindElement(By.Id("password")).SendKeys("Ivanoinavon");
            firefox.FindElement(By.Id("password_confirm")).SendKeys("Ivanoinavon");
            firefox.FindElement(By.XPath("//button[@type='submit']")).Click();

        }
        [TestMethod]
        public void TestTranslate()
        {
            firefox.Navigate().GoToUrl("https://yandex.ru/");
            firefox.FindElement(By.XPath("//a[@data-id='translate']")).Click();
            firefox.FindElement(By.Id("textarea")).SendKeys("Selenium");
            System.Threading.Thread.Sleep(1500);
            firefox.FindElement(By.Id("textarea")).Clear();
            firefox.FindElement(By.Id("textarea")).SendKeys("Тестирование");
            System.Threading.Thread.Sleep(1500);
        }
        [TestMethod]
        public void TestMaps()
        {
            firefox.Navigate().GoToUrl("https://yandex.ru/");
            firefox.FindElement(By.XPath("//a[@data-id='maps']")).Click();
            firefox.FindElement(By.ClassName("input_air-search-large__control")).SendKeys("Алтгту");
            firefox.FindElement(By.ClassName("input_air-search-large__control")).SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(2500);
            firefox.FindElement(By.ClassName("business-urls-view__url")).Click();
            System.Threading.Thread.Sleep(2500);
      
        }

        [TestMethod]
        public void TestTV()
        {
            firefox.Navigate().GoToUrl("https://yandex.ru/efir?from=morda&stream_channel=1550142789&stream_active=storefront");
            firefox.FindElement(By.Id("uniq15537841432981")).SendKeys("Алтгту");
            firefox.FindElement(By.Id("uniq15537841432981")).SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(2500);
      
        }
        [TestMethod]
        public void TestVK()
        {
            firefox.Navigate().GoToUrl("https://vk.com/mcserg");
            firefox.FindElement(By.ClassName("like_btn")).Click();
            System.Threading.Thread.Sleep(3500);
      
        }
        // разрушение объекта драйвера после окончание теста.
        [TestCleanup]
        public void TearDown()
        {
            firefox.Quit();
        }
    }
}
