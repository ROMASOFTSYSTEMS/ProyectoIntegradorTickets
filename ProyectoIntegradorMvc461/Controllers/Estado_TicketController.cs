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
    public class Estado_TicketController : Controller
    {
        Estado_TicketModel model;
        EstadoModel modelEstado;
        public Estado_TicketController()
        {
            this.model = new Estado_TicketModel();
            this.modelEstado = new EstadoModel();
        }

        // GET: Estado_Tickets
        [AsyncTimeout(1000)]
        [AutorizaUsuario(IdOpcion: 11)]   // Filtro 
        public async Task<ActionResult> Index()
        {
            List<Estado_Ticket> cList = await model.GetEstado_Ticket();
            return View(cList);
        }

        // GET: Estado_Ticket/Detalle/5
        public async Task<ActionResult> Detalle(int id)
        {
            Estado_Ticket c = await model.GetEstado_TicketByID(id);
            return View(c);
        }

        // GET: Estado_Ticket/Crear
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
            Estado_Ticket ObjEntidadNew = new Estado_Ticket();
            ObjEntidadNew.id_estado_ticket = 0;
            ObjEntidadNew.f_estado = 1;
            return View(ObjEntidadNew);
            //return View();
        }

        // POST: Estado_Ticket/Crear
        [HttpPost]
        public async Task<ActionResult> Crear(Estado_Ticket c)
        {
            try
            {
                await model.AddEstado_Ticket(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estado_Ticket/Editar/5
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
            Estado_Ticket c = await model.GetEstado_TicketByID(id);
            return View(c);
        }

        // POST: Estado_Ticket/Editar/5
        [HttpPost]
        public async Task<ActionResult> Editar(Estado_Ticket c)
        {
            try
            {
                await model.EditEstado_Ticket(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Estado_Ticket/Eliminar/5
        public async Task<ActionResult> Eliminar(int id)
        {
            await model.DeleteEstado_Ticket(id);
            return RedirectToAction("Index");
        }
    }
}