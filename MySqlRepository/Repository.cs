using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MySql.Data.MySqlClient;
using System.Data.Common;
using Dapper;

namespace MySqlRepository
{
    public class Repository
    {
        private DbConnection dbconnection;

        public Repository()
        {
            dbconnection = GetConnection();
        }

       

        private DbConnection GetConnection()
        {
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
            stringBuilder.Server = "localhost";
            stringBuilder.UserID = "root";
            stringBuilder.Password = "mpg123";
            stringBuilder.Port = 3311;
            stringBuilder.Database = "northwind";

            DbConnection dbconnection = new MySqlConnection(stringBuilder.ToString());
            return dbconnection;
        }

        public void DisplayAllEmployees()
        {
            List <Employee> allemployees = dbconnection
                        .Query<Employee>(
                        "SELECT EmployeeID, Firstname, LastName "+
                        "FROM Employees;")
                         .AsList();

            for (int i = 0; i < allemployees.Count; i++)
            {
                System.Console.WriteLine(allemployees[i].EmployeeID + " " 
                    + allemployees[i].FirstName + " " + allemployees[i].LastName);
            }
        }

        public void DisplayEmployee(int Id)
        {
            List<Employee> allemployees1 = dbconnection
                        .Query<Employee>(
                            "SELECT EmployeeID, Firstname, LastName " +
                            "FROM Employees " +
                            "WHERE EmployeeId = @Id",
                        new { Id = Id } ).AsList();
            
            if (allemployees1.Count > 0)
            {
                System.Console.WriteLine(
                    allemployees1[0].EmployeeID + " " +
                    allemployees1[0].FirstName + " " +
                    allemployees1[0].LastName);
            }
        }

        public void CreateEmployee(string FirstName, string LastName)
        {
            string Notes = "Irasas";

            string processQuery = "INSERT INTO Employees (FirstName, LastName, Notes) " +
                                  "VALUES (@FirstName1, @LastName1, @Notes1)";
            dbconnection.Execute(processQuery, new { FirstName1 = FirstName, LastName1 = LastName, Notes1 = Notes }); // Notes reikalingas nes nuturi Defaul reiksmes
        }


        public void DeleteEmployee(int Id)
        {
            string processQuery = "DELETE FROM Employees WHERE EmployeeID = @Id1";
            dbconnection.Execute(processQuery, new { Id1 = Id });
        }


        public void UpdateEmployee(Employee emp)
        {
            string processQuery = "UPDATE Employees " +
                                  "SET FirstName = @FirstName, LastName = @LastName " +
                                  "WHERE EmployeeID = @EmployeeID";
            dbconnection.Execute(processQuery, emp);
        }
    }
}
