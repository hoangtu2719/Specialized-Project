using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gymer.Models;

namespace Gymer.Controllers
{
    public class TimKiemDDController : Controller
    {
        GymEntities db = new GymEntities();
        // GET: TimKiemDD
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult TimKiemDD(string Key)
        {
            if (Key != null)
            {
                Session["key"] = Key;
            }
            string key = Session["key"].ToString();
            List<DinhDuong> bt = db.DinhDuongs.Where(t => t.TenThucPham.Contains(key)).ToList();
            ViewBag.TB = "Có " + bt.Count + " kết quả";
            return View(bt);
        }
    }
}