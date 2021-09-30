using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMVC.Controllers
{
    public class ProductController : Controller
    {
        PhoneShopContext db = new PhoneShopContext();
        public IActionResult Index()
        {
            //db.Categories.ToList();
            return View(db.Products.Take(10).Include(p=>p.CategoryNavigation).ToList());
        }
        public IActionResult Search(string txtSearch)
        {
            var result = db.Products.Where(p => p.ProductName.Contains(txtSearch));
            return View("Index", result);
        }
        public IActionResult Create()
        {
            ViewBag.category = db.Categories;
            return View();
        }
        
        public async Task<IActionResult> DoCreate(IFormFile postedFile, Product product)
        {            
            using (var dataStream = new MemoryStream())
            {
                await postedFile.CopyToAsync(dataStream);
                product.Picture = dataStream.ToArray();
            }
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
