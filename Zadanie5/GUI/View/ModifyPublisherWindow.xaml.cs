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
    /// Logika interakcji dla klasy ModifyPublisherWindow.xaml
    /// </summary>
    public partial class ModifyPublisherWindow : Window
    {
        public GamesCatalogModel.GameCatalogRoot GamesXml { get; set; }
        public string Id { get; set; }
        public static ModifyPublisherWindow AppWindow;
        public Delegate ReloadMain;
        public ModifyPublisherWindow(string id, GamesCatalogModel.GameCatalogRoot gamesXml)
        {
            Id = id;
            GamesXml = gamesXml;
            this.Title = "Modify Publisher";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AppWindow = this;
            InitializeComponent();
        }
    }
}
