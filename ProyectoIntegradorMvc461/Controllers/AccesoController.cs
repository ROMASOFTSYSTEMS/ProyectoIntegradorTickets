using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Usings
using System.Threading.Tasks;
using ProyectoIntegradorMvc461.Models;

namespace ProyectoIntegradorMvc461.Controllers
{
    public class AccesoController : Controller
    {
        UsuarioModel model;
        public AccesoController()
        {
            this.model = new UsuarioModel();
        }

        // GET: Acceso
        public ActionResult Login()
        {
            Session["User"] = null;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string User, string Pass)
        {
            try
            {
                // Aqui se pone la logica para extraer el Usuario y Clave
                Usuario Obj = await model.GetUsuarioByUserPass(User, Pass);
                if (Obj == null)
                {
                    ViewBag.Error = "Usuario o contrasena invalido";
                    return View();
                }
                Session["User"] = Obj;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        //[HttpPost]
        //public async Task<ActionResult> Login(string User, string Pass)
        //{
        //    try
        //    {
        //        // Aqui se pone la logica para extraer el Usuario y Clave
        //        Usuario Obj = await model.GetUsuarioByUserPass(User, Pass);
        //        if (Obj == null)
        //        {
        //            ViewBag.Error = "Usuario o contrasena invalido";
        //            return View();
        //        }
        //        Session["User"] = Obj;
        //        return RedirectToAction("Index", "Home");
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = ex.Message;
        //        return View();
        //    }
        //}

        //// GET: Contacts/Details/5
        //public async Task<ActionResult> Details(int id)
        //{
        //    Empresa c = await model.GetEmpresaByID(id);
        //    return View(c);
        //}

    }
}