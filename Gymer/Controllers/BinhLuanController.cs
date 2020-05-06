using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gymer.Models;

namespace Gymer.Controllers
{
    public class BinhLuanController : Controller
    {

        // GET: BinhLuan
        GymEntities db = new GymEntities();
        public ActionResult Index(int? id)
        {
            Session["BaiViet"] = id;
            var binhluan = db.Binhluans.Where(t => t.MaBaiViet == id).Include(t => t.TraLois).OrderByDescending(t => t.NgayBinhLuan).ToList();
            return View(binhluan);
        }
      
        // Create new Comment
        [HttpPost]
        public ActionResult DangBinhLuan(Binhluan bl)
        {
            NguoiDung info = (NguoiDung)Session["NguoiDung"];
            if(info == null)
            {
                return Redirect(Request.UrlReferrer.ToString());
            }
            bl.MaNguoiDung = info.MaNguoiDung;
            bl.NgayBinhLuan = DateTime.Now;
            bl.MaBaiViet = Int32.Parse(Session["MaBaiViet"].ToString());
            db.Binhluans.Add(bl);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        // Create new Reply
        [HttpPost]
        public ActionResult PostReply(TraLoi tl)
        {
            TraLoi info = (TraLoi)Session["NguoiDung"];
            tl.NguoiDung = info.NguoiDung;
            tl.NgayDang = DateTime.Now;
            db.TraLois.Add(tl);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}