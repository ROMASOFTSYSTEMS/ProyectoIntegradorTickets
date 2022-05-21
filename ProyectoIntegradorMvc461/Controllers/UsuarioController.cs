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
        EstadoModel modelEstado;
        public UsuarioController()
        {
            this.model = new UsuarioModel();
            this.modelEstado = new EstadoModel();
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
            List<Estado> cListEstado = await this.modelEstado.GetEstado();
            //SelectListItem ObjSelectListItem = new SelectListItem();
            List<SelectListItem> ItemsEstado = cListEstado.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.t_estado.ToString(),
                    Value = d.id_estado.ToString(),
                    Selected = false
                };
            });
            ViewBag.ItemsEstado = ItemsEstado;
            Usuario ObjEntidadNew = new Usuario();
            ObjEntidadNew.id_usuario = 0;
            ObjEntidadNew.f_estado = 1;
            return View(ObjEntidadNew);
            //return View();
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
            // Para cargar Combo de Estado
            List<Estado> cListEstado = await this.modelEstado.GetEstado();
            List<SelectListItem> ItemsEstado = cListEstado.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.t_estado.ToString(),
                    Value = d.id_estado.ToString(),
                    Selected = false
                };
            });
            ViewBag.ItemsEstado = ItemsEstado;
            Usuario c = await model.GetUsuarioByID(id);
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