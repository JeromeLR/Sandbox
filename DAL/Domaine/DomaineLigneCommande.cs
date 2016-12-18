using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Domaine
{
    public interface IDomaineLigneCommande
    {
        List<LigneCommande> GetAllLigneCommande();
        List<LigneCommande> GetLigneCommandeByIdFacture(int idFacture);
        LigneCommande GetLigneCommandeById(int id);
        void Update(LigneCommande lc);
        LigneCommande Add(LigneCommande lc);
        bool Del(int id);
    }

    /// <summary>
    /// Domaine Client
    /// </summary>
    public class DomaineLigneCommande :IDomaineLigneCommande
    {
        /// <summary>
        /// Retourne tous les clients
        /// </summary>
        /// <returns>liste de clients</returns>
        public List<LigneCommande> GetAllLigneCommande()
        {
            List<LigneCommande> lcs;
            using (var db = new modelEntities1())
            {
                lcs = db.LigneCommande.Include("Article.Categorie").ToList();
            }
            return lcs;
        }

        /// <summary>
        /// Retourne tous les lignesComm par idFacture
        /// </summary>
        /// <returns>liste de clients</returns>
        public List<LigneCommande> GetLigneCommandeByIdFacture(int idFacture)
        {
            List<LigneCommande> lcs;
            using (var db = new modelEntities1())
            {
                lcs = db.LigneCommande.Include("Article.Categorie").Where(lc=>lc.IdFacture == idFacture).ToList();
            }
            return lcs;
        }

        /// <summary>
        /// Retourne un client par son nom
        /// </summary>
        /// <param name="nom"></param>
        /// <returns>client</returns>
        public LigneCommande GetLigneCommandeById(int id)
        {
            LigneCommande ligneCommande;
            using (var db = new modelEntities1())
            {
                ligneCommande = db.LigneCommande.Include("Article.Categorie").First(c => c.Id == id);

            }
            return ligneCommande;
        }

        public void Update(LigneCommande lc)
        {
            using (var db = new modelEntities1())
            {
                var original = db.LigneCommande.Find(lc.Id);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(lc);
                    db.SaveChanges();
                }
            }

        }


        public LigneCommande Add(LigneCommande lc)
        {
            var newLC = new LigneCommande
            {
                Id = lc.Id,
                ArticleId = lc.ArticleId,
                Quantite=lc.Quantite,
                Prix=lc.Prix,
                IdFacture=lc.IdFacture
            };
            using (var db = new modelEntities1())
            {
                db.LigneCommande.Add(newLC);
                db.SaveChanges();
            }
            return newLC;
        }

        public bool Del(int id)
        {
            var lc = GetLigneCommandeById(id);
            using (var db = new modelEntities1())
            {

                db.LigneCommande.Attach(lc);
                db.LigneCommande.Remove(lc);
                db.SaveChanges();
                ; return true;
            }
        }

    }
}
