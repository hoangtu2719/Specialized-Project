using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gymer.Models;

namespace Gymer.Areas.ADMIN.Controllers
{
    public class DinhDuongsController : Controller
    {
        private GymEntities db = new GymEntities();

        // GET: ADMIN/DinhDuongs
        public ActionResult Index()
        {
            return View(db.DinhDuongs.ToList());
        }

        // GET: ADMIN/DinhDuongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DinhDuong dinhDuong = db.DinhDuongs.Find(id);
            if (dinhDuong == null)
            {
                return HttpNotFound();
            }
            return View(dinhDuong);
        }

        // GET: ADMIN/DinhDuongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/DinhDuongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_DinhDuong,TieuDe,TenThucPham,NoiDung,Quyen,AnhThucPham")] DinhDuong dinhDuong, HttpPostedFileBase fileUpload)
        {
            var fileimg = Path.GetFileName(fileUpload.FileName);
            //Lưu file
            var pa = Path.Combine(Server.MapPath("~/Content/ImgDD/"), fileimg);
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
            dinhDuong.AnhThucPham = fileUpload.FileName;
                db.DinhDuongs.Add(dinhDuong);
                db.SaveChanges();

            return View(dinhDuong);
        }

        // GET: ADMIN/DinhDuongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DinhDuong dinhDuong = db.DinhDuongs.Find(id);
            if (dinhDuong == null)
            {
                return HttpNotFound();
            }
            return View(dinhDuong);
        }

        // POST: ADMIN/DinhDuongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_DinhDuong,TieuDe,TenThucPham,NoiDung,Quyen,AnhThucPham")] DinhDuong dinhDuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dinhDuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dinhDuong);
        }

        // GET: ADMIN/DinhDuongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DinhDuong dinhDuong = db.DinhDuongs.Find(id);
            if (dinhDuong == null)
            {
                return HttpNotFound();
            }
            return View(dinhDuong);
        }

        // POST: ADMIN/DinhDuongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DinhDuong dinhDuong = db.DinhDuongs.Find(id);
            db.DinhDuongs.Remove(dinhDuong);
            db.SaveChanges();
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
