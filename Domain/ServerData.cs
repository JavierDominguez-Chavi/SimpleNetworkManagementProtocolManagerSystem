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


        public ServerData() 
        {
            this.IdServer = 0;
            this.SysNickname = "#No Information!!!";
            this.SysIP = "#No Information!!!";
            this.SysPort = 161;
            this.SysCommunity = "#No Information!!!";

        }

        public ServerData(DataAccess.ServerData serverData)
        {
            this.IdServer = serverData.idServer;
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
