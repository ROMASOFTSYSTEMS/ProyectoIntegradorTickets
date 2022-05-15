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
    public class PerfilController : Controller
    {
        PerfilModel model;
        public PerfilController()
        {
            this.model = new PerfilModel();
        }

        // GET: Perfils
        [AsyncTimeout(1000)]
        [AutorizaUsuario(IdOpcion: 7)]   // Filtro 
        public async Task<ActionResult> Index()
        {
            List<Perfil> cList = await model.GetPerfil();
            return View(cList);
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Detalle(int id)
        {
            Perfil c = await model.GetPerfilByID(id);
            return View(c);
        }

        // GET: Contacts/Create
        public async Task<ActionResult> Crear()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public async Task<ActionResult> Crear(Perfil c)
        {
            try
            {
                await model.AddPerfil(c);
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
            Perfil c = await model.GetPerfilByID(id);
            return View(c);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Editar(Perfil c)
        {
            try
            {
                await model.EditPerfil(c);
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
            await model.DeletePerfil(id);
            return RedirectToAction("Index");
        }
    }
}