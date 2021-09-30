using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMVC.Controllers
{
    public class ProductController : Controller
    {
        PhoneShopContext db = new PhoneShopContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.category = db.Categories;
            return View();
        }
        public async Task<IActionResult> DoCreateAsync(IFormFile postedFile, Product product)
        {            
            using (var dataStream = new MemoryStream())
            {
                await postedFile.CopyToAsync(dataStream);
                product.Picture = dataStream.ToArray();
            }
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

    }
}
