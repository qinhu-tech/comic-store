using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComicsStore.Models;

namespace ComicsStore.Areas.Admin.Controllers
{
    
    public class ADHomeController : Controller
    {
        ComicsStoreEntities1 db = new ComicsStoreEntities1();
        // GET: Admin/ADHome
        [AdminAuthorize(ResourceKey = 1)]
        public ActionResult Index()
        {
            return View();
        }
        [AdminAuthorize(ResourceKey = 1)]
        public ActionResult Product()
        {
            var productList = db.Products.ToList();
            return View(productList);
        }
        [AdminAuthorize(ResourceKey = 1)]
        public ActionResult Customer()
        {
            var cusList = db.Customers.ToList();
            return View(cusList);
        }
        [HttpPost]
       
        public ActionResult Login(AdminUser _user)
        {
            var check = db.AdminUsers.Where(s => s.NameUser == _user.NameUser && s.PasswordUser == _user.PasswordUser).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai Thông Tin";
                return View("Login");
            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["NameUser"] = _user.NameUser;
                Session["PassUser"] = _user.PasswordUser;
                Session["ID"] = check.ID;
                Session["ADPriority"] = 1;
                return RedirectToAction("Index", "ADHome", new { area = "Admin" });
            }
        }
        public ActionResult Logout()
        {
            Session["NameUser"] = null;
            Session["PassUser"] = null;
            Session["ID"] = null;
            Session["ADPriority"] = null;
            return RedirectToAction("Index", "ADHome", new { area = "Admin" });
            
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}