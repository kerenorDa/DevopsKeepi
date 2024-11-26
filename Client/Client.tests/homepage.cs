using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Xunit;

namespace Keepi.Client.Tests
{
    public class PageButtonsTests : IDisposable
    {
        private readonly IWebDriver driver;

        public PageButtonsTests()
        {
            // הגדרת EdgeDriver
            var driverPath = @"C:\Users\talor\OneDrive\שולחן העבודה\Keepi"; // נתיב שבו שמרת את msedgedriver.exe
            var options = new EdgeOptions();
            driver = new EdgeDriver(driverPath, options);

            // פתיחת האתר
            driver.Navigate().GoToUrl("https://localhost:7149"); // עדכני את ה-URL של עמוד הבית
        }

        [Fact]
        public void TestButton1()
        {
            var button1 = driver.FindElement(By.CssSelector("#app > div > main > table > tr:nth-child(1) > table > tr > td:nth-child(2) > button > img"));
            Assert.NotNull(button1);
            button1.Click();
        }

        [Fact]
        public void TestButton2()
        {
            var button2 = driver.FindElement(By.CssSelector("#app > div > main > table > tr:nth-child(1) > table > tr > td:nth-child(3) > button > img"));
            Assert.NotNull(button2);
            button2.Click();
        }

        [Fact]
        public void TestButton3()
        {
            var button3 = driver.FindElement(By.CssSelector("#app > div > main > table > tr:nth-child(1) > table > tr > td:nth-child(4) > button > img"));
            Assert.NotNull(button3);
            button3.Click();
        }

        [Fact]
        public void TestButton4()
        {
            var button4 = driver.FindElement(By.CssSelector("#app > div > main > table > tr:nth-child(1) > table > tr > td:nth-child(5) > button > img"));
            Assert.NotNull(button4);
            button4.Click();
        }

        [Fact]
        public void TestButton5()
        {
            var button5 = driver.FindElement(By.CssSelector("#app > div > main > table > tr:nth-child(1) > table > tr > td:nth-child(6) > button > img"));
            Assert.NotNull(button5);
            button5.Click();
        }

        [Fact]
        public void TestButton6()
        {
            var button6 = driver.FindElement(By.CssSelector("#app > div > main > table > tr:nth-child(1) > table > tr > td:nth-child(7) > button > img"));
            Assert.NotNull(button6);
            button6.Click();
        }

        [Fact]
        public void TestButton7()
        {
            var button7 = driver.FindElement(By.CssSelector("#app > div > main > table > tr:nth-child(1) > table > tr > td:nth-child(8) > button > img"));
            Assert.NotNull(button7);
            button7.Click();
        }

        [Fact]
        public void TestButton8()
        {
            var button8 = driver.FindElement(By.CssSelector("#app > div > main > table > tr:nth-child(1) > table > tr > td:nth-child(9) > button > img"));
            Assert.NotNull(button8);
            button8.Click();
        }

        [Fact]
        public void TestButton9()
        {
            var button9 = driver.FindElement(By.CssSelector("#app > div > main > table > tr:nth-child(2) > td > button"));
            Assert.NotNull(button9);
            button9.Click();
        }

        [Fact]
        public void TestButton10()
        {
            var button10 = driver.FindElement(By.CssSelector("#app > div > main > div > div:nth-child(3) > button:nth-child(1) > img"));
            Assert.NotNull(button10);
            button10.Click();
        }

        public void Dispose()
        {
            driver.Quit(); // סגירת הדפדפן לאחר הבדיקות
        }
    }
}