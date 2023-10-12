using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ServerData
    {
        public int IdServer { get; set; }
        public string SysDescr { get; set; }
        public string SysName { get; set; }
        public string SysLocation { get; set; }
        public string SysContact { get; set; }
        public string SysUpTime { get; set; }
        public string SysObjectID { get; set; }
        public int SysServices { get; set; }


        public ServerData() { }

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

            };
        }
    }
}
