namespace QC_ClassFetch.Services
{
    class Helpers
    {

        public static void LoadingAnimation(CancellationToken token)
        {
            char[] spinner = { '|', '/', '-', '\\' };
            int spinnerIndex = 0;

            while (!token.IsCancellationRequested)
            {
                Console.Write($"\rProcessing... {spinner[spinnerIndex]}");
                spinnerIndex = (spinnerIndex + 1) % spinner.Length;
                Thread.Sleep(100);
            }
        }

        public static void DisplayWelcomeMessage()
        {
            Console.Clear();

            int windowWidth = Console.WindowWidth;

            // Helper function to center text
            void WriteCentered(string text)
            {
                int padding = (windowWidth - text.Length) / 2;
                Console.WriteLine(new string(' ', Math.Max(0, padding)) + text);
            }

            WriteCentered("==========================================");
            WriteCentered("|         Welcome to QC Class Fetcher    |");
            WriteCentered("==========================================");
            Console.WriteLine();
            WriteCentered("🚀 This program will help you retrieve");
            WriteCentered("the course schedule from the QC website.");
            Console.WriteLine();
            WriteCentered("📂 Once processed, the data will be saved");
            WriteCentered("to a CSV file for easy reference.");
            Console.WriteLine();
            WriteCentered("💡 Please answer the following questions:");
            Console.WriteLine();
            WriteCentered("------------------------------------------");
        }
    }
}