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

        public ServerResources(DataAccess.ServerResources serverResources)
        {
            this.IdResource = serverResources.idResource;
            this.Name = serverResources.name;
            this.ObjectID = serverResources.objectID;
            this.Value = serverResources.objectID;
            this.IdServer = serverResources.idServer;
        }

        public DataAccess.ServerResources ConvertServerResourcesDomainToServerResourcesDataAccess()
        {
            return new DataAccess.ServerResources()
            {
                idResource = this.IdResource,
                name = this.Name,
                objectID = this.ObjectID,
                idServer = this.IdServer
            };
        }
    }
}
