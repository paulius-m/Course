using System;

namespace MySqlRepository
{
    public class Employee
    {
        private int _employeeID;
        public int EmployeeID {
            get { return _employeeID; }
            set { _employeeID = value; }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }

        public Employee(DateTime date)
        {
            this.BirthDate = date;
        }

        public Employee()
        {
        }

        public int GetAge()
        {
            int age = DateTime.Now.Year - this.BirthDate.Year;
            return age;
        }

        public int GetJobTenure()
        {
            int JobTenure = DateTime.Now.Year - this.HireDate.Year;
            return JobTenure;
        }


    }
}
