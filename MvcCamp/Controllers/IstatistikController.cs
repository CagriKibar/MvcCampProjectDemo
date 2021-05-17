using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var category = context.Categories.Count();
            ViewBag.task1 = category;
            var heading = context.Headings.Count(p => p.Category.CategoryName == "Yazılım");
            ViewBag.task2 = heading;

            var writer = context.Writers.Count(p => p.WriterLastName.Contains("a"));
            ViewBag.task3 = writer;

            var headingMax = context.Headings.Max(p => p.Category.CategoryName);
            ViewBag.task4 = headingMax;

            var categoryTrueOrFalse = context.Categories.Count(p => p.CategoryStatus == true) - context.Categories.Count(p => p.CategoryStatus == false);
            ViewBag.task5 = categoryTrueOrFalse;
            return View();
        }
    }
}