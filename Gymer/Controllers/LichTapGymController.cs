using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gymer.Models;

namespace Gymer.Controllers
{
    public class LichTapGymController : Controller
    {
        // GET: LichTapGym
        GymEntities db = new GymEntities();
        public ActionResult Index()
        {
            return View();
        }
    }
}