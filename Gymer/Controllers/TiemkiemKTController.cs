using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gymer.Models;

namespace Gymer.Controllers
{
    public class TiemkiemKTController : Controller
    {
        GymEntities db = new GymEntities();
        // GET: TiemkiemKT
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult TimKiemKT(string Key)
        {
            if (Key != null)
            {
                Session["key"] = Key;
            }
            string key = Session["key"].ToString();
            List<BaiVietKT> bt = db.BaiVietKTs.Where(t => t.TenChuDe.Contains(key)).ToList();
            ViewBag.TB = "Có " + bt.Count + " kết quả";
            return View(bt);
        }
    }
}