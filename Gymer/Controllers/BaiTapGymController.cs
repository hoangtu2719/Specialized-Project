using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gymer.Models;
using PagedList;
using PagedList.Mvc;

namespace Gymer.Controllers
{
    public class BaiTapGymController : Controller
    {
        // GET: BaiTapGym
        GymEntities db = new GymEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BaiTap( int? id, int? page)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
            }
            int num = 6;
            int pagenum = (page ?? 1);
            List<BaiViet> bv = db.BaiViets.Where(n => n.MaDanhMuc == id).ToList();
            return View(bv.OrderBy(n=>n.TenChuDe).ToPagedList(pagenum,num));
        }
       
    }
}