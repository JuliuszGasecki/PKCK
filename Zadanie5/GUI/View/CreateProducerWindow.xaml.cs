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
using System.Windows.Shapes;
using GUI.Model;

namespace GUI.View
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class CreateProducerWindow : Window
    {
        public GamesCatalogModel.GameCatalogRoot GamesXml { get; set; }
        public string SelectedItem { get; set; }
 
        public static CreateProducerWindow AppWindow;
        public Delegate ReloadMain;
        public CreateProducerWindow(GamesCatalogModel.GameCatalogRoot gamesXml)
        {
            GamesXml = gamesXml;
            this.Title = "Create Producer";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AppWindow = this;
            InitializeComponent();
        }

        private void GetSelectedItem(object sender, MouseButtonEventArgs e)
        {
            string SelectedItem = (string)Currency.SelectedItems[0];
        }
    }
}
