using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlRepository;

namespace ConsoleApp1
{
    interface IMenuItem
    {
        void Execute();
    }

    public abstract class RepositoryMenuItem : IMenuItem 
    {
        protected Repository repo;
        public RepositoryMenuItem(Repository pifas)
        {
            repo = pifas;
        }

        public abstract void Execute();
    }
    public class DisplayAllEmployeesMenuItem : RepositoryMenuItem
    {       

        public DisplayAllEmployeesMenuItem(Repository pifas) : base (pifas)
        {           
        }

        public override void Execute()
        {
            repo.DisplayAllEmployees();
        }

    }
    public class DisplayEmployeeMenuItem : RepositoryMenuItem
    {
        
        public DisplayEmployeeMenuItem(Repository pifas) : base(pifas)
        {            
        }

        public override void Execute()
        {
            int x = int.Parse(System.Console.ReadLine());
            repo.DisplayEmployee(x);            
        }
    }
    public class CreateEmployeeMenuItem : RepositoryMenuItem
    {
        public CreateEmployeeMenuItem(Repository pifas) : base(pifas)
        {
        }

        public override void Execute()
        {
            string firstname = System.Console.ReadLine();
            string lastname = System.Console.ReadLine();
            DateTime birthdate = DateTime.Parse(System.Console.ReadLine());
            DateTime hiredate = DateTime.Parse(System.Console.ReadLine());
            repo.CreateEmployee(firstname, lastname, birthdate, hiredate);
        }
    }
    public class ExitMenuItem : IMenuItem
    {
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
