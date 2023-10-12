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
        public Domain.ServerData GetServerDataForId(int idServer)
        {
            Domain.ServerData serverDataobtained = new Domain.ServerData();
            using (var snmpEntities = new SNMPdbEntities())
            {
                var serverDataFound = snmpEntities.ServerData.Find(idServer);
                if (serverDataFound != null)
                {
                    serverDataobtained = new Domain.ServerData(serverDataFound);
                }
            }
            return serverDataobtained;
        }
    }
}
