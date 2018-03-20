using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Secret()
        {
            if(((System.Security.Claims.ClaimsIdentity)User.Identity).HasClaim("secret", "access"))
            {
                return Json(new { msg = "Full access" }, JsonRequestBehavior.AllowGet);
            }
            else if (((System.Security.Claims.ClaimsIdentity)User.Identity).HasClaim("secret", "partial"))
            {
                return Json(new { msg = "Partial access" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}