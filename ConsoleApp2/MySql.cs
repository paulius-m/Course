using Dapper;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class MySqlTest
    {
        public static void Main2(string[] args)
        {
            MySqlConnectionStringBuilder s = new MySqlConnectionStringBuilder();
            s.Server = "localhost";
            s.Port = 3311;
            s.UserID = "root";
            s.Password = "mpg123";
            s.Database = "northwind";

            using (DbConnection dbconnection = new MySqlConnection(s.ToString()))
            {
                dbconnection.Open();

                var a = dbconnection.Query<int>("INSERT Employees " +
                        "(FirstName, LastName)" +
                        " VALUES (@FirstName, @LastName);" +
                    " SELECT CAST(LAST_INSERT_ID() AS UNSIGNED INTEGER)", new { FirstName = "A2", LastName = "A"  }).First();


                List<string> persons = dbconnection.Query<string>("SELECT FirstName FROM `Employees` WHERE EmployeeID = @EmployeeID ", new { EmployeeID = a } ).AsList();
                persons.ForEach(ss => System.Console.WriteLine(ss));

                System.Console.ReadLine();
            }
        }
    }
}
