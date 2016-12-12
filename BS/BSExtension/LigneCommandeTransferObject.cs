using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BS.BSExtension
{
    public static class LigneCommandeTransferObject
    {
        /// <summary>
        /// Transforme un LigneCommande en TOLigneCommande
        /// </summary>
        /// <param name="lc"></param>
        /// <returns></returns>
        public static TOLigneCommande ToTransferObject(this LigneCommande lc)
        {
            if (lc == null)
            {
                return null;
            }
            //TOClient toClient = lc.Client.ToTransferObject();
            TOArticle toArticle = lc.Article.ToTransferObject();

            TOLigneCommande toLigneCommande = new TOLigneCommande
            {
                Identifiant = lc.Id,
                Prix = lc.Prix,
                Quantite = lc.Quantite,
                toArticle = toArticle,
                IdFacture = lc.IdFacture
                
            };

            return toLigneCommande;
        }

        public static List<TOLigneCommande> ToTransferObject(this List<LigneCommande> listLc)
        {
             
            List<TOLigneCommande> listeToLC = new List<TOLigneCommande>();
            foreach (var toC in listLc)
            {
                listeToLC.Add(toC.ToTransferObject());
            };

            return listeToLC;

            //return listLigneCommande.Select(c => c.ToTransferObject()).ToList();
        }
    }
}
