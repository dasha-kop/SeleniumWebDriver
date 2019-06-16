using System;
using System.Collections.Generic;
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
            String actualy = firefox.FindElementByClassName("organic__url-text").Text;
            Assert.AreEqual("Алтайский государственный технический университет", actualy);
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
            firefox.FindElement(By.XPath("//form/div[4]/button")).Click();
            System.Threading.Thread.Sleep(3500);
            String actualt = firefox.FindElementByCssSelector("html.is-js_yes.is-inlinesvg_yes body.pointerfocus div#root.layout div.layout-inner div.grid div.main-container main.registration__wrapper.registration__wrapper_desktop div.registration__block div div form.registration__form.registration__form_desktop div div.form__field.field__password.form__field_filled.field__error div.reg-field__popup div.form__popup-error div.error-message").Text;
            Assert.AreEqual("Пароль не может совпадать с логином", actualt);
        }
        [TestMethod]
        public void TestTranslate()
        {
            firefox.Navigate().GoToUrl("https://yandex.ru/");
            firefox.FindElement(By.XPath("//a[@data-id='translate']")).Click();
            firefox.FindElement(By.Id("textarea")).SendKeys("Selenium");
            System.Threading.Thread.Sleep(1500);
            String actualy=firefox.FindElementByXPath("//div/pre/span/span").Text;
            Assert.AreEqual("Селен", actualy);
            System.Threading.Thread.Sleep(1500);
            firefox.FindElement(By.Id("textarea")).Clear();
            firefox.FindElement(By.Id("textarea")).SendKeys("Тестирование");
            System.Threading.Thread.Sleep(1500);
            actualy = firefox.FindElementByXPath("//div/pre/span/span").Text;
            Assert.AreEqual("Testing", actualy);
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
            String actualy = firefox.FindElementByXPath("//div/div/div[1]/div[1]/div[2]/a/span[2]").Text;
            Assert.AreEqual("www.altstu.ru", actualy);
      
        }

      
     
        // разрушение объекта драйвера после окончание теста.
        [TestCleanup]
        public void TearDown()
        {
            firefox.Quit();
        }
    }
}
