using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ServerResourcesDAO
    {
        public List<Domain.ServerResources> GetServersResourcesList(Domain.ServerData server)
        {
            List<Domain.ServerResources> serverResourcesListFound = new List<Domain.ServerResources>();
            using (var entities = new SNMPdbEntities())
            {
                List<DataAccess.ServerResources> serverResourcesListFind = new List<DataAccess.ServerResources>();
                serverResourcesListFind = (from serverResources in entities.ServerResources
                                           where serverResources.idServer == server.IdServer
                                           select serverResources).ToList();
                if (serverResourcesListFind.FirstOrDefault() != null)
                {
                    foreach (DataAccess.ServerResources serverResourceFound in serverResourcesListFind)
                    {
                        serverResourcesListFound.Add(new Domain.ServerResources(serverResourceFound));
                    }
                }
            }
            return serverResourcesListFound;
        }
    }
}
