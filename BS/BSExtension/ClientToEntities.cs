using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BS.BSExtension
{
    public static class ClientToEntities
    {
        /// <summary>
        /// Transforme le TO en Entity
        /// </summary>
        /// <param name="listeToCommande">Tranfert Object</param>
        /// <returns>The Entity</returns>
        public static Client ToEntity(this TOClient toClient)
        {
            if (toClient == null)
            {
                return null;
            }

            Client entity = new Client
            {
                Id = toClient.Identifiant,
                Nom = toClient.Nom,
                Prenom = toClient.Prenom,
                Age = toClient.Age          
            };
            return entity;
        }
    }
}
