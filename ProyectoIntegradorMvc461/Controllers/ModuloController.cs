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
    public class ModuloController : Controller
    {
        ModuloModel model;
        EstadoModel modelEstado;
        public ModuloController()
        {
            this.model = new ModuloModel();
            this.modelEstado = new EstadoModel();
        }

        // GET: Modulos
        [AsyncTimeout(1000)]
        [AutorizaUsuario(IdOpcion: 4)]   // Filtro 
        public async Task<ActionResult> Index()
        {
            List<Modulo> cList = await model.GetModulo();
            return View(cList);
        }

        // GET: Modulo/Detalle/5
        public async Task<ActionResult> Detalle(int id)
        {
            Modulo c = await model.GetModuloByID(id);
            return View(c);
        }

        // GET: Modulo/Crear
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
            Modulo ObjEntidadNew = new Modulo();
            ObjEntidadNew.id_modulo = 0;
            ObjEntidadNew.f_estado = 1;
            return View(ObjEntidadNew);
            //return View();
        }

        // POST: Modulo/Crear
        [HttpPost]
        public async Task<ActionResult> Crear(Modulo c)
        {
            try
            {
                await model.AddModulo(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Modulo/Editar/5
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
            Modulo c = await model.GetModuloByID(id);
            return View(c);
        }

        // POST: Modulo/Editar/5
        [HttpPost]
        public async Task<ActionResult> Editar(Modulo c)
        {
            try
            {
                await model.EditModulo(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Modulo/Eliminar/5
        public async Task<ActionResult> Eliminar(int id)
        {
            await model.DeleteModulo(id);
            return RedirectToAction("Index");
        }
    }
}