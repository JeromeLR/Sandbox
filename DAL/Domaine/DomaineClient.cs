using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Domaine
{
    public interface IDomaineClient
    {
        List<Client> GetAllClients();
        Client GetClientByNom(string nom);
        Client GetClientById(int id);
        Client Add(Client c);
        bool Del(int id);
        void Update(Client client);
    }

    /// <summary>
    /// Domaine Client
    /// </summary>
    public class DomaineClient : IDomaineClient
    {
        /// <summary>
        /// Retourne tous les clients
        /// </summary>
        /// <returns>liste de clients</returns>
        public List<Client> GetAllClients()
        {
            List<Client> clients;
            using(var db = new modelEntities1()) {
                clients = db.Client.Include("TypeSouscription").ToList();
            }
            return clients;
        }
        
        /// <summary>
        /// Retourne un client par son nom
        /// </summary>
        /// <param name="nom"></param>
        /// <returns>client</returns>
        public Client GetClientByNom(string nom)
        {
            Client client;
            using (var db = new modelEntities1())
            {
                client = db.Client.Include("TypeSouscription").First(c=>c.Nom == nom);
            }
            return client;
        }

        /// <summary>
        /// Retourne un client par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>client</returns>
        public Client GetClientById(int id)
        {
            Client client;
            using (var db = new modelEntities1())
            {
                client = db.Client.Include("TypeSouscription").First(c => c.Id == id);
            }
            return client;
        }
        
        public Client Add(Client c)
        {
            var newClient = new Client{
                Id = c.Id,
                Age = c.Age,
                DateInscription = c.DateInscription,
                Nom = c.Nom,
                Prenom = c.Prenom,
                IdTypeSouscription = c.IdTypeSouscription
            };
            using (var db = new modelEntities1())
            {
                db.Client.Add(newClient);
                db.SaveChanges();
            }
            return newClient;
        }

        public bool Del(int id)
        {
            var client = GetClientById(id);
            using (var db = new modelEntities1())
            {

                db.Client.Attach(client);                
                db.Client.Remove(client);
                db.SaveChanges();
;                return true;
            }
        }

        public void Update(Client client)
        {
            using (var db = new modelEntities1())
            {
                var original = db.Client.Find(client.Id);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(client);
                    db.SaveChanges();
                }
            }
           
        }
    }
}
