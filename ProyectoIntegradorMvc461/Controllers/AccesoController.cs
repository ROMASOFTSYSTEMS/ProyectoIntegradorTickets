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
        Perfil_OpcionModel modelPerfilOpcion;
        Usuario_PerfilModel modelUsuarioPerfil;
        Usuario_PerfilesModel modelUsuarioPerfiles;
        private int id_perfil;
        public AccesoController()
        {
            this.model = new UsuarioModel();
            this.modelPerfilOpcion = new Perfil_OpcionModel();
            this.modelUsuarioPerfil = new Usuario_PerfilModel();
            this.modelUsuarioPerfiles = new Usuario_PerfilesModel();
        }

        // GET: Acceso
        public ActionResult Login()
        {
            Session["User"] = null;
            Session["TipoUsuario"] = "";
            ViewBag.TipoUsuario = "";
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
                    ViewBag.Error = "Usuario o contraseña invalido";
                    return View();
                }
                //Session["Username"] = Obj.c_usuario.ToString();
                //var IdUsuario = Convert.ToInt32(Session["IdUsuario"]);
                
                List<Usuario_Perfil> LstUsuarioPerfil = await modelUsuarioPerfiles.GetUsuario_Perfiles(Obj.id_usuario);
                if (LstUsuarioPerfil.Count() < 1)
                {
                    Session["TipoUsuario"] = "Sin Perfil";
                    ViewBag.TipoUsuario = "Sin Perfil";
                    ViewBag.Error = "Usuario no cuenta con un Perfil Definido";
                    return View();
                }
                id_perfil = LstUsuarioPerfil[0].id_perfil;
                
                List <Perfil_Opcion> LstPerfilOpcion = await modelPerfilOpcion.GetPerfil_Opciones(id_perfil);
                Session["User"] = Obj;
                Session["Opciones"] = LstPerfilOpcion;
                Session["Perfil"] = LstUsuarioPerfil;
                Session["id_usuario"] = Obj.id_usuario;
                Session["TipoUsuario"] = LstUsuarioPerfil[0].t_perfil;
                ViewBag.TipoUsuario = Session["TipoUsuario"];
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