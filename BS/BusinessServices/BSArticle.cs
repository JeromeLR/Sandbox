using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using BS.BSExtension;

namespace BS.BusinessServices
{
    public interface IBSArticle
    {
        TOArticle GetArticleById(int id);
        TOArticle GetArticleByNom(string nom);
        List<TOArticle> GetAllArticles();
        TOArticle Add(TOArticle toArticle);
        bool Del(int id);
        void Update(TOArticle toArticle);
    }

    public class BSArticle : IBSArticle
    {
        private BusinessService Service;

        public BSArticle(BusinessService bs)
        {
            Service = bs;
        }            

        public TOArticle GetArticleById(int id)
        {
            var article = Service.DomaineArticle.GetArticleById(id);
            return article.ToTransferObject();
        }
        public TOArticle GetArticleByNom(string nom)
        {
            var article = Service.DomaineArticle.GetArticleByNom(nom);
            return article.ToTransferObject();
        }

        public List<TOArticle> GetAllArticles()
        {
            var article = Service.DomaineArticle.GetAllArticles();
            return article.ToTransferObject();
        }

        public TOArticle Add(TOArticle toArticle)
        {
            var article = Service.DomaineArticle.Add(toArticle.ToEntity());
            return article.ToTransferObject();
        }

        public bool Del(int id)
        {
            var article = Service.DomaineArticle.Del(id);
            return true;
        }

        public void Update(TOArticle toArticle)
        {
            Service.DomaineArticle.Update(toArticle.ToEntity());
        }
    }
}
