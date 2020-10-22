using My_Locker_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Locker_V2.Controllers
{
    public class LoginController : Controller
    {
        MasterDB context = new MasterDB();
        bool hasEmail;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public static string Encrypt(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            Byte[] originalBytes = encoder.GetBytes(password);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            password = BitConverter.ToString(encodedBytes).Replace("-", "");
            var result = password.ToLower();

            return result;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submited(Models.Utilizadores formData)
        {

            if (formData.Email.Contains("@"))
            {
                try
                {
                    var data = context.Database.SqlQuery<Utilizadores>("showUSers").ToList();

                    foreach (var i in data)
                    {
                        var serverEmail = i.Email.ToLower();
                        var userEmail = formData.Email.ToLower();

                        if (serverEmail == (userEmail))
                        {
                            hasEmail = true;
                        }
                        else { hasEmail = false; }
                    }
                }
                catch (Exception er) { }

                if (hasEmail == true)
                {
                    try
                    {
                        var passwordFromEmail = context.Database.SqlQuery<Utilizadores>("showPasswordFromEmail").ToString();

                        if(passwordFromEmail == Encrypt(formData.Password))
                        {

                        }
                        else
                        {
                            ModelState.AddModelError("Password", "Dados Incorretos");
                            return View("Index", formData);
                        }

                    }
                    catch (Exception er)
                    {
                        
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Email Introduzido não está registado");
                    return View("Index", formData);
                }

            }
            else
            {
                ModelState.AddModelError("Email", "Email Introduzido Incorreto");
                return View("Index", formData);
            }

                return View();

        }
    }
}