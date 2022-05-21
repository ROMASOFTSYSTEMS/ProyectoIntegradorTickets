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
    public class SistemaController : Controller
    {
        SistemaModel model;
        EstadoModel modelEstado;
        public SistemaController()
        {
            this.model = new SistemaModel();
            this.modelEstado = new EstadoModel();
        }

        // GET: Sistemas
        [AsyncTimeout(1000)]
        [AutorizaUsuario(IdOpcion: 3)]   // Filtro 
        public async Task<ActionResult> Index()
        {
            List<Sistema> cList = await model.GetSistema();
            return View(cList);
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Detalle(int id)
        {
            Sistema c = await model.GetSistemaByID(id);
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
            Sistema ObjEntidadNew = new Sistema();
            ObjEntidadNew.id_sistema = 0;
            ObjEntidadNew.f_estado = 1;
            return View(ObjEntidadNew);
            //return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public async Task<ActionResult> Crear(Sistema c)
        {
            try
            {
                await model.AddSistema(c);
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
            Sistema c = await model.GetSistemaByID(id);
            return View(c);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Editar(Sistema c)
        {
            try
            {
                await model.EditSistema(c);
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
            await model.DeleteSistema(id);
            return RedirectToAction("Index");
        }
    }
}