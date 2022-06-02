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
    public class Tipo_TicketController : Controller
    {
        Tipo_TicketModel model;
        EstadoModel modelEstado;
        public Tipo_TicketController()
        {
            this.model = new Tipo_TicketModel();
            this.modelEstado = new EstadoModel();
        }

        // GET: Tipo_Tickets
        [AsyncTimeout(1000)]
        [AutorizaUsuario(IdOpcion: 12)]   // Filtro 
        public async Task<ActionResult> Index()
        {
            List<Tipo_Ticket> cList = await model.GetTipo_Ticket();
            return View(cList);
        }

        // GET: Tipo_Ticket/Detalle/5
        public async Task<ActionResult> Detalle(int id)
        {
            Tipo_Ticket c = await model.GetTipo_TicketByID(id);
            return View(c);
        }

        // GET: Tipo_Ticket/Crear
        public async Task<ActionResult> Crear()
        {
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
            Tipo_Ticket ObjEntidadNew = new Tipo_Ticket();
            ObjEntidadNew.id_tipo_ticket = 0;
            ObjEntidadNew.f_estado = 1;
            return View(ObjEntidadNew);
            //return View();
        }

        // POST: Tipo_Ticket/Crear
        [HttpPost]
        public async Task<ActionResult> Crear(Tipo_Ticket c)
        {
            try
            {
                await model.AddTipo_Ticket(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tipo_Ticket/Editar/5
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
            Tipo_Ticket c = await model.GetTipo_TicketByID(id);
            return View(c);
        }

        // POST: Tipo_Ticket/Editar/5
        [HttpPost]
        public async Task<ActionResult> Editar(Tipo_Ticket c)
        {
            try
            {
                await model.EditTipo_Ticket(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Tipo_Ticket/Eliminar/5
        public async Task<ActionResult> Eliminar(int id)
        {
            await model.DeleteTipo_Ticket(id);
            return RedirectToAction("Index");
        }
    }
}