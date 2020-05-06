using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gymer.Models;

namespace Gymer.Controllers
{
    public class ChiTietBaiTapController : Controller
    {
        // GET: ChiTietBaiTap
        GymEntities db = new GymEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult ChiTiet(int machitiet = 0)
        {
            BaiViet baiviet = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == machitiet);
            return View(baiviet);
        }
    }
}