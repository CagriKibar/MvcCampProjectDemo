using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class HeadingController : Controller
    {

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var HeadingValues = headingManager.GetHeading();

            return View(HeadingValues);
        }

        [HttpGet]
        //drop down kullanabilmek için select list item sistemi kurulmalıdır.
        //çünkü id çekmemiz için gereklidir.
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategory()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            List<SelectListItem> valueWriter = (from x in writerManager.GetWriters()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterLastName,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();
            ViewBag.vlw = valueWriter;
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategory()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var HeadingValue = headingManager.GetById(id);
            return View(HeadingValue);
        }
        
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            headingManager.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = headingManager.GetById(id);
            //HeadingValue.He = false;
            headingManager.HeadingDelete(HeadingValue);
            return RedirectToAction("Index");
        }
    }
}