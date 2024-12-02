using Microsoft.Data.SqlClient;
using ProjectBlock8.ExampleCustumException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlock8.ExampleException
{
    public class ExampleDataBase
    {
        public void ExampleMetod()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-JV2NE4F\\SQLEXPRESS;Initial Catalog=GameStore;TrustServerCertificate=True; persist security info=True;Integrated Security=SSPI;";
                using SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Ошибка при работе с базой данных!");
                Console.WriteLine(ex.Message);
            }
            catch (CustomException ex)
            {
                Console.WriteLine("Произошла ошибка!");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally выполнен. Операция с базой данных завершена.");
            }
        }
    }
}
