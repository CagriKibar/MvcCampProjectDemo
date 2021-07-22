using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager imageFileManager = new ImageFileManager( new EfImageFileDal());
        public ActionResult Index()
        {
            var files = imageFileManager.GetImageFiles();
            return View(files);
        }
    }
}