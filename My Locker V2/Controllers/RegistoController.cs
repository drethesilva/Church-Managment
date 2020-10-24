using My_Locker_V2.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
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
                        string passEncrypt = My_Locker_V2.Classes.MyCommonUtilities.Encrypt(formData.Password);

                        int membro;

                        if (formData.Membro == true) { membro = 1; } else { membro = 0; }

                        SqlParameter[] param = new SqlParameter[]{new SqlParameter("@Nome", formData.Nome),
                            new SqlParameter("@Apelido", formData.Apelido),
                            new SqlParameter("@Email", formData.Email),
                            new SqlParameter("@Password", passEncrypt),
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
    