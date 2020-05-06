using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gymer.Controllers
{
    public class DangXuatController : Controller
    {
        // GET: DangXuat
        public ActionResult DangXuat()
        {
            Session["NguoiDung"] = null;
            Response.Redirect("/HienThi/Index");
            return View();
        }
    }
}