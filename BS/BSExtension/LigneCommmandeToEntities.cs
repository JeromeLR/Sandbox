using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BS.BSExtension
{
    public static class LigneCommandeToEntities
    {
        /// <summary>
        /// Transforme le TO en Entity
        /// </summary>
        /// <param name="listeToCommande">Tranfert Object</param>
        /// <returns>The Entity</returns>
        public static LigneCommande ToEntity(this TOLigneCommande toLigneCommande)
        {
            if (toLigneCommande == null)
            {
                return null;
            }

            LigneCommande entity = new LigneCommande
            {
                Id = toLigneCommande.Identifiant,
                IdFacture = toLigneCommande.IdFacture,
                ArticleId = toLigneCommande.toArticle.Identifiant,
                Quantite = toLigneCommande.Quantite,
                Prix = toLigneCommande.Prix
                    
            };
            return entity;
        }
    }
}
