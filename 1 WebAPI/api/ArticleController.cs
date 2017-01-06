using BS;
using BS.BusinessServices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TO;

namespace CrudOperation.api
{
    // Route 
    [RoutePrefix("api/Article")]
    public class ArticleController : ApiController
    {
        //Unity
        private IBSArticle BSArticle;
        public ArticleController() { }
        public ArticleController(IBSArticle BSArticle)
        {
            this.BSArticle = BSArticle;
        }
        //private BusinessService bs
        //{
        //    get { return bs; }
        //    set { bs = BusinessService.Instance; }
        //}

        [ResponseType(typeof(TOArticle))]
        [HttpPost]
        public HttpResponseMessage SaveArticle(TOArticle article)
        {
            var bs = BusinessService.Instance;
            int result = 0;
            try
            {
                bs.Article.Add(article);
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        [ResponseType(typeof(TOArticle))]
        [HttpPut]
        public HttpResponseMessage UpdateArticle(TOArticle article)
        {
            var bs = BusinessService.Instance;
            int result = 0;
            try
            {
                bs.Article.Update(article);
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [ResponseType(typeof(TOArticle))]
        [HttpDelete]
        public HttpResponseMessage DeleteArticle(int id)
        {
            var bs = BusinessService.Instance;
            int result = 0;
            try
            {
                bs.Article.Del(id);
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("GetArticleByID/{ArticleID:int}")]
        [ResponseType(typeof(TOArticle))]
        [HttpGet]
        public TOArticle GetArticleByID(int articleID)
        {
            var bs = BusinessService.Instance;
            TOArticle article = null;
            try
            {
                article = bs.Article.GetArticleById(articleID);
            }
            catch (Exception e)
            {
                article = null;
            }

            return article;
        }

        [ResponseType(typeof(TOArticle))]
        [HttpGet]
        public List<TOArticle> GetArticles()
        {
            var bs = BusinessService.Instance;
            List<TOArticle> articles = null;
            try
            {
                articles = bs.Article.GetAllArticles();

            }
            catch (Exception e)
            {
                articles = null;
            }

            return articles;
        }



    }
}
