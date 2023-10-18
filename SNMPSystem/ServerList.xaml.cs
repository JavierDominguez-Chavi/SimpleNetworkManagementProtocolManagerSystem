using BusinessLogic;
using DataAccess;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class ServerList : Page
    {
        public ObservableCollection<Domain.ServerData> ServersList { get; set; }
        public ServerList()
        {
            InitializeComponent();
            ServersList = new ObservableCollection<Domain.ServerData>();
            this.DataContext = this;
        }

        private void LoadInformationPage(object sender, RoutedEventArgs e)
        {
            ServerDataDAO serverDataDAO = new ServerDataDAO();
            ServersList = new ObservableCollection<Domain.ServerData>(serverDataDAO.GetServersList());
            if (ServersList.FirstOrDefault() != null)
            {
                CollectionViewSource ViewSource_Servers =
                    ((CollectionViewSource)(this.FindResource("ViewSource_Servers")));
                ViewSource_Servers.Source = ServersList;
            }
            else
            {
                MessageHelper.ConexionError();
                this.NavigationService.GoBack();
            }
        }

        private void DeleteServerSelected(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultadoMessageBox = MessageBox.Show("The server information will be deleted, Are You Sure?", "Confirmación", 
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (resultadoMessageBox == MessageBoxResult.Yes)
            {
                Domain.ServerData serverData = (sender as Button).Tag as Domain.ServerData;
                ServerDataDAO serverDataDAO = new ServerDataDAO();
                if (serverDataDAO.DeleteServerFirId(serverData))
                {
                    MessageHelper.SuccessfulOperation();
                    ServersList.Remove(serverData);
                }
                else
                {
                    MessageHelper.ConexionError();
                }
            }
        }

        private void ViewSelectedServerResources(object sender, RoutedEventArgs e)
        {
            Domain.ServerData server = (sender as Button).Tag as Domain.ServerData;
            this.NavigationService.Navigate(new ServerResourcesView(server));
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
