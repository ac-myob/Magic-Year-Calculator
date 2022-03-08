namespace MagicYearCalculator {
    class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AnnualSalary { get; set; }
        public int StartYear { get; set; }

        public string getFullName() {
            return this.FirstName + " " + this.LastName;
        }
        public int getMonthlySalary() {
            const int MONTHS_IN_YEAR = 12;
            return (int)Math.Round((double)this.AnnualSalary/MONTHS_IN_YEAR);
        }
    }
}