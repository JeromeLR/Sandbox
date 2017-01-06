using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace _1_WebAPI.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
    }
}
