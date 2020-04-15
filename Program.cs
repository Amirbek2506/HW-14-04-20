using System;
using System.Data;
using System.Data.SqlClient;

namespace MyprojecsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = @"Data source=localhost;initial catalog=Person;Integrated Security=True";
            SqlConnection Connection = new SqlConnection(ConnectionString);
            
            Console.ReadKey();
        }
    }
}
