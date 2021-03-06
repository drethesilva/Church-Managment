﻿using My_Locker_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Locker_V2.Controllers
{
    public class staffController : Controller
    {
        MasterDB context = new MasterDB();

        // GET: staff
        public ActionResult StaffCentral()
        {
            return View();
        }

        public ActionResult manageSats()
        {
            var nameIgrejas = context.Database.SqlQuery<Sabados>("SELECT * FROM Sabados WHERE Data >= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'").ToList();

            return PartialView("_manageSats",nameIgrejas);
        }

        public ActionResult gotoSat(int Id)
        {

            return PartialView("_viewRegistosBySat");
        }
    }
}