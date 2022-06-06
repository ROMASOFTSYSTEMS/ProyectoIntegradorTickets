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
    public class TicketsPorModuloController : Controller
    {
        ModuloModel modelModulo;
        TicketModel modelTicket;
        public TicketsPorModuloController()
        {
            this.modelModulo = new ModuloModel();
            this.modelTicket = new TicketModel();
        }

        // GET: TicketsPorModulo
        [AsyncTimeout(1000)]
        [AutorizaUsuario(IdOpcion: 7)]   // Filtro 
        public async Task<ActionResult> Index(string cboModulo = "")
        {
            int id_modulo = 0;
            try
            {
                id_modulo = Convert.ToInt32(cboModulo);
            }
            catch (Exception xx)
            {
                id_modulo = 0;
            }
           
            #region Combo Modulo
            List<Modulo> LstModulo = await this.modelModulo.GetModulo();
            List<SelectListItem> ItemsModulo = LstModulo.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.t_modulo.ToString(),
                    Value = d.id_modulo.ToString(),
                    Selected = false
                };
            });
            #endregion
            ViewBag.ItemsModulo = ItemsModulo;
            List<Ticket> cList;
            if (id_modulo == 0)
            {
                cList = new List<Ticket>();
                cList = await modelTicket.GetTickets();
            }
            else
            {
                cList = new List<Ticket>();
                cList = await modelTicket.GetTicketPorModulo(id_modulo);
            }

            return View(cList);
        }
    }
}