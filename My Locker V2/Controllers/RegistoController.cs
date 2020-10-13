using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Locker_V2.Controllers
{
    public class RegistoController : Controller
    {
        // GET: Registo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submited(string Nome , string Apelido , string Email , string Password , bool Membro)
        {
          

            return View();
        }
    }
}