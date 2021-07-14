using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCamp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        public ActionResult Index()
        {
            var ContactValues = contactManager.GetContacts();
            return View(ContactValues);
        }
        
        public ActionResult GetContactDetails(int id)
        {
            var ContactValues = contactManager.GetById(id);
            return View(ContactValues);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}