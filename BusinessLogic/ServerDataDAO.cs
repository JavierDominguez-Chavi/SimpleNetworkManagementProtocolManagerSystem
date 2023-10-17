using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ServerDataDAO
    {
        public Boolean InsertNewServer(Domain.ServerData serverData)
        {
            Boolean successful= false;
            using (var entities = new SNMPdbEntities())
            {
                entities.ServerData.Add(serverData.ConvertServerDataDomainToServerDataDataAccess());
                successful = entities.SaveChanges() == 1;
            }
            return successful;
        }

        public List<Domain.ServerData> GetServersList()
        {
            List<Domain.ServerData> serverListFound = new List<Domain.ServerData>();
            using (var entities = new SNMPdbEntities())
            {
                List<DataAccess.ServerData> serverListFind = new List<DataAccess.ServerData>();
                serverListFind = entities.ServerData.ToList();
                if (serverListFind.FirstOrDefault() != null)
                {
                    foreach (DataAccess.ServerData serverData in serverListFind)
                    {
                        serverListFound.Add(new Domain.ServerData(serverData));
                    }
                }
            }
            return serverListFound;
        }
    }
}
