using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrossZero.Lesson1;

namespace WebApplicationStatistic.Controllers
{
    public class HomeController : Controller
    {
        string filePath = @"c:\stat\stats.json";


        public ActionResult Index()
        {
            ViewBag.sg = Serializer.GetData(filePath);

            return View();
        }

      
    }
}