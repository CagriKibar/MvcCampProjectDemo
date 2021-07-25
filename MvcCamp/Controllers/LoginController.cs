using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCamp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
         [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context context = new Context();
            var adminUser = context.Admins.FirstOrDefault(p=>p.AdminUserName==admin.AdminUserName
            && p.AdminPassword==admin.AdminPassword );
            if (adminUser!=null)
            {
                //işlemler
                FormsAuthentication.SetAuthCookie(adminUser.AdminUserName,false);
                Session["AdminUserName"] = adminUser.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}