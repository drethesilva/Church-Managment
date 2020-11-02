using My_Locker_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace My_Locker_V2.Controllers
{
    public class insideUserController : Controller
    {
        MasterDB context = new MasterDB();

        // GET: insideUser
        public ActionResult Index()
        {

            var Dates = context.Database.SqlQuery<Sabados>("SELECT Data FROM Sabados WHERE Disponibilidade = '1' AND Data >= '"+DateTime.Now.ToString("yyyy-MM-dd")+"' ").ToList();


            return View(Dates);
        }




    }
}