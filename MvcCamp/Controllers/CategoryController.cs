using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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

        CategoryManager categoryManager=new CategoryManager(new EfCategoryDal());
        
        public ActionResult Index()
        {
            return View();
        }
         
        public ActionResult GetCategory()
        {
            var CategoryValues = categoryManager.GetCategory();
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
            //categoryManager.Add(p);
            CategoryValidatior categoryValidator = new CategoryValidatior();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                categoryManager.CategoryAdd(p);
                return RedirectToAction("GetCategory");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        
    }
}