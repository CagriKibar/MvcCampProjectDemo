using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager categoryManager = new CategoryManager();
        public ActionResult Index()
        {
            return View();
        }
         
        public ActionResult GetCategory()
        {
            var CategoryValues = categoryManager.GetAll();
            return View(CategoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

     

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            categoryManager.Add(p);
            return RedirectToAction("GetCategory");
        }

        
    }
}