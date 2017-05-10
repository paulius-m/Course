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
                            "SELECT EmployeeID, Firstname, LastName, BirthDate, HireDate " +
                            "FROM Employees " +
                            "WHERE EmployeeId = @Id",
                        new { Id = Id } ).AsList();
            
            if (allemployees1.Count > 0)
            {
                System.Console.WriteLine(
                    allemployees1[0].EmployeeID + " " +
                    allemployees1[0].FirstName + " " +
                    allemployees1[0].LastName + " " +
                    allemployees1[0].BirthDate.ToShortDateString() + " " +
                    allemployees1[0].HireDate.ToShortDateString());
            }
        }

        public void CreateEmployee(string FirstName, string LastName, DateTime BirthDate, DateTime HireDate)
        {
            string Notes = "Irasas";

            string processQuery = "INSERT INTO Employees (FirstName, LastName, BirthDate, HireDate, Notes) " +
                                  "VALUES (@FirstName1, @LastName1, @BirthDate1, @HireDate1, @Notes1)";
            dbconnection.Execute(processQuery, new { FirstName1 = FirstName,
                                                     LastName1 = LastName,
                                                     BirthDate1 = BirthDate,
                                                     HireDate1 = HireDate,
                                                     Notes1 = Notes }); // Notes reikalingas nes nuturi Defaul reiksmes
        }


        public void DeleteEmployee(int Id)
        {

            string processTerritories = "DELETE FROM EmployeeTerritories WHERE EmployeeID = @Id1";
            dbconnection.Execute(processTerritories, new { Id1 = Id });

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
