using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using BS.BSExtension;
using DAL.Entities;

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

        public int MAjStockProduit(int idProduit, int variation)
        {
            //recup totaux des lignes factures
            Article a = Service.DomaineArticle.GetArticleById(idProduit);
            a.Stock += variation;

            //maj staock
            Service.DomaineArticle.Update(a);

            return (int)a.Stock;
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
            // prix commande : recup prix article par id => prix
            var idArticle = toLC.toArticle.Identifiant;
            var article = Service.DomaineArticle.GetArticleById(idArticle);
            toLC.Prix = toLC.Quantite * article.Prix;

            // maj stock du produit
            int variation = (int)(article.Stock - toLC.Quantite);            
            toLC.toArticle.Stock = MAjStockProduit(idArticle, variation);

            // maj commande
            Service.DomaineLigneCommande.Update(toLC.ToEntity());

            // recalcul facture
            MajMontantFacture((int)toLC.IdFacture);
        }
        public TOLigneCommande Add(TOLigneCommande toLC)
        {
            // Montant facture : recup prix article par id
            var idArticle = toLC.toArticle.Identifiant;
            var article = Service.DomaineArticle.GetArticleById(idArticle);
            toLC.Prix = toLC.Quantite * article.Prix;

            // Maj Stock produit
            int variation = (int)(article.Stock - toLC.Quantite);
            toLC.toArticle.Stock = MAjStockProduit(idArticle, variation);

            // Ajout ligne commande
            var lc = Service.DomaineLigneCommande.Add(toLC.ToEntity());

            // Maj montant facture
            MajMontantFacture((int)toLC.IdFacture);
            return lc.ToTransferObject();
            
        }

        public bool Del(TOLigneCommande tolc)
        {
            // montant ligne de commande
            var lc = Service.DomaineLigneCommande.GetLigneCommandeById(tolc.Identifiant);
            var montantlc = lc.Prix;


            var del = Service.DomaineLigneCommande.Del(tolc.Identifiant);
            // Maj montantfacture

            var f = Service.DomaineFacture.GetFactureById((int)lc.IdFacture);
            f.Montant -= montantlc;
            MajMontantFacture((int)lc.IdFacture);

            return true;
        }


        
    }
}
