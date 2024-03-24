using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampim.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        LoginManager adminmanager = new LoginManager(new EfLoginDal());
        public ActionResult Index(string id = null)
        {
            var adminvalues = adminmanager.GetAdminList();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adminmanager.AdminAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var values = adminmanager.GetByID(id);
            values.AdminStatus = false;
            adminmanager.AdminDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> values = (from x in adminmanager.GetAdminList()
                                           select new SelectListItem
                                           {
                                               Text = x.AdminRole,
                                               Value = x.AdminID.ToString()

                                           }).Distinct().ToList();
            ViewBag.admin = values;
            var adminvalue = adminmanager.GetByID(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adminmanager.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}