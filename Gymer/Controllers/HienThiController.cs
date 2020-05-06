using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Gymer.Models;

namespace Gymer.Controllers
{
    public class HienThiController : Controller
    {
        GymEntities db = new GymEntities();
        // GET: HienThi
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DanhMuc()
        {
            return PartialView(db.DanhMucs.ToList());
        }
        public PartialViewResult Tintuc()
        {
            return PartialView(db.TinTucs.ToList());
        }
        public PartialViewResult BaiVietMoiNhat()
        {
            return PartialView(db.BaiViets.OrderByDescending(n => n.NgayDang).Take(6).ToList());
        }
        public ActionResult BaiVietDD(int ? page)
        {
            int pagesize = 6;
            int pagenumber = (page ?? 1);
            return View(db.DinhDuongs.OrderByDescending(n=>n.TenThucPham).ToPagedList(pagenumber,pagesize)) ; 
        }
        public PartialViewResult BaiVietDDMoiNhat()
        {
            return PartialView(db.DinhDuongs.OrderByDescending(n => n.TenThucPham).Take(6).ToList());
        }

    }
}