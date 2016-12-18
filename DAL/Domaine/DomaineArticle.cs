using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Domaine
{
    public interface IDomaineArticle
    {
        List<Article> GetAllArticles();
        Article GetArticleByNom(string nom);
        Article GetArticleById(int id);
        Article Add(Article a);
        bool Del(int id);
        void Update(Article article);
    }

    /// <summary>
    /// Domaine Client
    /// </summary>
    public class DomaineArticle : IDomaineArticle
    {
        //Unity
        //private IDomaineArticle domaineArticle;
        //public DomaineArticle(IDomaineArticle DomaineArticle)
        //{
        //    this.domaineArticle = DomaineArticle;
        //}
        /// <summary>
        /// Retourne tous les clients
        /// </summary>
        /// <returns>liste de clients</returns>
        public List<Article> GetAllArticles()
        {
            List<Article> articles;
            using (var db = new modelEntities1())
            {
                articles = db.Article.Include("Categorie").ToList();
            }
            return articles;
        }

        /// <summary>
        /// Retourne un client par son nom
        /// </summary>
        /// <param name="nom"></param>
        /// <returns>client</returns>
        public Article GetArticleByNom(string nom)
        {
            Article article;
            using (var db = new modelEntities1())
            {
                article = db.Article.Include("Categorie").First(c => c.Nom == nom);
            }
            return article;
        }

        /// <summary>
        /// Retourne un Article par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>client</returns>
        public Article GetArticleById(int id)
        {
            Article article;
            using (var db = new modelEntities1())
            {
                article = db.Article.Include("Categorie").First(c => c.Id == id);
            }
            return article;
        }

        public Article Add(Article c)
        {
            var newArticle = new Article
            {
                //Id = c.Id,
                Categorie=c.Categorie,
                Nom=c.Nom,
                Prix=c.Prix,
                Stock=c.Stock
            };
            using (var db = new modelEntities1())
            {
                db.Article.Add(newArticle);
                db.SaveChanges();
            }
            return newArticle;
        }

        public bool Del(int id)
        {
            var article = GetArticleById(id);
            using (var db = new modelEntities1())
            {

                db.Article.Attach(article);
                db.Article.Remove(article);
                db.SaveChanges();
                ; return true;
            }
        }

        public void Update(Article article)
        {
            using (var db = new modelEntities1())
            {
                var original = db.Client.Find(article.Id);

                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(article);
                    db.SaveChanges();
                }
            }

        }
    }
}
