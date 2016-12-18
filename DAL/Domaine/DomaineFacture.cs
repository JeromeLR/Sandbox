using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Domaine
{

    public interface IDomaineFacture
    {
        List<Facture> GetAllFacture();
        Facture GetFactureById(int id);
        void Update(Facture f);
        Facture Add(Facture f);
        bool Del(int id);
    }
    /// <summary>
    /// Domaine Client
    /// </summary>
    public class DomaineFacture :IDomaineFacture
    {
        /// <summary>
        /// Retourne tous les clients
        /// </summary>
        /// <returns>liste de clients</returns>
        public List<Facture> GetAllFacture()
        {
            List<Facture> lcs;
            using (var db = new modelEntities1())
            {
                lcs = db.Facture.Include("Client").ToList();
            }
            return lcs;
        }

        // <summary>
        // Retourne un client par son nom
        // </summary>
        // <param name = "nom" ></ param >
        // < returns > client </ returns >
        public Facture GetFactureById(int id)
        {
            Facture facture;
            using (var db = new modelEntities1())
            {
                facture = db.Facture.Include("Client").First(c => c.Id == id);

            }
            return facture;
        }

        public void Update(Facture f)
        {
            using (var db = new modelEntities1())
            {
                var original = db.Facture.Find(f.Id);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(f);
                    db.SaveChanges();
                }
            }

        }


        public Facture Add(Facture f)
        {
            var newLC = new Facture
            {
                Id = f.Id,
                IdClient = f.IdClient,
                Nom=f.Nom
            };
            using (var db = new modelEntities1())
            {
                db.Facture.Add(newLC);
                db.SaveChanges();
            }
            return newLC;
        }

        public bool Del(int id)
        {
            var lc = GetFactureById(id);
            using (var db = new modelEntities1())
            {
                db.Facture.Attach(lc);
                db.Facture.Remove(lc);
                db.SaveChanges();
                return true;
            }
        }

        
        

    }
}
