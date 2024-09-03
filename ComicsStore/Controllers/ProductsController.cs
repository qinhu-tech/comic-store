using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComicsStore.Models;
using PagedList;
using PagedList.Mvc;

namespace ComicsStore.Controllers
{
    public class ProductsController : Controller
    {
        private ComicsStoreEntities1 db = new ComicsStoreEntities1();

        // GET: Products
      
        
        public ActionResult Index(int category)
        {
            //if(category == 0)
            //{
            //    var productlist = db.Products.Include(p => p.NamePro);
            //    return View(productlist);
            //}
            //else
            //{
            //    var productlist = db.Products.OrderByDescending(p => p.NamePro).Where(p=> p.Category == category);
            //    return View(productlist);
            //}            
            return View(db.Products.Where(x => x.Category == category|| category == null).ToList());
        }
        [HttpGet]
        public ActionResult Index(string searching, int? category,int? page)
        {
            int pageSize = 4;
            int pageNum = (page ?? 1);
            if(searching != null)
                return View(db.Products.Where(x => x.NamePro.Contains(searching) || searching == null).ToList().ToPagedList(pageNum, pageSize));
           
            
            if(category != null)
                return View(db.Products.Where(x => x.Category == category || category == null).ToList().ToPagedList(pageNum,pageSize));

            return View(db.Products.ToList().ToPagedList(pageNum, pageSize));
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.returnUrl = Request.UrlReferrer.ToString();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
            
        }
        //[MyAuthorize(ResourceKey = 1)]
        public ActionResult Create()
        {
            List<Category> list = db.Categories.ToList();
            ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate", "");
            Product pro = new Product(); 
            return View(pro);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Product product)
        {
            List<Category> list = db.Categories.ToList();
            try
            {
                if (product.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(product.UploadImage.FileName);
                    string extent = Path.GetExtension(product.UploadImage.FileName);
                    filename = filename + extent;
                    product.ImagePro = "~/Content/images/" + filename;
                    product.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                }
                ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate",1);
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Product", "ADHome", new { area = "Admin" });
            }
            catch
            {
                return View();
            }                     
            
        }

        // GET: Products/Edit/5
        //[MyAuthorize(ResourceKey = 1)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = new SelectList(db.Categories, "IDCate", "NameCate", product.Category);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,NamePro,DecriptionPro,Category,Price,ImagePro,Quantity")] Product product)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Product", "ADHome", new {area ="Admin"});
            }
            ViewBag.Category = new SelectList(db.Categories, "IDCate", "NameCate", product.Category);
            return View(product);
        }

        // GET: Products/Delete/5
        //[MyAuthorize(ResourceKey = 1)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Product", "ADHome", new { area = "Admin" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult SelectCate()
        {
            Category se_cate = new Category();
            se_cate.ListCate = db.Categories.ToList<Category>();
            return PartialView(se_cate);
        }
        public ActionResult ProductsLayout()
        {
            var products = db.Products.Include(p => p.Category1);
            return PartialView(products);
        }
        public ActionResult ViewPro()
        {
            var products = db.Products.Include(p => p.Category1);
            return PartialView(products.ToList());
        }
        public ActionResult HotPro()
        {
            var products = db.Products.Include(p => p.Category1);
            return PartialView(products.ToList());
        }
        public ActionResult SearchOption(double min = double.MinValue, double max = double.MaxValue)
        {
            var list = db.Products.Where(p => (double)p.Price >= min && (double)p.Price <= max).ToList();
            return View(list);
        }
        public ActionResult CatePartial()
        {
            var cateList = db.Categories.ToList();
            return PartialView(cateList);
        }
    }
}
