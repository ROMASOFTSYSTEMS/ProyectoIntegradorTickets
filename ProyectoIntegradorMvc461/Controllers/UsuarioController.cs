using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Usings
using System.Threading.Tasks;
using ProyectoIntegradorMvc461.Models;
using ProyectoIntegradorMvc461.Filters;

namespace ProyectoIntegradorMvc461.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioModel model;
        public UsuarioController()
        {
            this.model = new UsuarioModel();
        }

        // GET: Usuarios
        [AsyncTimeout(1000)]
        [AutorizaUsuario(IdOpcion: 6)]   // Filtro 
        public async Task<ActionResult> Index()
        {
            List<Usuario> cList = await model.GetUsuario();
            return View(cList);
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Detalle(int id)
        {
            Usuario c = await model.GetUsuarioByID(id);
            return View(c);
        }

        // GET: Contacts/Create
        public async Task<ActionResult> Crear()
        {
            Usuario ObjEntidadNew = new Usuario();
            ObjEntidadNew.id_usuario = 0;
            ObjEntidadNew.f_estado = 1;
            return View(ObjEntidadNew);
        }

        // POST: Contacts/Create
        [HttpPost]
        public async Task<ActionResult> Crear(Usuario c)
        {
            try
            {
                await model.AddUsuario(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



    // GET: Contacts/Edit/5
    public async Task<ActionResult> Editar(int id)
        {
            Usuario c = await model.GetUsuarioByID(id);
            //Usuario ObjEntidadNew = new Usuario();
            //ObjEntidadNew.id_usuario = 0;
            //ObjEntidadNew.f_estado = 1;

            return View(c);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Editar(Usuario c)
        {
            try
            {
                await model.EditUsuario(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Eliminar(int id)
        {
            await model.DeleteUsuario(id);
            return RedirectToAction("Index");
        }
    }
}