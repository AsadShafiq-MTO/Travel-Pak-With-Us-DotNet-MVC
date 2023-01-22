using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel_Pakistan_With_Us.Controllers
{
    //[Authorize=(Roles="admin")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult MasterPageBooking()
        {
           

            return View();
        }
        public ActionResult Bilochistan()
        {


            return View();
        }
        public ActionResult Faslabad()
        {


            return View();
        }
        public ActionResult Lahore()
        {


            return View();
        }
        public ActionResult karachi()
        {


            return View();
        }
        public ActionResult Swat()
        {


            return View();
        }
        public ActionResult Kohat()
        {


            return View();
        }
        public ActionResult Kamrat()
        {


            return View();
        }
        public ActionResult FairyMeadow()
        {


            return View();
        }
    }
}