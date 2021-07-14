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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager MessageManager = new MessageManager(new EfMessageDal());
       
        public ActionResult Inbox()
        {
            var MessageList = MessageManager.GetMessagesInbox();
            return View(MessageList);
        }
        public ActionResult Sendbox()
        {
            var MessageList = MessageManager.GetMessagesInbox();
            return View(MessageList);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {

            return View();
        }
    }
}