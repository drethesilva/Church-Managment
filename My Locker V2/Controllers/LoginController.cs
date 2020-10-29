using My_Locker_V2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace My_Locker_V2.Controllers
{
    public class LoginController : Controller
    {
        MasterDB context = new MasterDB();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submited(Models.Utilizadores formData)
        {

            if (formData.Email.Contains("@"))
            {
                try
                {
                   
                    try
                    {
                        // User
                        SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Email", formData.Email) };
                        var data = context.Database.SqlQuery<Utilizadores>("showPasswordFromEmail @Email", param).ToList();

                        if(data.Count() != 0)
                        {
                            foreach(var i in data)
                            {
                                var ya = My_Locker_V2.Classes.MyCommonUtilities.Encrypt(formData.Password);
                                if (i.Password == ya )
                                {
                                    return View("~/Views/insideUser/Index.cshtml",formData);
                                }
                                else
                                {
                                    ModelState.AddModelError("Password", "Dados Incorretos");
                                    return View("Index", formData);
                                }
                            }
                           
                        }

                        // Staff 
                        var dataStaff = context.Database.SqlQuery<Staff>("SELECT * FROM Staff WHERE Email = '" + formData.Email.ToLower() + "'").ToList();

                        if(dataStaff.Count() != 0)
                        {
                            foreach(var i in data)
                            {
                                var pass = My_Locker_V2.Classes.MyCommonUtilities.Encrypt(formData.Password);

                                if(i.Password == pass)
                                {
                                    return View("~/Views/staff/StaffCentral.cshtml", formData);
                                }
                                else
                                {
                                    ModelState.AddModelError("Password", "Dados Incorretos");
                                    return View("Index", formData);
                                }

                            }
                        }





                    }
                    catch (Exception er)
                    {
                        ModelState.AddModelError("Email", "Email Introduzido não está registado");
                        return View("Index", formData);
                    }

                }
                catch (Exception er) { }


            }
            else
            {
                if(formData.Email.ToLower() == "admin" && formData.Password == "admin" )
                {
                    return View("~/Views/Admin/BackOffice.cshtml", formData);
                }

                ModelState.AddModelError("Email", "Email Introduzido Incorreto");
                return View("Index", formData);
            }

                return View();

        }
    }
}