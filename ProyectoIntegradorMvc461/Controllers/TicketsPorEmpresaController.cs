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
    public class TicketsPorEmpresaController : Controller
    {
        EmpresaModel modelEmpresa;
        EstadoModel modelEstado;
        TicketModel modelTicket;
        public TicketsPorEmpresaController()
        {
            this.modelEmpresa = new EmpresaModel();
            this.modelEstado = new EstadoModel();
            this.modelTicket = new TicketModel();
        }

        //// GET: TicketsPorEmpresa
        //public ActionResult Index()
        //{
        //    return View();
        //}
        
        // GET: Perfils
        [AsyncTimeout(1000)]
        [AutorizaUsuario(IdOpcion: 7)]   // Filtro 
        public async Task<ActionResult> Index(string cboEmpresa="")
        {
            int id_empresa = 0;
            try
            {
                id_empresa = Convert.ToInt32(cboEmpresa);
            }
            catch (Exception xx)
            {
                id_empresa = 0;
            }

            #region Combo Estado
            List<Estado> cListEstado = await this.modelEstado.GetEstado();
            List<SelectListItem> ItemsEstado = cListEstado.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.t_estado.ToString(),
                    Value = d.id_estado.ToString(),
                    Selected = false
                };
            });
            #endregion            
            #region Combo Empresa
            List<Empresa> LstEmpresa = await this.modelEmpresa.GetEmpresa();
            List<SelectListItem> ItemsEmpresa = LstEmpresa.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.t_empresa.ToString(),
                    Value = d.id_empresa.ToString(),
                    Selected = false
                };
            });
            #endregion
            ViewBag.ItemsEstado = ItemsEstado;
            ViewBag.ItemsEmpresa = ItemsEmpresa;
            List<Ticket> cList;
            if (id_empresa == 0)
            {
                cList = new List<Ticket>();
                cList = await modelTicket.GetTickets();
            }
            else
            {
                cList = new List<Ticket>();
                cList = await modelTicket.GetTicketPorEmpresa(id_empresa); 
            }
            
            return View(cList);
        }

    }
}