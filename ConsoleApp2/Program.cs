using System.Data.SqlClient;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbconnection = new SqlConnection("SERVER=localhost;DATABASE=mysql;user=root;password=mpg123"))
            {
                dbconnection.Open();
            }
        }
    }
}
