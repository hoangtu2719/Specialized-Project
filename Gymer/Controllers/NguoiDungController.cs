using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Gymer.Models;

namespace Gymer.Controllers
{
    public class NguoiDungController : Controller
    {
        GymEntities db = new GymEntities();
        // GET: NguoiDung
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string staikhoan = f["txtusername"].ToString();
            string smatkhau = f["txtpassword"].ToString();
            NguoiDung nd = db.NguoiDungs.SingleOrDefault(n => n.TenNguoiDung == staikhoan && n.MatKhau == smatkhau);
            ADMIN ad = db.ADMINs.SingleOrDefault(n => n.TenDNAdmin == staikhoan && n.MatKhauAdmin == smatkhau);
            if(nd != null)
            {
                Session["NguoiDung"] = nd;
                return Redirect(Request.UrlReferrer.ToString());
            }
            if( ad != null)
            {
                Session["ADMIN"] = ad;
                return Redirect("/ADMIN/TrangChu/Index");
            }
            else
            {
                ViewBag.ThongBao = "Đăng nhập thất bại";
            }
            return View();
        }
        public ActionResult DangNhapChinh()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DangKy([Bind(Include = "MaNguoiDung,TenNguoiDung,MatKhau,Gmail,NhapLaiMatKhau,NgaySinh,GioiTinh,DienThoaiND")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(nguoiDung);
                await db.SaveChangesAsync();
                return RedirectToAction("Index","HienThi");
            }

            return View(nguoiDung);
        }

        public PartialViewResult CongCu()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult kttk(string TenNguoiDung)
        {
            bool tt = db.NguoiDungs.FirstOrDefault(n=>n.TenNguoiDung == TenNguoiDung) != null;
            return Json(!tt, JsonRequestBehavior.AllowGet);
        }
    }
}