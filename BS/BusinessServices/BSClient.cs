using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using BS.BSExtension;

namespace BS.BusinessServices
{
    public class BSClient
    {
        private BusinessService Service;

        internal BSClient(BusinessService bs)
        {
            Service = bs;
        }            

        public TOClient GetClientById(int id)
        {
            var client = Service.DomaineClient.GetClientById(id);
            return client.ToTransferObject();
        }
        public TOClient GetClientByNom(string nom)
        {
            var client = Service.DomaineClient.GetClientByNom(nom);
            return client.ToTransferObject();
        }

        public List<TOClient> GetAllClients()
        {
            var clients = Service.DomaineClient.GetAllClients();
            return clients.ToTransferObject();
        }

        public TOClient Add(TOClient toClient)
        {
            var client = Service.DomaineClient.Add(toClient.ToEntity());
            return client.ToTransferObject();
        }

        public bool Del(int id)
        {
            var client = Service.DomaineClient.Del(id);
            return true;
        }

        public void Update(TOClient toClient)
        {
            Service.DomaineClient.Update(toClient.ToEntity());
        }
    }
}
