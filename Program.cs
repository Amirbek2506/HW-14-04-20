using System;
using System.Data;
using System.Data.SqlClient;

namespace MyprojecsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ConnectionString = @"Data source=localhost;initial catalog=Person;Integrated Security=True";
            while(true){
            Console.Write("\tВыберите действия\n1.Дабавить\n2.Удалить\n3.Выбрать всё\n4.Выбрать один по Id\n5.Обновить\n");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        using (SqlConnection Connection = new SqlConnection(ConnectionString))
                        {
                            Connection.Open();

                            SqlTransaction Transaction = Connection.BeginTransaction();
                            SqlCommand Command = Connection.CreateCommand();
                            Command.Transaction = Transaction;
                            try
                            {
                                Console.Write("LastName: ");
                                string LN=Console.ReadLine();
                                Console.Write("FirstName: ");
                                string FN=Console.ReadLine();
                                Console.Write("MiddleName: ");
                                string MN=Console.ReadLine();
                                Console.Write("BirthDate: ");
                                DateTime newDate = new DateTime(2019, 12,25, 10,50,30);
                                
                                Command.CommandText = "Insert Into PersonTable(LastName,FirstName,MiddleName,BirthDate) Values('LN','FN','MN',newData";
                                Command.ExecuteNonQuery();
                                Transaction.Commit();
                                Console.WriteLine("Данные успешно добавлен в базу данных");
                            }
                            catch (Exception ex)
                            {
                                System.Console.WriteLine(ex.Message);
                                Transaction.Rollback();
                            }
                        }
                    }
                    break;
                case "2":
                {

                }break;

            }
            }
        }
    }
}
