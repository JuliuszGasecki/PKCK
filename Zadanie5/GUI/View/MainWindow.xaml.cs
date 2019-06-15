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
using GUI.Model;

namespace GUI.View
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GamesCatalogModel.GameCatalogRoot GamesXml { get; set; }
        public static MainWindow AppWindow;
        private void GetSelectedItemToUpdate(object sender, MouseButtonEventArgs e)
        {
            string item = (string)UpdateBox.SelectedItems[0];

        }

        private void GetSelectedItemToDelete(object sender, MouseButtonEventArgs e)
        {
            string item = (string)DeleteBox.SelectedItems[0];
        }

        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;
            this.Title = "PKCK Zadanie5";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
