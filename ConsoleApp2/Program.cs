using MySqlRepository;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            IRepository repo = new Repository();

            IMenuItem[] subMenuItems = new IMenuItem[2];
            subMenuItems[0] = new EmptyMenuItem("not implementent.");
            subMenuItems[1] = new EmptyMenuItem("not implementent.");

            IMenuItem submenu = new MenuGroup("SubMenu", subMenuItems);

            IMenuItem[] menuItems = new IMenuItem[6];

            menuItems[0] = submenu;
            menuItems[1] = new DisplayAllEmployeesMenuItem(repo);
            menuItems[2] = new DisplayEmployeeMenuItem(repo);
            menuItems[3] = new CreateEmployeeMenuItem(repo);
            menuItems[4] = new DeleteEmployeeMenuItem(repo);
            menuItems[5] = new UpdateEmployeeMenuItem(repo);

            IMenuItem mainMenu = new MenuGroup("SubMenu", menuItems);
            mainMenu.Execute();
        }
    }
}