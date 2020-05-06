using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gymer.Models;

namespace Gymer.Controllers
{
    public class ChiTietBaiVietDDController : Controller
    {
        // GET: ChiTietBaiVietDD
        GymEntities db = new GymEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult ChiTietDD( int madinhduong = 0)
        {
            DinhDuong dd = db.DinhDuongs.SingleOrDefault(n => n.Ma_DinhDuong == madinhduong);
            db.DinhDuongs.Find(madinhduong).LuotXem++;
            db.SaveChanges();
            return View (dd);
        }
    }
}