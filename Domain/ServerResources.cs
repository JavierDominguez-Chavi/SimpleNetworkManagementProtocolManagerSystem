using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ServerResources
    {
        public int IdResource { get; set; }
        public string Name { get; set; }
        public string ObjectID { get; set; }
        public string Value { get; set; }
        public int IdServer { get; set; }
        public int SysServices { get; set; }
        public string SysUpTime { get; set; }
        public string SysDescr { get; set; }
        public string SysName { get; set; }
        public string SysLocation { get; set; }
        public string SysContact { get; set; }


        public ServerResources(DataAccess.ServerResources serverResources)
        {
            this.IdResource = serverResources.idResource;
            this.Name = serverResources.name;
            this.ObjectID = serverResources.objectID;
            this.Value = serverResources.objectID;
            this.IdServer = serverResources.idServer;
            this.SysServices = serverResources.sysServices;
            this.SysUpTime = serverResources.sysUpTime;
            this.SysDescr = serverResources.sysDescr;
            this.SysName = serverResources.sysName;
            this.SysLocation = serverResources.sysLocation;
            this.SysContact = serverResources.sysContact;
    }

        public DataAccess.ServerResources ConvertServerResourcesDomainToServerResourcesDataAccess()
        {
            return new DataAccess.ServerResources()
            {
                idResource = this.IdResource,
                name = this.Name,
                objectID = this.ObjectID,
                idServer = this.IdServer,
                sysServices = this.SysServices,
                sysUpTime = this.SysUpTime,
                sysDescr = this.SysDescr,
                sysName = this.SysName,
                sysLocation = this.SysLocation,
                sysContact = this.SysContact

            };
        }
    }
}
