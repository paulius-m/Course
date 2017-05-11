using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlRepository;

namespace ConsoleApp1
{
    public interface IMenuItem
    {
        string MenuName { get; }
        void Execute();
    }

    public abstract class RepositoryMenuItem : IMenuItem 
    {
        protected IRepository repo;
        public RepositoryMenuItem(IRepository pifas)
        {
            repo = pifas;
        }

        public abstract string MenuName { get; }

        public abstract void Execute();
    }
    public class DisplayAllEmployeesMenuItem : RepositoryMenuItem
    {
        public override string MenuName { get { return "DisplayAllEmployees"; } }

        public DisplayAllEmployeesMenuItem(IRepository pifas) : base (pifas)
        {           
        }

        

        public override void Execute()
        {

            List<Employee> AllEmployees = repo.GetAllEmployees();
            for (int i = 0; i < AllEmployees.Count; i++)
            {   
                System.Console.WriteLine(AllEmployees[i].EmployeeID + " " + AllEmployees[i].FirstName + " " + AllEmployees[i].LastName);
            }
        }
    }
    public class DisplayEmployeeMenuItem : RepositoryMenuItem
    {
        public override string MenuName { get { return "DisplayEmployee"; } }
        public DisplayEmployeeMenuItem(IRepository pifas) : base(pifas)
        {
        }
        public override void Execute()
        {
            System.Console.WriteLine("Įveskite ID");
            int x = int.Parse(System.Console.ReadLine());

            Employee employee = repo.GetEmployee(x);

            if (employee != null)
            {
                System.Console.WriteLine(
                    employee.EmployeeID + " " +
                    employee.FirstName + " " +
                    employee.LastName + " " +
                    employee.BirthDate.ToShortDateString() + " " +
                    employee.HireDate.ToShortDateString());
            }
        }
    }
    public class CreateEmployeeMenuItem : RepositoryMenuItem
    {
        public override string MenuName { get { return "CreateEmployee"; } }

        public CreateEmployeeMenuItem(IRepository pifas) : base(pifas)
        {
        }
        public override void Execute()
        {
            //System.DateTime input1;
            //input1 = System.DateTime.Parse(Console.ReadLine());
            System.Console.WriteLine("Įveskite vardą");
            string firstname = (System.Console.ReadLine());
            System.Console.WriteLine("Įveskite pavardę");
            string lastname = (System.Console.ReadLine());
            System.Console.WriteLine("Įveskite gimimo datą. Formatas - yyyy-mm-dd");
            System.DateTime birthdate = System.DateTime.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Įveskite įdarbinimo datą. Formatas - yyyy-mm-dd");
            System.DateTime hiredate = System.DateTime.Parse(System.Console.ReadLine());
            repo.CreateEmployee(firstname, lastname, birthdate, hiredate);
        }
    }


    public class DeleteEmployeeMenuItem : RepositoryMenuItem
    {
        public override string MenuName { get { return "DeleteEmployee"; } }
        public DeleteEmployeeMenuItem(IRepository pifas) : base(pifas)
        {
        }
        public override void Execute()
        {
            System.Console.WriteLine("Įveskite ID");
            int x = int.Parse(System.Console.ReadLine());
            repo.DeleteEmployee(x);
        }
    }

    public class UpdateEmployeeMenuItem : RepositoryMenuItem
    {
        public override string MenuName { get { return "UpdateEmployee"; } }
        public UpdateEmployeeMenuItem(IRepository pifas) : base(pifas)
        {
        }
        public override void Execute()
        {
            System.Console.WriteLine("Įveskite ID");
            int x = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Įveskite vardą");
            string firstname = (System.Console.ReadLine());
            System.Console.WriteLine("Įveskite pavardę");
            string lastname = (System.Console.ReadLine());
            System.Console.WriteLine("Įveskite gimimo datą. Formatas - yyyy-mm-dd");
            System.DateTime birthdate = System.DateTime.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Įveskite įdarbinimo datą. Formatas - yyyy-mm-dd");
            System.DateTime hiredate = System.DateTime.Parse(System.Console.ReadLine());
            Employee emp = new Employee();
            emp.FirstName = firstname;
            emp.LastName = lastname;
            emp.EmployeeID = x;
            emp.BirthDate = birthdate;
            emp.HireDate = hiredate;
            repo.UpdateEmployee(emp);
        }
    }

    public class EmptyMenuItem : IMenuItem
    {
        string text;
        public string MenuName { get { return this.text; } }

        public EmptyMenuItem(string text)
        {
            this.text = text;
        }

        public void Execute()
        {
            Console.WriteLine(this.text);
        }
    }

    public class MenuGroup : IMenuItem
    {
        IMenuItem[] menuItems;
        string text;
        public string MenuName { get { return text; } }

        public MenuGroup(string menuName, IMenuItem[] menuItems)
        {
            this.text = menuName;
            this.menuItems = menuItems;
        }

        public void Execute()
        {
            while (true)
            {
                DisplayMenu();
                int input = int.Parse(System.Console.ReadLine());

                if (input < menuItems.Length)
                {
                    menuItems[input].Execute();
                }
                else
                {
                    break;
                }
            }
        }

        public void DisplayMenu()
        {
            System.Console.WriteLine("============MENU==========");

            for (int i = 0; i < menuItems.Length; i++)
            {
                System.Console.WriteLine(i + ". " + menuItems[i].MenuName);
            }

            System.Console.WriteLine(menuItems.Length + ". Exit");
        }
    }
}
