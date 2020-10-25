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
                        SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Email", formData.Email.ToLower()) };
                        var data = context.Database.SqlQuery<Utilizadores>("showPasswordFromEmail @Email", param).ToList();
                        
                        if(data.Count < 1)
                        {
                            // Encriptar password
                            string passEncrypt = My_Locker_V2.Classes.MyCommonUtilities.Encrypt(formData.Password);

                            int membro;

                            if (formData.Membro == true) { membro = 1; } else { membro = 0; }

                            SqlParameter[] param2 = new SqlParameter[]{new SqlParameter("@Nome", formData.Nome),
                            new SqlParameter("@Apelido", formData.Apelido),
                            new SqlParameter("@Email", formData.Email),
                            new SqlParameter("@Password", passEncrypt),
                            new SqlParameter("@Membro", membro), };

                            try
                            {
                                context.Database.ExecuteSqlCommand("Add_Utilizador @Nome,@Apelido,@Email,@Password,@Membro", param2);
                            }
                            catch (Exception er) { }
                        }
                        else
                        {
                            ModelState.AddModelError("Email", "Email já registado, Aceda a pagina de login para entrar");
                            return View("Index", formData);
                        }

                   
                    }
                    catch (Exception er) { }
                           

                }
                else
                {
                    ModelState.AddModelError("Email", "Email Inválido");
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
    