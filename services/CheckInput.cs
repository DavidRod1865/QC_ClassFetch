using System;
using System.Linq;

namespace QC_ClassFetch.Services
{
    public class CheckInput
    {
        private static readonly string[] validSemesters = ["Spring", "Summer 1", "Summer 2", "Fall", "Winter"];
        private static readonly string[] validDepartments = ["CSCI", "MATH", "ENGL"];

        public static bool CheckYear(ref string year, ref int attempt)
        {
            while (attempt < 3)
            {
                if (year.Length == 4 && int.TryParse(year, out _))
                {
                    return true;
                }

                Console.Write("Invalid year. Please enter a valid year (e.g., 2025): ");
                year = Console.ReadLine() ?? string.Empty;
                attempt++;
            }

            Console.WriteLine("You have exceeded the number of attempts. Exiting program.");
            Environment.Exit(0);
            return false; // Unreachable but required for method signature
        }

        public static string CheckSemester(ref string semester, ref int attempt)
        {

            Dictionary<string, string> semesterCodes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Spring", "02N" },
                { "Summer 1", "06N" },
                { "Summer 2", "06Y" },
                { "Fall", "09N" },
                { "Winter", "02Y" }
            };

            while (attempt < 3)
            {
                if (validSemesters.Contains(semester, StringComparer.OrdinalIgnoreCase))
                {
                    return semesterCodes[semester];
                }

                Console.Write("Invalid semester. Please enter a valid semester (e.g., Spring, Summer 1, Summer 2, Fall, Winter): ");
                semester = Console.ReadLine() ?? string.Empty;
                attempt++;
            }

            Console.WriteLine("You have exceeded the number of attempts. Exiting program.");
            Environment.Exit(0);
            return string.Empty;;
        }

        public static bool CheckDepartment(ref string department, ref int attempt)
        {
            department = department.ToUpper();
            
            while (attempt < 3)
            {
                if (validDepartments.Contains(department, StringComparer.OrdinalIgnoreCase))
                {
                    return true;
                }

                Console.Write("Invalid department code. Please enter a valid department code (e.g., CSCI, MATH, ENGL): ");
                department = Console.ReadLine() ?? string.Empty;
                attempt++;
            }

            Console.WriteLine("You have exceeded the number of attempts. Exiting program.");
            Environment.Exit(0);
            return false;
        }
    }
}
