using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// Usings
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorMvc461.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ProyectoIntegradorMvc461.Controllers
{
    public class TicketController : Controller
    {
        public int pid_usuario { get; set; }
        public int pid_empresa { get; set; }
        EstadoModel modelEstado;
        EmpresaModel modelEmpresa;
        UsuarioModel modelUsuario;
        SistemaModel modelSistema;
        ModuloModel modelModulo;
        Tipo_TicketModel modelTipo_Ticket;
        Estado_TicketModel modelEstado_Ticket;
        // 
        Usuario_EmpresaModel modelUsuario_Empresa;

        //string Url = "https://localhost:44396/";
        private String UriApi;
        private readonly IConfiguration _configuration;
        MediaTypeWithQualityHeaderValue mediaheader;
        public TicketController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TicketController()
        {
            this.modelEstado = new EstadoModel();
            this.modelEmpresa = new EmpresaModel();
            this.modelUsuario = new UsuarioModel();
            this.modelSistema = new SistemaModel();
            this.modelModulo = new ModuloModel();
            this.modelTipo_Ticket = new Tipo_TicketModel();
            this.modelEstado_Ticket = new Estado_TicketModel();
            //
            this.modelUsuario_Empresa = new Usuario_EmpresaModel();

            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }
        //public async Task<IActionResult> Index()
        public async Task<ActionResult> Index()
        {
            List<Ticket> TicketsAll = new List<Ticket>();
            #region Anterior
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(Url);
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //    // LLamar a Todos los Tickets usando HttpClient
            //    HttpResponseMessage Res = await client.GetAsync("Ticket/");
            //    //if (Res.IsSuccessStatusCode)
            //    //{
            //    // Si Res=true entra y Asigna los datos
            //    var _clientResponse = Res.Content.ReadAsStringAsync().Result;
            //    //Deserializar el Api y Almacenar los datos
            //    TicketsAll = JsonConvert.DeserializeObject<List<Ticket>>(_clientResponse);
            //    //}
            //}
            #endregion
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Ticket";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    //List<Empresa> cList = await respuesta.Content.ReadAsAsync<List<Empresa>>();
                    //return cList;
                    var _clientResponse = respuesta.Content.ReadAsStringAsync().Result;
                    //Deserializar el Api y Almacenar los datos
                    TicketsAll = JsonConvert.DeserializeObject<List<Ticket>>(_clientResponse);
                }
                //else { return null; }
            }
            //(IActionResult)
            return View(TicketsAll);  //(IActionResult)
        }
        // GET: Contacts/Create
        public async Task<ActionResult> Crear()
        {
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
            #region Combo Usuario
            List<Usuario> LstUsuario = await this.modelUsuario.GetUsuario();
            List<SelectListItem> ItemsUsuario = LstUsuario.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.c_usuario.ToString(),
                    Value = d.id_usuario.ToString(),
                    Selected = false
                };
            });
            #endregion
            #region Combo Sistema
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
            #region Combo Tipo_Ticket
            List<Tipo_Ticket> LstTipo_Ticket = await this.modelTipo_Ticket.GetTipo_Ticket();
            List<SelectListItem> ItemsTipo_Ticket = LstTipo_Ticket.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.t_tipo_ticket.ToString(),
                    Value = d.id_tipo_ticket.ToString(),
                    Selected = false
                };
            });
            #endregion
            #region Combo Estado_Ticket
            List<Estado_Ticket> LstEstado_Ticket = await this.modelEstado_Ticket.GetEstado_Ticket();
            List<SelectListItem> ItemsEstado_Ticket = LstEstado_Ticket.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.t_estado_ticket.ToString(),
                    Value = d.id_estado_ticket.ToString(),
                    Selected = false
                };
            });
            #endregion
            var id_usuario = Convert.ToInt32(Session["id_usuario"]);
            List<Usuario_Empresa> LstUsuarioEmpresa = await this.modelUsuario_Empresa.GetUsuario_Empresas(id_usuario);

            ViewBag.ItemsEstado = ItemsEstado;
            ViewBag.ItemsEmpresa = ItemsEmpresa;
            ViewBag.ItemsUsuario = ItemsUsuario;
            ViewBag.ItemsSistema = ItemsSistema;
            ViewBag.ItemsModulo = ItemsModulo;
            ViewBag.ItemsTipo_Ticket = ItemsTipo_Ticket;
            ViewBag.ItemsEstado_Ticket = ItemsEstado_Ticket;

            Ticket ObjEntidadNew = new Ticket();
            ObjEntidadNew.id_ticket = 0;
            ObjEntidadNew.id_usuario = id_usuario;
            ObjEntidadNew.f_estado = 1;
            ObjEntidadNew.id_empresa = 0;
            // Variables Globales
            this.pid_usuario = id_usuario;
            this.pid_empresa = 0;
            Session["id_empresa"] = 0;
            if (LstUsuarioEmpresa.Count > 0)
            {
                ObjEntidadNew.id_empresa = Convert.ToInt32(LstUsuarioEmpresa[0].id_empresa);
                this.pid_empresa = ObjEntidadNew.id_empresa;
                Session["id_empresa"] = ObjEntidadNew.id_empresa;
            }

            return View(ObjEntidadNew);
        }

        // POST: Contacts/Create
        [HttpPost]
        public async Task<ActionResult> Crear(Ticket c)
        {
            //Aqui Se le reasigna los valores a c
            
            c.id_usuario = Convert.ToInt32(Session["id_usuario"]);
            c.id_empresa = Convert.ToInt32(Session["id_empresa"]);

            //try
            //{
            //    await model.AddPerfil(c);
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}

            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Ticket";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PostAsJsonAsync(peticion, c);
                return RedirectToAction("Index");
            }
            //return View();
        }
    }
}