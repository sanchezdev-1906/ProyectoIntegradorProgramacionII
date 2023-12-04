using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SubCube.Clases
{
    class DBConnector
    {
        private string connectionString = $"Data Source=LAPTOP-ASUS;Initial Catalog=TeamTalker;User ID=sa;Password=joelsanchz;Encrypt=FALSE;";
        public SqlConnection OpenConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
                 
            catch (Exception ex)
            {
                Console.WriteLine($"Error al abrir la conexión: {ex.Message}");
                throw; 
            }
        }

        public void CloseConnection(SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cerrar la conexión: {ex.Message}");
            }
        }
    }
}