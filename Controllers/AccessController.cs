using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaPP.Models;
namespace PruebaPP.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, int  password)
        {   
            try
            {
                
                using (Entities db=new Entities()) 
                {
                    var lst = from d in db.usuario
                              where d.correo == user && d.codigo == password
                              select d;
                    if (lst.Count() > 0)
                    {
                        usuario oUser = lst.First();
                        Session["user"] = oUser.rol;
                        return RedirectToAction("Index", "Home");
                        
                    }
                    else {

                        return RedirectToAction("Index", "Access");
                    }
                }

                   
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :"+ ex.Message);
            }
        
        }
    }
}