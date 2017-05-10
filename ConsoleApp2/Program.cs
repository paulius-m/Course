using MySqlRepository;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repo = new Repository();

            DisplayMenu();
            int input;
            input = int.Parse(System.Console.ReadLine());

            while (true)
            {
                if (input == 1)
                {
                    DisplayAllEmployeesMenuItem displayItem = new DisplayAllEmployeesMenuItem(repo);
                    displayItem.Execute();
                }

                if (input == 2)
                {
                    DisplayEmployeeMenuItem displayEmployee = new DisplayEmployeeMenuItem(repo);
                    displayEmployee.Execute();
                }
                if (input == 3)
                {
                    string firstname = System.Console.ReadLine();
                    string lastname = System.Console.ReadLine();
                    repo.CreateEmployee(firstname, lastname);
                }
                if (input == 4)
                {
                    int x = int.Parse(System.Console.ReadLine());
                    repo.DeleteEmployee(x);
                }
                if (input == 5)
                {
                    int x = int.Parse(System.Console.ReadLine());
                    string firstname = System.Console.ReadLine();
                    string lastname = System.Console.ReadLine();
                    DateTime date = DateTime.Parse(System.Console.ReadLine());



                    Employee emp = new Employee();
                    emp.FirstName = firstname;
                    emp.LastName = lastname;
                    emp.EmployeeID = x;
                    repo.UpdateEmployee(emp);
                }               
                if (input == 6)
                {
                    ExitMenuItem exitmenu = new ExitMenuItem();
                    exitmenu.Execute();
                }
                DisplayMenu();
                input = int.Parse(System.Console.ReadLine());              
            }               
        }
        public static void DisplayMenu()
        {
            System.Console.WriteLine("1. DisplayAllEmployee");
            System.Console.WriteLine("2. DisplayEmployee");
            System.Console.WriteLine("3. CreateEmpleyee");
            System.Console.WriteLine("4. DeleteEmployee");
            System.Console.WriteLine("5. UpdateEmployee");
            System.Console.WriteLine("6. Exit");
        }
    }
}