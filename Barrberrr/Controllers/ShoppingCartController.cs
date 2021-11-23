using Barrberrr.EntityContext;
using Barrberrr.Models;
using Barrberrr.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barrberrr.Controllers
{
    public class ShoppingCartController : Controller
    {
        HairStoreEntities storeDB = new HairStoreEntities();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {         
            var addedProduct = storeDB.Products
            .Single(product => product.ProductId == id);            
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedProduct);          
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {           
            var cart = ShoppingCart.GetCart(this.HttpContext);          
            string ProductName = storeDB.Carts.FirstOrDefault(item => item.RecordId == id).Product.Title;           
            int itemCount = cart.RemoveFromCart(id);          
            var results = new ShoppingCartRemoveViewModel()
            {
                Message = Server.HtmlEncode(ProductName) +
                "has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
       
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView(cart);
        }
    }
}