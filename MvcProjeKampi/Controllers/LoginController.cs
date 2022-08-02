using BusinessLayer.Hashing;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using DataAccessLayer.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminLoginManager alm = new AdminLoginManager(new EfAdminLoginDal());
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterLoginDal());
        Hashing h = new Hashing();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var encryuser = h.EncrytString(p.AdminUserName);
            var encrypassword = h.EncrytString(p.AdminPassword);
            p.AdminPasswordEncrypt = encrypassword; 
            p.AdminUserNameEncrypt = encryuser;         
            var adminuserinfo = alm.GetAdminIfExist(p);               
            //cm.LoginUpdate(adminuserinfo);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserNameEncrypt, false);
                Session["AdminUserNameEncrypt"] =adminuserinfo.AdminUserNameEncrypt;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
           
        }
        [HttpGet]
        public ActionResult  WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //var encryuser = h.EncrytString(p.WriterMail);
            //var encrypassword = h.EncrytString(p.WriterPassword);
            //p.AdminPasswordEncrypt = encrypassword;
            //p.AdminUserNameEncrypt = encryuser;
            var writeruserinfo = wlm.GetWriterIfExist(p);
            //cm.LoginUpdate(adminuserinfo);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");
        }
    }
}