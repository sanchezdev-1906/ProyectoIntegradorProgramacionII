using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SubCube
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string ActualTheme = "Light";
        public void ChangeTheme(Uri dictionaryUri)
        {
            ResourceDictionary newDictionary = new ResourceDictionary();
            newDictionary.Source = dictionaryUri;
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(newDictionary);
        }
        
    }
}
