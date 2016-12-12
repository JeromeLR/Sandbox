using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BS.BSExtension
{
    public static class FactureToEntities
    {
        /// <summary>
        /// Transforme le TO en Entity
        /// </summary>
        /// <param name="listeToCommande">Tranfert Object</param>
        /// <returns>The Entity</returns>
        public static Facture ToEntity(this TOFacture toFacture)
        {
            if (toFacture == null)
            {
                return null;
            }

            Facture entity = new Facture
            {
                Id = toFacture.Identifiant,
                IdClient = toFacture.toClient.Identifiant,
                Nom = toFacture.Nom,
                Montant=toFacture.Montant
            };
            return entity;
        }
    }
}
