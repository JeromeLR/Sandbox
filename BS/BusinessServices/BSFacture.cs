using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using BS.BSExtension;

namespace BS.BusinessServices
{
    public class BSFacture
    {
        private BusinessService Service;

        internal BSFacture(BusinessService bs)
        {
            Service = bs;
        }


        /* Facture */

        public List<TOFacture> GetAllFacture()
        {
            var f = Service.DomaineFacture.GetAllFacture();
            return f.ToTransferObject();
        }

        public TOFacture GetFactureById(int id)
        {
            var f = Service.DomaineFacture.GetFactureById(id);
            TOFacture tof = f.ToTransferObject();
            return tof;
        }

        public void Update(TOFacture tof)
        {
            Service.DomaineFacture.Update(tof.ToEntity());
        }
        public TOFacture Add(TOFacture tof)
        {
            var f = Service.DomaineFacture.Add(tof.ToEntity());
            return f.ToTransferObject();
        }

        public bool Delf(int id)
        {
            var lc = Service.DomaineFacture.Del(id);
            return true;
        }

        public void MajMontantFacture(int idFacture)
        {
            decimal total = 0;
            //recup totaux des lignes factures
            var listlf = Service.DomaineLigneCommande.GetLigneCommandeByIdFacture(idFacture);
            foreach (var lf in listlf)
            {
                total += (decimal)lf.Prix;
            }

            //maj
            var f = GetFactureById(idFacture);
            f.Montant = total;
            Update(f);
        }



        /* Lignes commande */

        public List<TOLigneCommande> GetAllLigneCommande()
        {
            var LignesCommande = Service.DomaineLigneCommande.GetAllLigneCommande();
            return LignesCommande.ToTransferObject();
        }

        public List<TOLigneCommande> GetLigneCommandeByIdFacture(int idFacture)
        {
            var LignesCommande = Service.DomaineLigneCommande.GetLigneCommandeByIdFacture(idFacture);
            return LignesCommande.ToTransferObject();
        }

        public TOLigneCommande GetLigneCommandeById(int id)
        {
            var LigneCommande = Service.DomaineLigneCommande.GetLigneCommandeById(id);
            TOLigneCommande toLC = LigneCommande.ToTransferObject();
            return toLC;
        }

        public void Update(TOLigneCommande toLC)
        {
            //recup prix articlepar id
            var article = Service.DomaineArticle.GetArticleById(toLC.toArticle.Identifiant);
            toLC.Prix = toLC.Quantite * article.Prix;
            

            Service.DomaineLigneCommande.Update(toLC.ToEntity());
            MajMontantFacture((int)toLC.IdFacture);
        }
        public TOLigneCommande Add(TOLigneCommande toLC)
        {
            //recup prix articlepar id
            var article = Service.DomaineArticle.GetArticleById(toLC.toArticle.Identifiant);
            toLC.Prix = toLC.Quantite * article.Prix;


            var lc = Service.DomaineLigneCommande.Add(toLC.ToEntity());
            MajMontantFacture((int)toLC.IdFacture);
            return lc.ToTransferObject();
            
        }

        public bool Del(int id)
        {
            var lc = Service.DomaineLigneCommande.Del(id);
            //todo : maj facture

            return true;
        }

    }
}
