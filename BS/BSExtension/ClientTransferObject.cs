using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BS.BSExtension
{
    public static class ClientTransferObject
    {
        /// <summary>
        /// Transforme un Clinet en ToClient
        /// </summary>
        /// <param name="typeProjet"></param>
        /// <returns></returns>
        public static TOClient ToTransferObject(this Client client)
        {
            if (client == null)
            {
                return null;
            }
            TOClient toClient = new TOClient
            {
                Identifiant = client.Id,
                Nom = client.Nom,
                Prenom = client.Prenom,
                Age = client.Age
            };
            return toClient;
        }

        public static List<TOClient> ToTransferObject(this List<Client> listClient)
        {
            //List<TOClient> toClient = new List<TOClient>();
            //foreach (var client in listClient)
            //{
            //    listClient.Add(client.ToTransferObject());
            //};

            //return toClient;

            return listClient.Select(c => c.ToTransferObject()).ToList();
        }
    }
}
