using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampim.Controllers
{
    public class GalleryController : Controller
    {
        ImageManager repo = new ImageManager(new EfImageDal());
        
        // GET: Gallery
        public ActionResult Index()
        {
            var degerler = repo.GetImageFileList();
            return View(degerler);
        }
    }
}