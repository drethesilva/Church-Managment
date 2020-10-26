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
            //List<DateTime> Dates;
            //string atualYear = DateTime.Now.ToString("yyyy");
            //Dates = My_Locker_V2.Classes.MyCommonUtilities.GetAllSats(Convert.ToInt32(atualYear));

            var Dates = context.Database.SqlQuery<Sabados>("SELECT Data FROM Sabados WHERE Disponibilidade = '1'").ToList();


            return View(Dates);
        }




    }
}