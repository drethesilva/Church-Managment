using My_Locker_V2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Locker_V2.Controllers
{
    public class HomeController : Controller
    {
        MasterDB context = new MasterDB();

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

        public ActionResult List()
        {
            // se for necessario passar parametros 
            //SqlParameter[] param = new SqlParameter[]
            //{
            //    new SqlParameter("",0),
            //    new SqlParameter("",0)
            //};

            var data = context.Database.SqlQuery<Users>("select_users_and_info").ToList();
            return View(data);
        }
    }
}