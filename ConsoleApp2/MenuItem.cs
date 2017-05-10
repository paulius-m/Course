﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlRepository;

namespace ConsoleApp1
{
    public abstract class MenuItem
    {
        public MenuItem()
        {
        }
        public abstract void Execute();
        
    }
    public abstract class RepositoryMenuItem : MenuItem 
    {
        protected Repository repo;
        public RepositoryMenuItem(Repository pifas)
        {
            repo = pifas;
        }
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
    public class ExitMenuItem : MenuItem
    {
        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
