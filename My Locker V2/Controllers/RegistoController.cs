using My_Locker_V2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        [HttpPost]
        public ActionResult Submited(Models.Utilizadores formData)
        {
            try
            {
                

                if (formData.Email != "")
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
                    }
                    hasEmail = false;

                    if(hasEmail == false)
                    {

                    }
                    else
                    {
                        // Mandar msg de erro 
                    }

                }

            }
            catch (Exception er)
            {

            }

            return View();


        }


        /*
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@Nome",Nome),
            new SqlParameter("@Apelido",Apelido),
            new SqlParameter("@Email",Email),
            new SqlParameter("@Password",Password),
            new SqlParameter("@Membro","0"),
        };
        // var data = context.Database.SqlQuery<Users>("Add_Utilizador @Nome,@Apelido,@Email,@Password,@Membro",param);
        try
        {
            context.Database.ExecuteSqlCommand("Add_Utilizador @Nome,@Apelido,@Email,@Password,@Membro", param);
        }
        catch (Exception er) { }
        */


    }
}
    