using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampim.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        LoginManager login = new LoginManager(new EfLoginDal());
        WriterLoginManager writerlogin = new WriterLoginManager(new EfWriterLoginDal());
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var usernameinfo = login.GetLogin(p.AdminUserName, p.AdminPassword);

            if (usernameinfo != null)
            {
                FormsAuthentication.SetAuthCookie(usernameinfo.AdminUserName, false);
                Session["AdminUserName"] = usernameinfo.AdminPassword;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ModelState.AddModelError("", "Hatalı Kullanıcı & Şifre Girişi Yaptınız");
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {

            var writerlogininfo = writerlogin.WriterLogin(p.WriterMail, p.WriterPassword);

            if (writerlogininfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerlogininfo.WriterMail, false);
                Session["WriterMail"] = writerlogininfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");

            }
            else
            {
                ModelState.AddModelError("", "Hatalı Kullanıcı & Şifre Girişi Yaptınız");
                return View();
            }
        }
    }
}