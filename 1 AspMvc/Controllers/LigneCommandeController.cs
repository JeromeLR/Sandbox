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
    public class LigneCommandeController : Controller
    {
        public ActionResult Index()
        {
            var bs = BusinessService.Instance;
            var lcs = bs.Facture.GetAllLigneCommande();

            return View(lcs);
        }

        public ActionResult listByIdFacture(int idFacture, int idClient)
        {
            var bs = BusinessService.Instance;
            var lcs = bs.Facture.GetLigneCommandeByIdFacture(idFacture);
            var client = bs.Client.GetClientById(idClient);


            var ligneCommandesClient = new LigneCommandesClient
            {
                Client = client,
                ListCommande = lcs,
                IdFacture=idFacture
            };



            return View(ligneCommandesClient);
        }

        public ActionResult test()
        {
            var bs = BusinessService.Instance;
            var lcs = bs.Client.GetAllClients();

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
                var client = bs.Facture.GetLigneCommandeById(idi);
                if (client == null)
                {
                    return HttpNotFound();
                }
                return View(client);
            }

        }

        // GET: Clients/Create
        public ActionResult Create(int idFacture, int idClient)
        {
            var bs = BusinessService.Instance;
            List<TOArticle> lToA = bs.Article.GetAllArticles();
            #region article
            List<SelectListItem> listeArticle = new List<SelectListItem>();
            foreach (var a in lToA)
            {
                listeArticle.Add(new SelectListItem
                {
                    Value = a.Identifiant.ToString(),
                    Text = a.Nom
                });
            };
            TOArticle avm = new TOArticle();
            //avm.article = new SelectList(listeArticle, "Value", "Text");
            #endregion article

            LigneCommandEdit lce = new LigneCommandEdit
            {
                lc = new TOLigneCommande(),
                listArticle = lToA,
                idFacture = idFacture,            
                idClient = idClient
            };
            lce.lc.IdFacture = idFacture;
            
            return View(lce);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(LigneCommandEdit lce)
        {
            //lignecommande => TO
            var tolc = new TOLigneCommande();
            tolc = lce.lc;
            tolc.IdFacture = lce.idFacture;


            var bs = BusinessService.Instance;
            if (ModelState.IsValid)
            {
                bs.Facture.Add(tolc);
                return RedirectToAction("listByIdFacture", new { idFacture = tolc.IdFacture, idClient = lce.idClient });
                //return RedirectToAction("Index");
            }

            //return View(lce);
            return RedirectToAction("listByIdFacture", new { idFacture = tolc.IdFacture, idClient = lce.idClient });
        }

        // GET: lc/Edit/5
        public ActionResult Edit(int? id)
        {
            var bs = BusinessService.Instance;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var idi = (int)id;
            TOLigneCommande toLC = bs.Facture.GetLigneCommandeById(idi);
            if (toLC == null)
            {
                return HttpNotFound();
            }
            
            List<TOArticle> lToA = bs.Article.GetAllArticles();         
            #region article
            List<SelectListItem> listeArticle = new List<SelectListItem>();
            foreach (var a in lToA)
            {
                listeArticle.Add(new SelectListItem
                {
                    Value = a.Identifiant.ToString(),
                    Text = a.Nom
                });
            };
            TOArticle avm = new TOArticle();
            //avm.article = new SelectList(listeArticle, "Value", "Text");
            #endregion article
            
            LigneCommandEdit lce = new LigneCommandEdit
            {
                lc = toLC,
                listArticle = lToA,
                
            };

            return View(lce);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(LigneCommandEdit ligneCommandeEdit)
        {
            var bs = BusinessService.Instance;

            var toLigneCommande = new TOLigneCommande
            {
                Identifiant = ligneCommandeEdit.lc.Identifiant,
                toArticle = bs.Article.GetArticleById(ligneCommandeEdit.lc.toArticle.Identifiant),
                Quantite = ligneCommandeEdit.lc.Quantite,
                IdFacture=ligneCommandeEdit.lc.IdFacture
            };

            bs.Facture.Update(toLigneCommande);
            //return RedirectToAction("listByIdFacture", new { idFacture=toLigneCommande.IdFacture, idClient= ligneCommandeEdit.idClient});
            return RedirectToAction("Index", "Facture", new { area = "" });
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult EditAjax(LigneCommande ligneCommande)
        {
            var bs = BusinessService.Instance;

            var toLigneCommande = new TOLigneCommande
            {
                Identifiant = ligneCommande.Identifiant,
                //toClient = bs.Client.GetClientById(ligneCommande.IdClient),
                toArticle = bs.Article.GetArticleById(ligneCommande.IdArticle),
                Prix = ligneCommande.Prix,
                Quantite = ligneCommande.Quantite
            };


            bs.Facture.Update(toLigneCommande);
            //return RedirectToAction("Index");

            return Json(Url.Action("Index", "LigneCommande"));
        }




        // GET: Clients/Delete/5
        //public ActionResult Delete(int? id)
        public ActionResult Delete(int id)
        {
            var bs = BusinessService.Instance;
            //if (lce.lc.Identifiant == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            int idi = (int)id;
            TOLigneCommande tolc = bs.Facture.GetLigneCommandeById(idi);

            

            if (tolc == null)
            {
                return HttpNotFound();
            }

            LigneCommandEdit lce = new LigneCommandEdit
            {
                lc = tolc,
                idFacture = (int)tolc.IdFacture
            };

            return View(lce);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(LigneCommandEdit lce)
        {
            var bs = BusinessService.Instance;
            bs.Facture.Del(lce.lc);
            //return RedirectToAction("listByIdFacture");
            return RedirectToAction("Index", "Facture", new { area = "" });
        }



    }
}
