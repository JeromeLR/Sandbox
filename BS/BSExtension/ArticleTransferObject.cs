using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BS.BSExtension
{
    public static class ArticleTransferObject
    {
        /// <summary>
        /// Transforme un Article en ToArticle
        /// </summary>
        /// <param name="typeProjet"></param>
        /// <returns></returns>
        public static TOArticle ToTransferObject(this Article article)
        {
            if (article == null)
            {
                return null;
            }

            TOArticle a = new TOArticle();

           

            TOCategorie toCategorie = article.Categorie.ToTransferObject();

            a.Identifiant = article.Id;
            a.Nom = article.Nom;
            a.Prix = article.Prix;
            a.toCategorie = toCategorie;
            a.Stock = article.Stock;
            a.affichageNomPrix = a.Nom +" "+ a.Prix.ToString()+"€";    
          

            return a;
        }

        public static List<TOArticle> ToTransferObject(this List<Article> listArticle)
        {
            List<TOArticle> listeToA = new List<TOArticle>();
            foreach (var toC in listArticle)
            {
                listeToA.Add(toC.ToTransferObject());
            };

            return listeToA;

            //return listArticle.Select(c => c.ToTransferObject()).ToList();
        }
    }
}
