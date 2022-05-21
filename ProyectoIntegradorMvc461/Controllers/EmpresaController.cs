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
    public class EmpresaController : Controller
    {
        EmpresaModel model;
        EstadoModel modelEstado;
        public EmpresaController()
        {
            this.model = new EmpresaModel();
            this.modelEstado = new EstadoModel();
        }

        // GET: Empresas
        [AsyncTimeout(1000)]
        [AutorizaUsuario(IdOpcion:2)]   // Filtro 
        public async Task<ActionResult> Index()
        {
            List<Empresa> cList = await model.GetEmpresa();
            return View(cList);
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Empresa c = await model.GetEmpresaByID(id);
            return View(c);
        }

        // GET: Contacts/Create
        public async Task<ActionResult> Create()
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
            Empresa ObjEntidadNew = new Empresa();
            ObjEntidadNew.id_empresa = 0;
            ObjEntidadNew.f_estado = 1;
            return View(ObjEntidadNew);
        }

        // POST: Contacts/Create
        [HttpPost]
        public async Task<ActionResult> Create(Empresa c)
        {
            try
            {
                await model.AddEmpresa(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Edit/5
        public async Task<ActionResult> Edit(int id)
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
            Empresa c = await model.GetEmpresaByID(id);
            return View(c);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Empresa c)
        {
            try
            {
                await model.EditEmpresa(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await model.DeleteEmpresa(id);
            return RedirectToAction("Index");
        }
    }
}