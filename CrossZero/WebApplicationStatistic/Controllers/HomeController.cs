using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationStatistic.Models;

namespace WebApplicationStatistic.Controllers
{
    public class HomeController : Controller
    {
        static StatisticsDBEntities db = new StatisticsDBEntities();

        public ActionResult Index()
        {
            ViewBag.sg = db.CrossZeroStat.ToList();

            return View();
        }

      
    }
}