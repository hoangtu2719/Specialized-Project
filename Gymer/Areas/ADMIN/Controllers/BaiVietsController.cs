using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gymer.Models;
using System.IO;

namespace Gymer.Areas.ADMIN.Controllers
{
    public class BaiVietsController : Controller
    {
        private GymEntities db = new GymEntities();

        // GET: ADMIN/BaiViets
        public async Task<ActionResult> Index()
        {
            var baiViets = db.BaiViets.Include(b => b.DanhMuc).Include(b => b.DinhDuong).Include(b => b.KT).Include(b => b.NguoiDung).Include(b => b.PhanLoai).Include(b => b.TinTuc);
            return View(await baiViets.ToListAsync());
        }

        // GET: ADMIN/BaiViets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = await db.BaiViets.FindAsync(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // GET: ADMIN/BaiViets/Create
        public ActionResult Create()
        {
            ViewBag.MaBinhLuan = new SelectList(db.Binhluans, "MaBinhLuan", "NoiDungBinhLuan");
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucs, "MaDanhMuc", "TenDanhMuc");
            ViewBag.MaDinhDuong = new SelectList(db.DinhDuongs, "Ma_DinhDuong", "TieuDe");
            ViewBag.MaKienThuc = new SelectList(db.KTs, "MaKienThuc", "TenKienThuc");
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenNguoiDung");
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "TenPhanLoai");
            ViewBag.MaTinTuc = new SelectList(db.TinTucs, "MaTinTuc", "TieuDe");
            return View();
        }

        // POST: ADMIN/BaiViets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaBaiViet,NoiDung,AnhChuDe,MaPhanLoai,NgayDang,LuotXem,MaNguoiDung,MaBinhLuan,MaDanhMuc,TenBaiViet,MaDinhDuong,MaTinTuc,MaKienThuc,TenChuDe,TieuDe,HuongDan")] BaiViet baiViet, HttpPostedFileBase fileUpload)
        {
            var fileimg = Path.GetFileName(fileUpload.FileName);
            //Lưu file
            var pa = Path.Combine(Server.MapPath("~/Content/Img/"), fileimg);
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }
            else if (System.IO.File.Exists(pa))
            {
                ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
            }
            else
            {
                fileUpload.SaveAs(pa);
            }
            baiViet.AnhChuDe = fileUpload.FileName;
                db.BaiViets.Add(baiViet);
                await db.SaveChangesAsync();

   
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucs, "MaDanhMuc", "TenDanhMuc", baiViet.MaDanhMuc);
            ViewBag.MaDinhDuong = new SelectList(db.DinhDuongs, "Ma_DinhDuong", "TieuDe", baiViet.MaDinhDuong);
            ViewBag.MaKienThuc = new SelectList(db.KTs, "MaKienThuc", "TenKienThuc", baiViet.MaKienThuc);
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenNguoiDung", baiViet.MaNguoiDung);
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "TenPhanLoai", baiViet.MaPhanLoai);
            ViewBag.MaTinTuc = new SelectList(db.TinTucs, "MaTinTuc", "TieuDe", baiViet.MaTinTuc);
            return View(baiViet);
        }

        // GET: ADMIN/BaiViets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = await db.BaiViets.FindAsync(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucs, "MaDanhMuc", "TenDanhMuc", baiViet.MaDanhMuc);
            ViewBag.MaDinhDuong = new SelectList(db.DinhDuongs, "Ma_DinhDuong", "TieuDe", baiViet.MaDinhDuong);
            ViewBag.MaKienThuc = new SelectList(db.KTs, "MaKienThuc", "TenKienThuc", baiViet.MaKienThuc);
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenNguoiDung", baiViet.MaNguoiDung);
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "TenPhanLoai", baiViet.MaPhanLoai);
            ViewBag.MaTinTuc = new SelectList(db.TinTucs, "MaTinTuc", "TieuDe", baiViet.MaTinTuc);
            return View(baiViet);
        }

        // POST: ADMIN/BaiViets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaBaiViet,NoiDung,AnhChuDe,MaPhanLoai,NgayDang,LuotXem,MaNguoiDung,MaBinhLuan,MaDanhMuc,TenBaiViet,MaDinhDuong,MaTinTuc,MaKienThuc,TenChuDe,TieuDe,HuongDan")] BaiViet baiViet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiViet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucs, "MaDanhMuc", "TenDanhMuc", baiViet.MaDanhMuc);
            ViewBag.MaDinhDuong = new SelectList(db.DinhDuongs, "Ma_DinhDuong", "TieuDe", baiViet.MaDinhDuong);
            ViewBag.MaKienThuc = new SelectList(db.KTs, "MaKienThuc", "TenKienThuc", baiViet.MaKienThuc);
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenNguoiDung", baiViet.MaNguoiDung);
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "TenPhanLoai", baiViet.MaPhanLoai);
            ViewBag.MaTinTuc = new SelectList(db.TinTucs, "MaTinTuc", "TieuDe", baiViet.MaTinTuc);
            return View(baiViet);
        }

        // GET: ADMIN/BaiViets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = await db.BaiViets.FindAsync(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // POST: ADMIN/BaiViets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BaiViet baiViet = await db.BaiViets.FindAsync(id);
            db.BaiViets.Remove(baiViet);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
