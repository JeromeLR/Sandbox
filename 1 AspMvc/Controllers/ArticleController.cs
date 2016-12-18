using BS;
using BS.BusinessServices;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TO;

namespace mvctest.Controllers
{
    public class ArticleController : Controller
    {
        //Unity
        private IBSArticle BSArticle;
        public ArticleController(IBSArticle BSArticle)
        {
            this.BSArticle = BSArticle;
        }

        //bs
        //private BusinessService bs
        //{
        //    get { return bs; }
        //    set { bs = BusinessService.Instance; }
        //}

        // GET: 
        public ViewResult Index()
        {
            var bs = BusinessService.Instance;
            var articles = bs.Article.GetAllArticles();
            return View(articles);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            var bs = BusinessService.Instance;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                int idi = (int)id;
                var article = bs.Article.GetArticleById(idi);
                if (article == null)
                {
                    return HttpNotFound();
                }
                return View(article);
            }
            
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TOArticle article)
        {
            var bs = BusinessService.Instance;
            if (ModelState.IsValid)
            {
                bs.Article.Add(article);
                //bs.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            var bs = BusinessService.Instance;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var idi = (int)id;
            TOArticle article = bs.Article.GetArticleById(idi);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TOArticle toArticle)
        {
            var bs = BusinessService.Instance;
            if (ModelState.IsValid)
            {
                // bs.Entry(client).State = EntityState.Modified;
                //bs.SaveChanges();
                bs.Article.Update(toArticle);
                return RedirectToAction("Index");
            }
            return View(toArticle);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            var bs = BusinessService.Instance;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int idi = (int)id;
            TOArticle article = bs.Article.GetArticleById(idi);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var bs = BusinessService.Instance;
            //TOClient client = bs.Client.GetClientById(id);
            bs.Article.Del(id);
            //bs.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            var bs = BusinessService.Instance;
            if (disposing)
            {
                //bs.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
