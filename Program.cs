using System;
using QC_ClassFetch.Services;

namespace QC_ClassFetch
{
    class Program
    {
        static void Main(string[] args)
        {
            int attempt = 0;

            Helpers.DisplayWelcomeMessage();

            // Year Input
            Console.Write("Enter the year (e.g., 2025): ");
            string year = Console.ReadLine() ?? string.Empty;
            CheckInput.CheckYear(ref year, ref attempt);

            // Reset attempt counter
            attempt = 0;

            // Semester Input
            Console.Write("Enter the semester (e.g., Spring, Summer 1, Summer 2, Fall, Winter): ");
            string semester = Console.ReadLine() ?? string.Empty;
            string semesterCode = CheckInput.CheckSemester(ref semester, ref attempt);

            // Reset attempt counter
            attempt = 0;

            // Department Input
            Console.Write("Enter the department code (e.g., CSCI, MATH, ENGL): ");
            string department = Console.ReadLine() ?? string.Empty;
            CheckInput.CheckDepartment(ref department, ref attempt);
            Console.WriteLine();

            // Fetch Courses
            try
            {
                FetchCourses.FetchCoursesData(year, semesterCode, department);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in the main program: {ex.Message}");
            }
        }
    }
}
