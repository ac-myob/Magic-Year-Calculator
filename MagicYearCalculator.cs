using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MagicYearCalculator // Note: actual namespace depends on the project name.
{
    class MagicYearCalculator {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private int AnnualSalary { get; set; }
        private int StartYear { get; set; }

        private string getUserInput(string question, string regex) {
            string userResponse = "";

            do {
                Console.Write(question);
                userResponse = Console.ReadLine();
                if (!Regex.IsMatch(userResponse, regex)) {
                    Console.Write("Invalid input. Please try again.\n");
                }
            } while (!Regex.IsMatch(userResponse, regex));

            return userResponse;
        }

        private void getUserInfo() {
            this.FirstName = getUserInput("Please input your name: ", "^[A-Z][a-z]*$");
            this.LastName = getUserInput("Please input your surname: ", "^[A-Z][a-z]*$");
            this.AnnualSalary = Convert.ToInt32(getUserInput("Please enter your annual salary: ", "^[0-9]*$"));
            this.StartYear = Convert.ToInt32(getUserInput("Please enter your work start year : ", "^[0-9]{4}$"));
        }
        
        private string getFullName() {
            return this.FirstName + " " + this.LastName;
        }

        // Func<string> getFullName = () => this.FirstName;
        // Func<int,int,int> test = (x, y) => x + y;

        private int getMonthlySalary() {
            const int MONTHS_IN_YEAR = 12;
            return (int)Math.Round((double)this.AnnualSalary/MONTHS_IN_YEAR);
        }

        private int getMagicYear() {
            const int MAGIC_CONST = 65;
            return this.StartYear + MAGIC_CONST;
        }
        private string generateMagicAgeDetails() {
            return $"\nYour magic age details are:\n\nName: {getFullName()}\nMonthly Salary: {getMonthlySalary()}\nMagic Year: {getMagicYear()}";
        }

        public void run() {
            Console.WriteLine("Welcome to the magic year calculator!\n");
            getUserInfo();
            Console.WriteLine(generateMagicAgeDetails());
        }
    }
}