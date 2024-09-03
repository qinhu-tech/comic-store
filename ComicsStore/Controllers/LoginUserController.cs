using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComicsStore.Models;


namespace ComicsStore.Controllers
{
    public class LoginUserController : Controller
    {
        // GET: LoginUser
        private ComicsStoreEntities1 db = new ComicsStoreEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAcount(Customer _user)
        {
            var check = db.Customers.Where(s => s.NameCus == _user.NameCus && s.PassCus == _user.PassCus).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai Thông Tin";
                return View("Login");
            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["NameCus"] = _user.NameCus;
                Session["PassCus"] = _user.PassCus;
                Session["IDCus"] = check.IDCus;
                Session["Priority"] = 2;
                return RedirectToAction("Index", "Products");
            }
        }
        public ActionResult Login()
        {
            return View();
        }
       
        public ActionResult Logout()
        {
            Session["NameCus"] = null;
            Session["PassCus"] = null;
            Session["IDCus"] = null;
            Session["PassCus"] = null;
            return RedirectToAction("Login", "LoginUser");

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(Customer _user)
        {
            if (ModelState.IsValid)
            {
                var check_NameUser = db.Customers.Where(s => s.NameCus == _user.NameCus ).FirstOrDefault();
                if(check_NameUser == null)
                {
                    db.Configuration.ValidateOnSaveEnabled=false;   
                    db.Customers.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.ErrorRegister = "Tên người dùng đã tồn tại";
                    return View("Register");
                }
            }
            return View(_user);
        }
        public ActionResult NotAuthorized()
        {
            return PartialView();
        }
    }
}