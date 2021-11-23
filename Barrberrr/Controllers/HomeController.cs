using Barrberrr.EntityContext;
using Barrberrr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barrberrr.Controllers
{
    public class HomeController : Controller
    {
        HairStoreEntities storeDB = new HairStoreEntities();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            // Get most popular albums
            var products = GetTopSellingAlbums(5);
            return View(products);
        }
        public List<Product> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return storeDB.Products
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
    }
}