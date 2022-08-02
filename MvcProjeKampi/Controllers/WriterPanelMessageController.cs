using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        Context c = new Context();
        // GET: WriterPanelMessage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendInbox(p);
            return View(messagelist);
        }
        public PartialViewResult ContactPartial()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListInbox(p);
            ViewBag.unreadmessage = messagelist.Where(x => x.MessageReadStatus == false).Count();
            return PartialView(messagelist);
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
        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string mail = (string)Session["WriterMail"];
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)

            {
                
                p.SenderMail = mail;
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
    }
}