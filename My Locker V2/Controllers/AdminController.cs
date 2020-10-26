using My_Locker_V2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Locker_V2.Controllers
{
    public class AdminController : Controller
    {

        MasterDB context = new MasterDB();

        // GET: Admin
        public ActionResult BackOffice()
        {
            return View();
        }

        public ActionResult addSat()
        {
            List<DateTime> Dates;
            string atualYear = DateTime.Now.ToString("yyyy");
            Dates = My_Locker_V2.Classes.MyCommonUtilities.GetAllSats(Convert.ToInt32(atualYear));

            foreach(var i in Dates)
            {
                var ID = context.Database.SqlQuery<Sabados>("SELECT ID FROM Sabados WHERE Data = '"+ i.ToString("yyyy/MM/dd") + "'").ToList();

                if(ID.Count() == 0)
                {
                    try
                    {
                        context.Database.ExecuteSqlCommand("INSERT INTO dbo.Sabados(Data,Disponibilidade) VALUES ('" + i.ToString("yyyy/MM/dd") + "','0')");
                    }
                    catch (Exception er) { }
                }
                else
                {

                }

           
            }

            return View();
        }
    }
}