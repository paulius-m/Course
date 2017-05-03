using Dapper;
namespace ConsoleApp2
{
    class MySqlTest
    {
        public static void Main2(string[] args)
        {
            System.Console.WriteLine("Hello world");

            var s = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder();
            s.Server = "localhost";
            s.Port = 3311;
            s.UserID = "root";
            s.Password = "mpg123";
            s.Database = "mysql";

            using (System.Data.Common.DbConnection dbconnection = new MySql.Data.MySqlClient.MySqlConnection(s.ToString()))
            {
                dbconnection.Open();

                var persons = dbconnection.Query<string>("SELECT LastName FROM persons").AsList();
                persons.ForEach(ss => System.Console.WriteLine(ss));

                System.Console.ReadLine();
            }
        }
    }
}
