using ComicsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicsStore.Controllers
{
    public class HomeController : Controller
    {
        private ComicsStoreEntities1 db = new ComicsStoreEntities1();
        public ActionResult Index(string searching)
        {
            return View(db.Products.Where(x => x.NamePro.Contains(searching) || searching == null).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
      
    }
}