using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMVC.Controllers
{
    public class CategoryController : Controller
    {
        PhoneShopContext db = new PhoneShopContext();
        public IActionResult DoCreate(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ViewAll()
        {
            return View(db.Categories.ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
