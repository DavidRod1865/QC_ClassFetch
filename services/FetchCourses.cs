using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace QC_ClassFetch.Services
{
    public class FetchCourses
    {
        private static void SaveToCsv(List<string[]> tableData, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var row in tableData)
                {
                    writer.WriteLine(string.Join(",", row));
                }
            }
        }

        public static void FetchCoursesData(string year, string semester, string department)
        {
            // Create a cancellation token for stopping the animation
            CancellationTokenSource cts = new CancellationTokenSource();
            
            // Start the loading animation in a background task
            Task.Run(() => Helpers.LoadingAnimation(cts.Token));

            // Set up ChromeOptions for headless mode
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");

            // Initialize the WebDriver with headless options
            IWebDriver driver = new ChromeDriver(options);

            try
            {
                // Navigate to the webpage
                driver.Navigate().GoToUrl("https://apps.qc.cuny.edu/Courses/Default.aspx");

                // Maximize the browser window (virtual in headless mode)
                driver.Manage().Window.Maximize();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IWebElement tabElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("__tab_MainContent_tcMainSearch_tbCourseSchd")));
                tabElement.Click();

                IWebElement yearDropdown = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("MainContent_tcMainSearch_tbCourseSchd_ddlTermYear")));
                var selectYear = new SelectElement(yearDropdown);
                selectYear.SelectByValue(year);

                IWebElement semesterDropdown = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("MainContent_tcMainSearch_tbCourseSchd_ddlSemester")));
                var selectSemester = new SelectElement(semesterDropdown);
                selectSemester.SelectByValue(semester);

                IWebElement departmentDropdown = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("MainContent_tcMainSearch_tbCourseSchd_ddlDeptList")));
                var selectDepartment = new SelectElement(departmentDropdown);
                selectDepartment.SelectByValue(department);

                IWebElement submitButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("ctl00$MainContent$tcMainSearch$tbCourseSchd$btnBringSchedule")));
                submitButton.Click();

                wait.Until(ExpectedConditions.ElementExists(By.Id("gvCourseSchd")));
                IWebElement table = driver.FindElement(By.Id("gvCourseSchd"));

                IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
                List<string[]> tableData = new List<string[]>();

                foreach (IWebElement row in rows)
                {
                    IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                    if (cells.Count > 0)
                    {
                        string[] rowData = new string[cells.Count];
                        for (int i = 0; i < cells.Count; i++)
                        {
                            rowData[i] = cells[i].Text.Trim();
                        }
                        tableData.Add(rowData);
                    }
                }

                SaveToCsv(tableData, "CourseSchedule.csv");
                Console.WriteLine("Courses retrieved and saved to CourseSchedule.csv");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Stop the loading animation
                cts.Cancel();
                Thread.Sleep(500);

                driver.Quit();
            }
        }
    }
}
