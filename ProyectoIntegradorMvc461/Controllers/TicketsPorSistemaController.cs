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
    public class TicketsPorSistemaController : Controller
    {
        
        SistemaModel modelSistema;
        TicketModel modelTicket;
        public TicketsPorSistemaController()
        {
            this.modelSistema = new SistemaModel();
            this.modelTicket = new TicketModel();
        }

        // GET: TicketsPorSistema
        [AsyncTimeout(1000)]
        [AutorizaUsuario(IdOpcion: 7)]   // Filtro 
        public async Task<ActionResult> Index(string cboSistema = "")
        {
            int id_sistema = 0;
            try
            {
                id_sistema = Convert.ToInt32(cboSistema);
            }
            catch (Exception xx)
            {
                id_sistema = 0;
            }

            #region Combo Modulo
            List<Sistema> LstSistema = await this.modelSistema.GetSistema();
            List<SelectListItem> ItemsSistema = LstSistema.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.t_sistema.ToString(),
                    Value = d.id_sistema.ToString(),
                    Selected = false
                };
            });
            #endregion
            ViewBag.ItemsSistema = ItemsSistema;
            List<Ticket> cList;
            if (id_sistema == 0)
            {
                cList = new List<Ticket>();
                cList = await modelTicket.GetTickets();
            }
            else
            {
                cList = new List<Ticket>();
                cList = await modelTicket.GetTicketPorSistema(id_sistema);
            }

            return View(cList);
        }
    }
}