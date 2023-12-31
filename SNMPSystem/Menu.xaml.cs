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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SNMPSystem
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void WatchServerList(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ServerList());
        }

        private void AddNewServer(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NewServer());
        }
    }
}
