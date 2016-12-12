using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domaine;
using DAL;
using BS.BusinessServices;

namespace BS
{
    public class BusinessService
    {
         #region Singleton
        /// <summary>
        /// Singleton
        /// </summary>
        private static BusinessService _instance;

        /// <summary>
        /// Verrou du singleton _instance
        /// </summary>
        private static object instanceVerrou = new object();

        /// <summary>
        /// Accesseur du singleton
        /// </summary>
        public static BusinessService Instance
        {
            get
            {
                lock (instanceVerrou)
                {
                    if (_instance == null)
                    {
                        _instance = new BusinessService();
                    }

                    return _instance;
                }
            }
        }

        #endregion

       
        internal DomaineClient DomaineClient;
        public BSClient Client { get; private set; }

        internal DomaineArticle DomaineArticle;
        public BSArticle Article { get; private set; }

        internal DomaineLigneCommande DomaineLigneCommande;
        public BSLigneCommande LigneCommande { get; private set; }

        internal DomaineFacture DomaineFacture;
        public BSFacture Facture { get; private set; }


        private BusinessService()
        {
            DomaineClient = new DAL.Domaine.DomaineClient();
            Client = new BSClient(this);

            DomaineArticle = new DAL.Domaine.DomaineArticle();
            Article = new BSArticle(this);

            DomaineLigneCommande = new DAL.Domaine.DomaineLigneCommande();
            LigneCommande = new BSLigneCommande(this);

            DomaineFacture = new DAL.Domaine.DomaineFacture();
            Facture = new BSFacture(this);
        }
    }
}
