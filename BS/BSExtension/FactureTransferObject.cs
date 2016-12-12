using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BS.BSExtension
{
    public static class FactureTransferObject
    {
        /// <summary>
        /// Transforme un LigneCommande en TOLigneCommande
        /// </summary>
        /// <param name="lc"></param>
        /// <returns></returns>
        public static TOFacture ToTransferObject(this Facture f)
        {
            if (f == null)
            {
                return null;
            }
            TOClient toClient = f.Client.ToTransferObject();

            TOFacture tof = new TOFacture
            {
                Identifiant = f.Id,
                toClient = toClient,
                Nom=f.Nom,
                Montant=f.Montant
                
            };

            return tof;
        }

        public static List<TOFacture> ToTransferObject(this List<Facture> listF)
        {
             
            List<TOFacture> listeToF = new List<TOFacture>();
            foreach (var toC in listF)
            {
                listeToF.Add(toC.ToTransferObject());
            };

            return listeToF;

            //return listLigneCommande.Select(c => c.ToTransferObject()).ToList();
        }
    }
}
