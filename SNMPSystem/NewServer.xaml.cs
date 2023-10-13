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

namespace SNMPSystem
{
    /// <summary>
    /// Lógica de interacción para NewServer.xaml
    /// </summary>
    public partial class NewServer : Page
    {
        public Domain.ServerData ServerData{ get; set; }
        public NewServer()
        {
            InitializeComponent();
            this.DataContext = ServerData;
        }

        private void SaveNewServer(object sender, RoutedEventArgs e)
        {
            //save new server in database
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
