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
        public IActionResult DoEdit(Category cat)
        {
            var c = db.Categories.SingleOrDefault(ca => ca.Id == cat.Id);
            c.CategoryName = cat.CategoryName;
            db.SaveChanges();
            return RedirectToAction("ViewAll");
        }
        public IActionResult Edit(int id)
        {
            var c = db.Categories.SingleOrDefault(ca => ca.Id == id);
            return View(c);
        }

        public IActionResult Details(int id)
        {
            var c = db.Categories.SingleOrDefault(ca => ca.Id == id);
            return View(c);
        }
        public IActionResult Delete(int id)
        {
            var c = db.Categories.SingleOrDefault(ca => ca.Id == id);
            db.Categories.Remove(c);
            db.SaveChanges();
            return RedirectToAction("ViewAll");
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
