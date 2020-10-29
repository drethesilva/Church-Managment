using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Locker_V2.Controllers
{
    public class staffController : Controller
    {
        // GET: staff
        public ActionResult StaffCentral()
        {
            return View();
        }

        public ActionResult manageSats()
        {


            return PartialView("_manageSats");
        }
    }
}