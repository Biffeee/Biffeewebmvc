using Barrberrr.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Barrberrr.EntityContext
{
    public class HairStoreEntities:DbContext
    {
       
        public DbSet<Product> Products { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        
    }
}