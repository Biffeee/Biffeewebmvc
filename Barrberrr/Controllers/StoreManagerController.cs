using Barrberrr.EntityContext;
using Barrberrr.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Barrberrr.Controllers
{

    [Authorize(Roles = "Admin")]
    public class StoreManagerController : Controller
    {
        private HairStoreEntities db = new HairStoreEntities();

        // GET: /StoreManager/
        public ActionResult Index(string searchString)
        {
            var products = db.Products.Include(a => a.Brand).Include(a => a.Genre);
           
            //var st = from m in db.Products
            //         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                 products = products.Where(s => s.Title.Contains(searchString));
            }
            return View(products.ToList());
        }

        // GET: /StoreManager/Details/5
        public ActionResult Details(int? id)
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

        // GET: /StoreManager/Create
        public ActionResult Create()
        {
            
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,GenreId,BrandId,Title,Price,ProductArtUrl")] Product product)
        {
            
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", product.BrandId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", product.GenreId);
            return View(product);
        }

        // GET: /StoreManager/Edit/5
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
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", product.BrandId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", product.GenreId);
            return View(product);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,GenreId,BrandId,Title,Price,ProductArtUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", product.BrandId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", product.GenreId);
            return View(product);
        }

        // GET: /StoreManager/Delete/5
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

        // POST: /StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();          
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}