﻿using System;
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
    /// Logika interakcji dla klasy CreatePublisherWindow.xaml
    /// </summary>
    public partial class CreatePublisherWindow : Window
    {
        public GamesCatalogModel.GameCatalogRoot GamesXml { get; set; }

        public static CreatePublisherWindow AppWindow;
        public Delegate ReloadMain;
        public CreatePublisherWindow(GamesCatalogModel.GameCatalogRoot gamesXml)
        {
            GamesXml = gamesXml;
            this.Title = "Create Publisher";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AppWindow = this;
            InitializeComponent();
        }
    }
}
