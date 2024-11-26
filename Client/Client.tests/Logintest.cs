using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Xunit;

namespace Keepi.Client.Tests
{
    public class LoginPageTests : IDisposable
    {
        private readonly IWebDriver driver;

        public LoginPageTests()
        {
            // הגדרת EdgeDriver
            var driverPath = @"C:\Users\talor\OneDrive\שולחן העבודה\Keepi"; // נתיב שבו שמור msedgedriver.exe
            var options = new EdgeOptions();
            driver = new EdgeDriver(driverPath, options);


            // פתיחת עמוד ההתחברות
            driver.Navigate().GoToUrl("https://localhost:7149/"); // URL של עמוד ההתחברות
            Thread.Sleep(5000); // המתנה של 5 שניות

        }

        [Fact]
        public void TestSuccessfulLogin()
        {
            // הכנסת שם משתמש
            var userNameField = driver.FindElement(By.CssSelector("#userName"));
            Assert.NotNull(userNameField);
            userNameField.SendKeys("keren");

            // הכנסת סיסמה
            var passwordField = driver.FindElement(By.CssSelector("#password"));
            Assert.NotNull(passwordField);
            passwordField.SendKeys("123456");

            // לחיצה על כפתור התחברות
            var loginButton = driver.FindElement(By.CssSelector("#loginButton"));
            Assert.NotNull(loginButton);
            loginButton.Click();

            // ווידוא ניתוב לעמוד הבית
            Assert.Equal("https://localhost:7149/home", driver.Url); // בדיקה שכתובת ה-URL היא של עמוד הבית
        }

        [Fact]
        public void TestLoginWithInvalidPassword()
        {
            // הכנסת שם משתמש
            var userNameField = driver.FindElement(By.CssSelector("#userName"));
            userNameField.SendKeys("keren");

            // הכנסת סיסמה לא נכונה
            var passwordField = driver.FindElement(By.CssSelector("#password"));
            passwordField.SendKeys("wrongpassword");

            // לחיצה על כפתור התחברות
            var loginButton = driver.FindElement(By.CssSelector("#loginButton"));
            loginButton.Click();

            // ווידוא שעדיין בעמוד ההתחברות (לא עמוד הבית)
            Assert.NotEqual("https://localhost:7149/home", driver.Url);
        }

        public void Dispose()
        {
            driver.Quit(); // סגירת הדפדפן לאחר הבדיקות
        }
    }
}
