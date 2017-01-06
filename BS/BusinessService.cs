using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domaine;
using DAL;
using BS.BusinessServices;


// todo Question : appel d'un BS à partir d'un autre : passer par les domaines de la DAL ?
// todo Factorisation des BS ?
// todo MVC : bonne définitions des modèles ?


namespace BS
{
    //unity
    public interface IBusinessService
    {
        //private static object instanceVerrou = new object();
    }

    public class BusinessService : IBusinessService
    {
         #region Singleton
        /// <summary>
        /// Singleton
        /// </summary>
        public static BusinessService _instance;

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

                
        public IDomaineClient DomaineClient;
        public BSClient Client { get; private set; }

        public IDomaineArticle DomaineArticle;
        public BSArticle Article { get; private set; }

        public IDomaineLigneCommande DomaineLigneCommande;
        public BSLigneCommande LigneCommande { get; private set; }

        public IDomaineFacture DomaineFacture;
        public BSFacture Facture { get; private set; }


        //unity : private=>public
        public BusinessService()
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
