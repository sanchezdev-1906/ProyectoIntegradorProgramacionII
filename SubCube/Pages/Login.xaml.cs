using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
using SubCube.Clases;

namespace SubCube.Pages
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            string user = TxtUser.Text;
            string password = TxtPassword.Password;
            if (!Auth(user, password))
            {
                MessageBox.Show("No se ha podido ingresar a la aplicacion");
                return;
            }

            NavigationService navigationService = NavigationService.GetNavigationService(this);

            if (navigationService != null)
            {
                navigationService.Navigate(new Uri("Pages/Navigation.xaml", UriKind.Relative));
            }
        }

        private bool Auth(string user, string password)
        {
            string DBPassword = null;
            DBConnector DBmanager = new DBConnector();
            try
            {
                using (SqlConnection connection = DBmanager.OpenConnection())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand($"SELECT password FROM Usuarios WHERE username = @UserName", connection))
                        {
                            command.Parameters.AddWithValue("@UserName", user);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    DBPassword = reader["password"].ToString();
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("Sucedio un error en la autenticacion");
                MessageBox.Show(E.Message);
                return false;
            }

            if (DBPassword == null)
            {
                MessageBox.Show("El usuario no existe");
                return false;
            }
            else if (DBPassword != password)
            {
                MessageBox.Show("Contraseña incorrecta");
                return false;
            }
            else
            {
                SaveData(user);
                return true;
            }
        }
        private void SaveData(string user)
        {
            DBConnector DBmanager = new DBConnector();
            try
            {
                using (SqlConnection connection = DBmanager.OpenConnection())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand($"SELECT username, fullname, description, cargo, alias FROM Usuarios WHERE username = @UserName", connection))
                        {
                            command.Parameters.AddWithValue("@UserName", user);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    ((App)Application.Current).User.username = reader["username"].ToString();
                                    ((App)Application.Current).User.fullname = reader["fullname"].ToString();
                                    ((App)Application.Current).User.alias = reader["alias"].ToString();
                                    ((App)Application.Current).User.description = reader["description"].ToString();
                                    ((App)Application.Current).User.cargo = reader["cargo"].ToString();
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("Sucedio un error en la autenticacion");
            }
        }
    }
}
