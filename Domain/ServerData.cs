using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ServerData : INotifyPropertyChanged
    {
        public int IdServer { get; set; }
        public string SysDescr { get; set; }
        public string SysName { get; set; }

        private string sysNickName;
        public string SysNickname
        {
            get { return sysNickName; }
            set
            {
                if (value != sysNickName)
                {
                    sysNickName = value;
                    OnPropertyChanged(nameof(SysNickname));
                }
            }
        }
        public string SysLocation { get; set; }
        public string SysContact { get; set; }
        public string SysUpTime { get; set; }
        public string SysObjectID { get; set; }

        private string sysIP;
        public string SysIP
        {
            get { return sysIP; }
            set
            {
                if (value != sysIP)
                {
                    sysIP = value;
                    OnPropertyChanged(nameof(SysIP));
                }
            }
        }
        public int SysPort { get; set; }

        private string sysCommunity;
        public string SysCommunity
        {
            get { return sysCommunity; }
            set
            {
                if (value != sysCommunity)
                {
                    sysCommunity = value;
                    OnPropertyChanged(nameof(SysCommunity));
                }
            }
        }
        public int SysServices { get; set; }


        public ServerData() 
        {
            this.IdServer = 0;
            this.SysDescr = "#No Information!!!";
            this.SysName = "#No Information!!!";
            this.SysLocation = "#No Information!!!";
            this.SysContact = "#No Information!!!";
            this.SysUpTime = "#No Information!!!";
            this.SysObjectID = "#No Information!!!";
            this.SysServices = 0;
            this.SysNickname = "#No Information!!!";
            this.SysIP = "#No Information!!!";
            this.SysPort = 0;
            this.SysCommunity = "#No Information!!!";

        }

        public ServerData(DataAccess.ServerData serverData)
        {
            this.IdServer = serverData.idServer;
            this.SysDescr = serverData.sysDescr;
            this.SysName = serverData.sysName;
            this.SysLocation = serverData.sysLocation;
            this.SysContact = serverData.sysContact;
            this.SysUpTime = serverData.sysUpTime;
            this.SysObjectID = serverData.sysObjectID;
            this.SysServices = serverData.sysServices;
            this.SysNickname = serverData.sysNickname;
            this.SysIP = serverData.sysIP;
            this.SysPort = serverData.sysPort;
            this.SysCommunity = serverData.sysCommunity;    
        }

        public DataAccess.ServerData ConvertServerDataDomainToServerDataDataAccess()
        {
            return new DataAccess.ServerData()
            {
               idServer = this.IdServer,
               sysDescr = this.SysDescr,
               sysName = this.SysName,
               sysLocation = this.SysLocation,
               sysContact = this.SysContact,
               sysUpTime = this.SysUpTime, 
               sysObjectID = this.SysObjectID,
               sysServices = this.SysServices,
               sysNickname = this.SysNickname,
               sysIP = this.SysIP,
               sysPort = this.SysPort,
               sysCommunity = this.SysCommunity
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
