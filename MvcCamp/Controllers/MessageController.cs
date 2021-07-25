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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager MessageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidation = new MessageValidator();
        [Authorize]
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
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = MessageManager.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = MessageManager.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = messageValidation.Validate(message);
            if (results.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                MessageManager.MessageAdd(message);
                return RedirectToAction("SendBox");
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