using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messagelist = mm.GetListInbox(p);  
            return View(messagelist);
        }
        public ActionResult Sendbox(string p)
        {
            var messagelist = mm.GetListSendInbox(p);
            return View(messagelist);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {         
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
                
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
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
        [HttpGet]
        public ActionResult PartialMessage(string mail)
        {                  
            ViewBag.mail = mail;
            
            return PartialView();
        }
        [HttpPost]
        public ActionResult PartialMessage(Message p)
        { 
            string mail = (string)Session["WriterMail"];
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = mail;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox", "WriterPanelMessage");
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
        public ActionResult GetInboxDetails(int id)
        {
            var values = mm.GetByID(id);
            values.MessageReadStatus = true;
            mm.MessageUpdate(values);
            return View(values);
        }
        
        public ActionResult GetSendboxDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
    }
}