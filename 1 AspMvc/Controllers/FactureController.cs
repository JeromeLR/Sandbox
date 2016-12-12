using BS;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TO;
using _1_AspMvc.Models;

namespace mvctest.Controllers
{
    public class FactureController : Controller
    {
        public ActionResult Index()
        {
            var bs = BusinessService.Instance;
            var lcs = bs.Facture.GetAllFacture();

            return View(lcs);
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
                var client = bs.Facture.GetFactureById(idi);
                if (client == null)
                {
                    return HttpNotFound();
                }
                return View(client);
            }

        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            var bs = BusinessService.Instance;
            List<TOClient> lToC = bs.Client.GetAllClients();
            FactureEdit fe = new FactureEdit
            {
                f = new TOFacture(),
                listClient = lToC
            };
            return View(fe);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TOFacture f)
        {
            var bs = BusinessService.Instance;
            if (ModelState.IsValid)
            {
                bs.Facture.Add(f);
                //bs.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(f);
        }

        //// GET: Clients/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    var bs = BusinessService.Instance;
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var idi = (int)id;
        //    TOFacture toLC = bs.Facture.GetFactureById(idi);
        //    if (toLC == null)
        //    {
        //        return HttpNotFound();
        //    }


        //    List<TOFacture> lToC = bs.Facture.GetAllFacture();

        //    List<TOArticle
        //        > lToA = bs.Article.GetAllArticles();

        //    #region client
        //    List<SelectListItem> listeClient = new List<SelectListItem>();
        //    foreach(var c in lToC){
        //        listeClient.Add(new SelectListItem {
        //            Value = c.Identifiant.ToString(),
        //            Text = c.Prenom +" "+ c.Nom
        //        });
        //    }
        //    TOClient cvm = new TOClient();
        //    //cvm.client = new SelectList(listeClient, "Value", "Text");
        //    #endregion client

        //    #region article
        //    List<SelectListItem> listeArticle = new List<SelectListItem>();
        //    foreach (var a in lToA)
        //    {
        //        listeArticle.Add(new SelectListItem
        //        {
        //            Value = a.Identifiant.ToString(),
        //            Text = a.Nom
        //        });
        //    };
        //    TOArticle avm = new TOArticle();
        //    //avm.article = new SelectList(listeArticle, "Value", "Text");
        //    #endregion article


        //    LigneCommandEdit lce = new LigneCommandEdit
        //    {
        //        lc = toLC,
        //        listClient = lToC,
        //        listArticle = lToA,
        //        //client = cvm,
        //        //article = avm
        //    };

        //    return View(lce);
        //}

        //// POST: Clients/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //public ActionResult Edit(LigneCommandEdit ligneCommandeEdit)
        //{
        //    var bs = BusinessService.Instance;

        //    var toLigneCommande = new TOLigneCommande
        //    {
        //        Identifiant = ligneCommandeEdit.lc.Identifiant,
        //        toClient = bs.Client.GetClientById(ligneCommandeEdit.lc.Identifiant),
        //        toArticle = bs.Article.GetArticleById(ligneCommandeEdit.lc.toArticle.Identifiant),
        //        Prix = ligneCommandeEdit.lc.Prix,
        //        Quantite = ligneCommandeEdit.lc.Quantite
        //    };

        //    bs.LigneCommande.Update(toLigneCommande);
        //    return RedirectToAction("Index");
        //}

        //// POST: Clients/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //public ActionResult EditAjax(LigneCommande ligneCommande)
        //{
        //    var bs = BusinessService.Instance;

        //    var toLigneCommande = new TOLigneCommande
        //    {
        //        Identifiant = ligneCommande.Identifiant,
        //        toClient = bs.Client.GetClientById(ligneCommande.IdClient),
        //        toArticle = bs.Article.GetArticleById(ligneCommande.IdArticle),
        //        Prix = ligneCommande.Prix,
        //        Quantite = ligneCommande.Quantite
        //    };


        //    bs.LigneCommande.Update(toLigneCommande);
        //    //return RedirectToAction("Index");

        //    return Json(Url.Action("Index", "LigneCommande"));
        //}




        //// GET: Clients/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    var bs = BusinessService.Instance;
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    int idi = (int)id;
        //    TOLigneCommande lc = bs.LigneCommande.GetLigneCommandeById(idi);
        //    if (lc == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(lc);
        //}

        //// POST: Clients/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var bs = BusinessService.Instance;
        //    //TOClient client = bs.Client.GetClientById(id);
        //    bs.LigneCommande.Del(id);
        //    //bs.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
