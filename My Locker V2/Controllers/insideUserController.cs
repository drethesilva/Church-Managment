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
        // GET: insideUser
        public ActionResult Index()
        {
            List<DateTime> Dates;
            string atualYear = DateTime.Now.ToString("yyyy");
            Dates = My_Locker_V2.Classes.MyCommonUtilities.GetAllSats(Convert.ToInt32(atualYear));

            return View(Dates);
        }




    }
}