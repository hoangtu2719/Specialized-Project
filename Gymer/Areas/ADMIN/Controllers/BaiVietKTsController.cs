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
    public class BaiVietKTsController : Controller
    {
        private GymEntities db = new GymEntities();

        // GET: ADMIN/BaiVietKTs
        public ActionResult Index()
        {
            return View(db.BaiVietKTs.ToList());
        }

        // GET: ADMIN/BaiVietKTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiVietKT baiVietKT = db.BaiVietKTs.Find(id);
            if (baiVietKT == null)
            {
                return HttpNotFound();
            }
            return View(baiVietKT);
        }

        // GET: ADMIN/BaiVietKTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/BaiVietKTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBaiVietKT,NoiDung,AnhChuDe,TenChuDe,TieuDe,MaNguoiDung,NgayDang")] BaiVietKT baiVietKT,HttpPostedFileBase fileUpload)
        {
            var fileimg = Path.GetFileName(fileUpload.FileName);
            //Lưu file
            var pa = Path.Combine(Server.MapPath("~/Content/ImgBVKT/"), fileimg);
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
            baiVietKT.AnhChuDe = fileUpload.FileName;
            db.BaiVietKTs.Add(baiVietKT);
            db.SaveChanges();
            return View(baiVietKT);
        }

        // GET: ADMIN/BaiVietKTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiVietKT baiVietKT = db.BaiVietKTs.Find(id);
            if (baiVietKT == null)
            {
                return HttpNotFound();
            }
            return View(baiVietKT);
        }

        // POST: ADMIN/BaiVietKTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBaiVietKT,NoiDung,AnhChuDe,TenChuDe,TieuDe,MaNguoiDung,NgayDang")] BaiVietKT baiVietKT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiVietKT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baiVietKT);
        }

        // GET: ADMIN/BaiVietKTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiVietKT baiVietKT = db.BaiVietKTs.Find(id);
            if (baiVietKT == null)
            {
                return HttpNotFound();
            }
            return View(baiVietKT);
        }

        // POST: ADMIN/BaiVietKTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiVietKT baiVietKT = db.BaiVietKTs.Find(id);
            db.BaiVietKTs.Remove(baiVietKT);
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
