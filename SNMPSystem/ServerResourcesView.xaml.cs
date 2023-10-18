using BusinessLogic;
using DataAccess;
using Domain;
using System;
using System.Collections;
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
using Xceed.Wpf.AvalonDock.Properties;
using System.Resources;
using objectsIDNames = Domain.ObjectsID;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System.Net;
using Microsoft.VisualBasic.FileIO;
using System.Windows.Threading;

namespace SNMPSystem
{
    public partial class ServerResourcesView : Page
    {
        public Domain.ServerData Server { get; set; }
        public ServerResourcesView(Domain.ServerData server)
        {
            InitializeComponent();
            this.Server = server;
            GetServerResources();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();

            GetServerResources();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            GetServerResources();
        }

        private void GetServerResources() 
        {
            ResourceManager rm = Domain.ObjectsID.ResourceManager;

            ResourceSet resourceSet = rm.GetResourceSet(System.Threading.Thread.CurrentThread.CurrentCulture, true, true);
            if (resourceSet != null)
            {
                foreach (DictionaryEntry entry in resourceSet)
                {
                    IPAddress.TryParse(Server.SysIP, out IPAddress ipAddress);
                    string targetObjectID = entry.Value.ToString();
                    var targetOid = new ObjectIdentifier(targetObjectID);
                    var variables = new List<Variable> { new Variable(targetOid) };
                    var community = new OctetString(Server.SysCommunity);
                    try
                    {
                        IList<Variable> responseVariables = Messenger.Get(VersionCode.V2, new IPEndPoint(ipAddress, Server.SysPort), community, variables, 6000);

                        if (responseVariables != null && responseVariables.Count > 0)
                        {
                            Variable variable = responseVariables[0];
                            MostrarValorOID(variable);
                        }
                        else
                        {
                            Console.WriteLine("No se recibió respuesta del dispositivo SNMP o se produjo un error.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }

        private void MostrarValorOID(Variable variable) 
        {
            if (objectsIDNames.ID_SysName == variable.Id.ToString())
            {
                TextBlock_SystemName.Text = variable.Data.ToString();
            }
            if (objectsIDNames.ID_SysDescr == variable.Id.ToString())
            {
                TextBlock_SystemDescription.Text = variable.Data.ToString();
            }
            if (objectsIDNames.ID_SysUptime == variable.Id.ToString())
            {
                TextBlock_SystemUptime.Text = variable.Data.ToString();
            }
            if (objectsIDNames.ID_PhysicalMemoryUsage == variable.Id.ToString())
            {
                float memorySize = (float.Parse(variable.Data.ToString())) / 1024;
                TextBlock_PhysicalMemoryUsage.Text = memorySize.ToString();
            }
            if (objectsIDNames.ID_AvailablePhysicalMemory == variable.Id.ToString())
            {
                float memorySize = (float.Parse(variable.Data.ToString()))/1024;
                TextBlock_AvailablePhysicalMemory.Text = memorySize.ToString();
            }
            if (objectsIDNames.ID_SysLocation == variable.Id.ToString())
            {
                TextBlock_SysLocation.Text = variable.Data.ToString();
            }
            if (objectsIDNames.ID_SysContact == variable.Id.ToString())
            {
                TextBlock_SysContact.Text = variable.Data.ToString();
            }
            if (objectsIDNames.ID_SysServices == variable.Id.ToString())
            {
                TextBlock_SysServices.Text = variable.Data.ToString();
            }
            if (objectsIDNames.ID_SysNumUsers == variable.Id.ToString())
            {
                TextBlock_SysNumUsers.Text = variable.Data.ToString();
            }
            if (objectsIDNames.ID_SysNumProcesses == variable.Id.ToString())
            {
                TextBlock_SysNumProcesses.Text = variable.Data.ToString();
            }

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
