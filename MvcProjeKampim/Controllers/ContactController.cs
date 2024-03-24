using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampim.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalue = cm.GetContactList();
            return View(contactvalue);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult GetContactPartial()
        {
            DataCount();
            return PartialView();
        }
        public void DataCount()
        {
            //MessageManager mm = new MessageManager(new EfMessageDal());

            //ViewBag.Inbox = mm.GetMessageListInbox().Count();
            //ViewBag.Sendbox = mm.GetMessageListSendbox().Count();
            //ViewBag.Contact = cm.GetContactList().Count();
        }


    }
}