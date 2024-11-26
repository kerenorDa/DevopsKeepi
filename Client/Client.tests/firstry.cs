namespace Keepi.Client.Client.tests
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Xunit;

    public class ChromeTests : IDisposable
    {
        private readonly IWebDriver driver;

        public ChromeTests()
        {
            // ציון הנתיב של ChromeDriver
            var driverPath = @"C:\Users\talor\OneDrive\שולחן העבודה\Keepi\chromedriver-win32"; // עדכני את הנתיב שבו שמרת את chromedriver.exe
            var options = new ChromeOptions();

            // יצירת אינסטנס של ChromeDriver
            driver = new ChromeDriver(driverPath, options);

            // פתיחת האתר
            driver.Navigate().GoToUrl("https://localhost:7149"); // עדכני את ה-URL שלך
        }

        [Fact]
        public void TestHomePageLoads()
        {
            // בדיקה לדוגמה - לוודא שהכותרת קיימת
            var title = driver.Title;
            Assert.NotNull(title);
            Console.WriteLine($"Page Title: {title}");
        }

        public void Dispose()
        {
            // סגירת הדפדפן אחרי הבדיקות
            driver.Quit();
        }
    }

}

