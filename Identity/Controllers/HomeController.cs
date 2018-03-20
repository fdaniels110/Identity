using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.ClaimsIdentity = Thread.CurrentPrincipal.Identity;
            ViewBag.Message = "Your application description page.";
            var right = Rights.PossessProperty;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}