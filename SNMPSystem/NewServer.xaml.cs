using BusinessLogic;
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
        private Domain.ServerData ServerData{ get; set; }
        public NewServer()
        {
            InitializeComponent();
            ServerData = new Domain.ServerData();
            ServerData.SysNickname = string.Empty;
            ServerData.SysIP = string.Empty;
            ServerData.SysCommunity = string.Empty;
            this.DataContext = ServerData;
        }

        private void SaveNewServer(object sender, RoutedEventArgs e)
        {
            ServerDataDAO serverDataDAO = new ServerDataDAO();
            Boolean newServerInsert = serverDataDAO.InsertNewServer(ServerData);
            if (newServerInsert)
            {
                MessageHelper.SuccessfulOperation();
                CleanFields();

            }
            else 
            {
                MessageHelper.ConexionError();
            }
        }

        private void CleanFields()
        {
            ServerData.SysNickname = string.Empty;
            ServerData.SysIP = string.Empty;
            ServerData.SysCommunity = string.Empty;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
