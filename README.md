# QC Class Fetch

🚀 **QC Class Fetch** is a console-based application designed to streamline the process of retrieving course schedules for departments at Queens College. It scrapes the QC website, processes the data, and saves it as a CSV file for easy reference.

---

## Features

- 🎓 **Department-Specific Schedule**: Fetches course schedules based on your chosen year, semester, and department.
- 📂 **CSV Export**: Saves the fetched schedule data to a CSV file for offline use.
- 🖥️ **Headless Browser Mode**: Operates silently in the background without opening a browser window.
- 🌟 **User-Friendly Interface**: Offers clear, interactive prompts with validation for input.

---

## How It Works

1. **Interactive Prompt**: Enter the year, semester, and department code when prompted.
2. **Data Scraping**: The application uses Selenium WebDriver to extract course data from the QC website.
3. **CSV Output**: The retrieved data is saved as `CourseSchedule.csv` in the current directory.

---

## Built With / Requirements

- **C# .NET SDK**
- **Selenium WebDriver**
- **Google Chrome & ChromeDriver**

---

## Setup & Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/QC-Class-Fetcher.git
   cd QC-Class-Fetcher
   ```

2. Install dependencies:

    ```bash
    dotnet add package DotNetSeleniumExtras.WaitHelpers
    dotnet add package Selenium.Support
    dotnet add package Selenium.WebDriver
    dotnet add package Selenium.WebDriver.ChromeDriver
    ```

3. Build and run the project:

    ```bash
    dotnet build
    dotnet run
    ```
---

## Example Usage

1. Run the application:

    ```bash
    dotnet run
    ```

2. Follow the prompts:

    ```java
    Welcome to QC Class Fetcher!
    Enter the year (e.g., 2025): 2025
    Enter the semester (e.g., Spring): Spring
    Enter the department code (e.g., CSCI): CSCI
    ```

3. Check your project directory for the CourseSchedule.csv file.

---

## Project Structure

    QC-Class-Fetcher/
    ├── QC_ClassFetch/
    │   ├── Program.cs                 # Entry point of the application
    │   ├── Services/
    │   │   ├── FetchCourses.cs        # Handles Selenium web scraping
    │   │   └── CheckInput.cs          # Validates user input
    ├── CourseSchedule.csv             # Example output file
    └── README.md                      # Project documentation

---

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement". Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## License

Distributed under the MIT License. See `LICENSE` for more information.

---

## Contact

David Rodriguez - [LinkedIn](https://www.linkedin.com/in/david-rodriguez1865/) - d.rodriguez.1865@gmail.com

Project Link: [https://github.com/DavidRod1865/QC_ClassFetch](https://github.com/DavidRod1865/QC_ClassFetch)

---

## Top contributors:

<a href="https://github.com/DavidRod1865/QC_ClassFetch/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=DavidRod1865/QC_ClassFetch" alt="contrib.rocks image" />
</a>


--

## Acknowledgments

- 🏫 Queens College for the course schedule portal
- 🛠️ Selenium WebDriver for powerful web automation

---

## 🌟 Star this repository if you find it helpful! 🌟

