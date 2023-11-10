using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SubCube.Pages
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Page
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).ActualTheme == "Light")
            {
                ((App)Application.Current).ChangeTheme(new Uri("Themes/ThemeDark.xaml", UriKind.Relative));
                ((App)Application.Current).ActualTheme = "Dark";
            }
            else if (((App)Application.Current).ActualTheme == "Dark")
            {
                ((App)Application.Current).ChangeTheme(new Uri("Themes/ThemeLight.xaml", UriKind.Relative));
                ((App)Application.Current).ActualTheme = "Light";
            }
        }
    }
}
