using BS;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TO;

namespace mvctest.Controllers
{
    public class ClientsController : Controller
    {            
        
        // GET: Clients
        public ActionResult Index()
        {
            var bs = BusinessService.Instance;
            var clients = bs.Client.GetAllClients();
            return View(clients);
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
                var client = bs.Client.GetClientById(idi);
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
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identifiant,Nom,Age,DateInscription,TypeInscription,Prenom")] TOClient client)
        {
            var bs = BusinessService.Instance;
            if (ModelState.IsValid)
            {
                bs.Client.Add(client);
                //bs.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
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
            TOClient client = bs.Client.GetClientById(idi);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identifiant,Nom,Age,DateInscription,TypeInscription,Prenom")] TOClient client)
        {
            var bs = BusinessService.Instance;
            if (ModelState.IsValid)
            {
                // bs.Entry(client).State = EntityState.Modified;
                //bs.SaveChanges();
                bs.Client.Update(client);
                return RedirectToAction("Index");
            }
            return View(client);
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
            TOClient client = bs.Client.GetClientById(idi);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var bs = BusinessService.Instance;
            //TOClient client = bs.Client.GetClientById(id);
            bs.Client.Del(id);
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
