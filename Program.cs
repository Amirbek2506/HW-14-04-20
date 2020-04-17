using System;
using System.Data;
using System.Data.SqlClient;

namespace MyprojecsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Queries DbControler = new Queries();
            while (true)
            {
                Console.Write("\tВыберите действия\n1.Дабавить\n2.Удалить\n3.Выбрать всё\n4.Выбрать один по Id\n5.Обновить\n6.Выход\n\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Console.Write("LastName: ");
                            string LastName = Console.ReadLine();
                            Console.Write("FirstName: ");
                            string FirstName = Console.ReadLine();
                            Console.Write("MiddleName: ");
                            string MiddleName = Console.ReadLine();
                            Console.Write("BirthDate(2020-04-15): ");
                            string BirthDate = Console.ReadLine();
                            DbControler.Insert(FirstName, LastName, MiddleName, BirthDate);
                        }
                        break;
                    case "2":
                        {
                            Console.Write("Id: ");
                           int Id=int.Parse(Console.ReadLine());
                            DbControler.Delete(Id);
                        }
                        break;
                    case "3":
                        {
                           DbControler.SelectAll();
                        }
                        break;
                    case "4":
                        {
                        Console.Write("Id: ");
                        int Id=int.Parse(Console.ReadLine());
                        DbControler.SelectById(Id);
                        }
                        break;
                    case "5":
                        {
                            Console.Write("LastName: ");
                            string LastName = Console.ReadLine();
                            Console.Write("FirstName: ");
                            string FirstName = Console.ReadLine();
                            Console.Write("MiddleName: ");
                            string MiddleName = Console.ReadLine();
                            Console.Write("BirthDate(2020-04-15): ");
                            string BirthDate = Console.ReadLine();
                            Console.Write("Id: ");
                            int Id=int.Parse(Console.ReadLine());
                            DbControler.UpdateById(Id,FirstName,LastName,MiddleName,BirthDate);
                        }
                        break;
                    case "6": { return; }
                }
            }
        }
        class Queries
        {
            SqlConnection connect = new SqlConnection(@"Data source=localhost; Initial catalog=Person; Integrated security=true");
            public void OpenConnection()
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
            }
            public void CloseConnection()
            {
                connect.Close();
            }
            public void Insert(string LastName, string FirstName, string MiddleName, string BirthDate)
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand("insert into PersonTable([LastName],[FirstName],[MiddleName],[BirthDate]) Values ('" + LastName + "','" + FirstName + "','" + MiddleName + "','" + Convert.ToDateTime(BirthDate) + "')", connect))
                {
                    int a = command.ExecuteNonQuery();
                    if (a > 0) { Console.WriteLine("Данные успешно добавлен в базу данных!"); }
                }
                CloseConnection();
            }
            public void SelectAll()
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand("Select * from PersonTable", connect))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            System.Console.WriteLine($"Id: {reader.GetValue(0)} | LastName: {reader.GetValue(1)} | FirstName: {reader.GetValue(2)} | MiddleName: {reader.GetValue(3)} | BirthDate: {reader.GetValue(4).ToString().Substring(0, 10)}");
                        }
                    }
                }
                CloseConnection();
            }
            public void SelectById(int Id)
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand("Select * from PersonTable where Id =" + Id, connect))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int c = 0;
                        while (reader.Read())
                        {
                            System.Console.WriteLine($"Id: {reader.GetValue(0)} | LastName: {reader.GetValue(1)} | FirstName: {reader.GetValue(2)} | MiddleName: {reader.GetValue(3)} | BirthDate: {reader.GetValue(4).ToString().Substring(0, 10)}");
                            c += (reader.GetValue(0).ToString() == Id.ToString()) ? 1 : 0;
                        }
                        if (c == 0)
                            System.Console.WriteLine("Такого Id не существует в базе данных!");
                    }
                }
                CloseConnection();
            }
            public void UpdateById(int Id, string LastName, string FirstName, string MiddleName, string BirthDate)
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand("UPDATE PersonTable set LastName = '" + LastName + "',FirstName ='" + FirstName + "',MiddleName ='" + MiddleName + "','"+Convert.ToDateTime(BirthDate)+"') where Id =" + Id, connect))
                {
                    if (command.ExecuteNonQuery() > 0)
                        Console.WriteLine("Updated PersonTable with " + Id + " Id!");
                    else
                        Console.WriteLine("Такого Id не существует в базе данных!");
                }
                CloseConnection();
            }
            public void Delete(int Id)
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand("Delete PersonTable where Id ='"+Id+"'", connect))
                {
                    if (command.ExecuteNonQuery() > 0)
                        Console.WriteLine("Успешно удалено!");
                    else
                        Console.WriteLine("Такого Id не существует в базе данных!");
                }
                CloseConnection();
            }
        }
    }
}
