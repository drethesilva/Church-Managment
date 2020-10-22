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
    public class RegistoController : Controller
    {
        // GET: Registo

        MasterDB context = new MasterDB();
        bool hasEmail;

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
            try
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
                           


                    if(hasEmail == false)
                    {
                        // Encriptar password
                        Encrypt(formData.Password);

                        int membro;

                        if (formData.Membro == true) { membro = 1; } else { membro = 0; }

                        SqlParameter[] param = new SqlParameter[]{new SqlParameter("@Nome", formData.Nome),
                            new SqlParameter("@Apelido", formData.Apelido),
                            new SqlParameter("@Email", formData.Email),
                            new SqlParameter("@Password", formData.Password),
                            new SqlParameter("@Membro", membro), };
{
                            
};
                        var data = context.Database.SqlQuery<Users>("Add_Utilizador @Nome,@Apelido,@Email,@Password,@Membro",param);
                        try
                        {
                            context.Database.ExecuteSqlCommand("Add_Utilizador @Nome,@Apelido,@Email,@Password,@Membro", param);
                        }
                        catch (Exception er) { }

                    }
                    else
                    {
                        ModelState.AddModelError("Email", "Email já registado, Deseja fazer login?");
                        return View("Index", formData);
                    }

                }
                else
                {
                    ModelState.AddModelError("Email", "Email Inexistente");
                    return View("Index",formData);
                }

            }
            catch (Exception er)
            {

            }

            return View();


        }


        

        


    }
}
    