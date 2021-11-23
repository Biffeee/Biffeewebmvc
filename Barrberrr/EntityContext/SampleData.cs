using Barrberrr.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Barrberrr.EntityContext
{
    public class SampleData : System.Data.Entity.DropCreateDatabaseIfModelChanges<HairStoreEntities>
    {
        protected override void Seed(HairStoreEntities context)
        {
            var genres = new List<Genre>
            {
                new Genre { Name = "Tạo Kiểu Tóc" },
                new Genre { Name = "Chăm Sóc Tóc" },
                new Genre { Name = "Chăm Sóc Da" },
                new Genre { Name = "Chăm Sóc Cơ Thể" },
                new Genre { Name = "Phụ Kiện" },
                new Genre { Name = "Thực Phẩm Chức Năng" },
            };
            genres.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();

            var brands = new List<Brand>
            {
                new Brand { Name = "Paul Mitchell" },
                new Brand { Name = "Reuzel" },
                new Brand { Name = "By Valian" },
                new Brand { Name = "TiGi" },
                new Brand { Name = "Glanzen" },
                new Brand { Name = "Kevin Murphy" },
                new Brand { Name = "British M" },
                new Brand { Name = "Volcanic" },
                new Brand { Name = "WOOSINCOS" },
                new Brand { Name = "Lady" },
                new Brand { Name = "FARCOM" },
                new Brand { Name = "KMS" },
                new Brand { Name = "ATS" },
                new Brand { Name = "Furin" },
                new Brand { Name = "Davines" },
                new Brand { Name = "ORZEN " },
                new Brand { Name = "Seri" },
                new Brand { Name = "KAYAN" },
                new Brand { Name = "ELFA" },
                //new Brand { Name = "ATS " },
                //new Brand { Name = "ATS " },
                //new Brand { Name = "ATS " },
                //new Brand { Name = "ATS " },
                //new Brand { Name = "ATS " },
                //new Brand { Name = "ATS " },

            };
            brands.ForEach(s => context.Brands.Add(s));
            context.SaveChanges();

            
        }
    }
}