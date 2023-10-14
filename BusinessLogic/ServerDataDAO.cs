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
    }
}
