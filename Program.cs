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
            while (true)
            {
                Console.Write("\tВыберите действия\n1.Дабавить\n2.Удалить\n3.Выбрать всё\n4.Выбрать один по Id\n5.Обновить\n6.Выход\n\n");
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
                                    string LastName = Console.ReadLine();
                                    Console.Write("FirstName: ");
                                    string FirstName = Console.ReadLine();
                                    Console.Write("MiddleName: ");
                                    string MiddleName = Console.ReadLine();
                                    Console.Write("BirthDate(2020-04-15): ");
                                    string date = Console.ReadLine();
                                    Command.CommandText = "Insert Into PersonTable(LastName,FirstName,MiddleName,BirthDate) Values('" + LastName + "','" + FirstName + "','" + MiddleName + "','" + Convert.ToDateTime(date) + "')";
                                    Command.ExecuteNonQuery();
                                    Transaction.Commit();
                                    Console.WriteLine("Данные успешно добавлен в базу данных!");
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
                            using (SqlConnection Connection = new SqlConnection(ConnectionString))
                            {
                                Connection.Open();
                                SqlTransaction Transaction = Connection.BeginTransaction();
                                SqlCommand Command = Connection.CreateCommand();
                                Command.Transaction = Transaction;
                                try
                                {
                                    Console.Write("Id: ");
                                    Command.CommandText = "Delete from PersonTable where Id='" + Console.Read() + "'";
                                    Command.ExecuteNonQuery();
                                    Transaction.Commit();
                                    Console.WriteLine("Данные успешно удален из база данных!");
                                }
                                catch (Exception ex)
                                {
                                    System.Console.WriteLine(ex.Message);
                                    Transaction.Rollback();
                                }
                            }

                        }
                        break;
                    case "3":
                        {
                            using (SqlConnection Connection = new SqlConnection(ConnectionString))
                            {
                                Connection.Open();
                                SqlTransaction Transaction = Connection.BeginTransaction();
                                SqlCommand Command = Connection.CreateCommand();
                                Command.Transaction = Transaction;
                                try
                                {
                                    Command.CommandText = "Select *from PersonTable";
                                    Command.ExecuteNonQuery();
                                    Transaction.Commit();
                                    Console.WriteLine("Все данные успешно выбран!");
                                }
                                catch (Exception ex)
                                {
                                    System.Console.WriteLine(ex.Message);
                                    Transaction.Rollback();
                                }
                            }
                        }
                        break;
                    case "4":
                        {
                            using (SqlConnection Connection = new SqlConnection(ConnectionString))
                            {
                                Connection.Open();
                                SqlTransaction Transaction = Connection.BeginTransaction();
                                SqlCommand Command = Connection.CreateCommand();
                                Command.Transaction = Transaction;
                                try
                                {
                                    Console.Write("Id: ");
                                    Command.CommandText = "Select *from PersonTable where Id=" + Console.Read() + "";
                                    Command.ExecuteNonQuery();
                                    Transaction.Commit();
                                    Console.WriteLine("Все данные по этого Id успешно выбран!");
                                }
                                catch (Exception ex)
                                {
                                    System.Console.WriteLine(ex.Message);
                                    Transaction.Rollback();
                                }
                            }
                        }
                        break;
                    case "5":
                        {
                            System.Console.Write("Какой столбец вы хотели обновить\n1.LastName\n2.FirstName\n3.MiddleName\n4.BirthDate");
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
                                                string LastName = Console.ReadLine();
                                                Command.CommandText = "update PersonTable set LastName ='" + LastName + "'";
                                                Command.ExecuteNonQuery();
                                                Transaction.Commit();
                                                Console.WriteLine("Все данные этого столбца успешно обновлен!");
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
                                        using (SqlConnection Connection = new SqlConnection(ConnectionString))
                                        {
                                            Connection.Open();
                                            SqlTransaction Transaction = Connection.BeginTransaction();
                                            SqlCommand Command = Connection.CreateCommand();
                                            Command.Transaction = Transaction;
                                            try
                                            {
                                                Console.Write("FirstName: ");
                                                string FirstName = Console.ReadLine();
                                                Command.CommandText = "update PersonTable set FirstName ='" + FirstName + "'";
                                                Command.ExecuteNonQuery();
                                                Transaction.Commit();
                                                Console.WriteLine("Все данные этого столбца успешно обновлен!");
                                            }
                                            catch (Exception ex)
                                            {
                                                System.Console.WriteLine(ex.Message);
                                                Transaction.Rollback();
                                            }
                                        }
                                    }
                                    break;
                                case "3":
                                    {
                                        using (SqlConnection Connection = new SqlConnection(ConnectionString))
                                        {
                                            Connection.Open();
                                            SqlTransaction Transaction = Connection.BeginTransaction();
                                            SqlCommand Command = Connection.CreateCommand();
                                            Command.Transaction = Transaction;
                                            try
                                            {
                                                Console.Write("MiddleName: ");
                                                string MiddleName = Console.ReadLine();
                                                Command.CommandText = "update PersonTable set MiddleName ='" + MiddleName + "'";
                                                Command.ExecuteNonQuery();
                                                Transaction.Commit();
                                                Console.WriteLine("Все данные этого столбца успешно обновлен!");
                                            }
                                            catch (Exception ex)
                                            {
                                                System.Console.WriteLine(ex.Message);
                                                Transaction.Rollback();
                                            }
                                        }
                                    }
                                    break;
                                case "4":
                                    {
                                        using (SqlConnection Connection = new SqlConnection(ConnectionString))
                                        {
                                            Connection.Open();
                                            SqlTransaction Transaction = Connection.BeginTransaction();
                                            SqlCommand Command = Connection.CreateCommand();
                                            Command.Transaction = Transaction;
                                            try
                                            {
                                                Console.Write("BirthDate(2020-04-15): ");
                                                string date = Console.ReadLine();
                                                Command.CommandText = "update PersonTable set BirthDate ='" + date + "'";
                                                Command.ExecuteNonQuery();
                                                Transaction.Commit();
                                                Console.WriteLine("Все данные этого столбца успешно обновлен!");
                                            }
                                            catch (Exception ex)
                                            {
                                                System.Console.WriteLine(ex.Message);
                                                Transaction.Rollback();
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    case "6": { return; }
                }
            }
        }
    }
}

