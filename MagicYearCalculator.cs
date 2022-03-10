using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MagicYearCalculator // Note: actual namespace depends on the project name.
{
    class MagicYearCalculator {
        
        private int getMagicYear(Person person, int magicConst=65) {
            return person.StartYear + magicConst;
        }

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

        private void getUserInfo(Person person) {
            person.FirstName = getUserInput("Please input your name: ", "^[A-Z][a-z]*$");
            person.LastName = getUserInput("Please input your surname: ", "^[A-Z][a-z]*$");
            person.AnnualSalary = Convert.ToInt32(getUserInput("Please enter your annual salary: ", "^[0-9]*$"));
            person.StartYear = Convert.ToInt32(getUserInput("Please enter your work start year : ", "^[0-9]{4}$"));
        }

        private string generateMagicAgeDetails(Person person) {
            return $"\nYour magic age details are:\n\nName: {person.getFullName()}\nMonthly Salary: {person.getMonthlySalary()}\nMagic Year: {getMagicYear(person)}";
        }

        public void run() {
            Console.WriteLine("Welcome to the magic year calculator!\n");
            Person person = new Person();
            getUserInfo(person);
            Console.WriteLine(generateMagicAgeDetails(person));
        }
    }
}