using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DZ_ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; 
                                      AttachDbFilename = D:\Users\MIKOLKA\DZ_ADO\DZ_ADO\DZ_ADO\DZ_ADO.mdf; Integrated Security = True";
            var con = new SqlConnection(connectionString);
            try
            {
                con.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Connection OK");

            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "CREATE TABLE Gruppa (id INT PRIMARY KEY IDENTITY(1,1), name NVARCHAR(50) NOT NULL CHECK(name <> ''))";
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("CREATED NEW");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("CREATED SKKIPED");
            }

            //cmd.CommandText = "INSERT INTO Test VALUES (N'Popitka 1')";
            //try
            //{
            //    cmd.ExecuteNonQuery();
            //    Console.WriteLine("INSERT OK");
            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine("INSERT 1 SKKIPED");
            //}

            //string str;
            //Console.WriteLine("Введите строки через <Enter>. Пустая строка - выход");
            //str = Console.ReadLine();
            //while(!str.Equals(""))
            //{
            //    str = str.Replace("'", "''");
            //    cmd.CommandText = $"INSERT INTO Test VALUES (N'{str}')";
            //    try
            //    {
            //        cmd.ExecuteNonQuery();
            //    }
            //    catch (SqlException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        Console.WriteLine(cmd.CommandText);
            //        Console.ReadKey();
            //        return;
            //    }
            //    str = Console.ReadLine();
            //}

            //SqlDataReader reader;
            //cmd.CommandText = "SELECT * FROM Test";
            //try
            //{
            //    reader = cmd.ExecuteReader();
            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.ReadKey();
            //    return;
            //}
            
            //while(reader.Read())
            //{
            //    Console.WriteLine("{0} {1}", reader.GetInt32(0), reader.GetString(1) );

            //}

            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
            con.Close();
            con.Dispose();


        }
    }
}
