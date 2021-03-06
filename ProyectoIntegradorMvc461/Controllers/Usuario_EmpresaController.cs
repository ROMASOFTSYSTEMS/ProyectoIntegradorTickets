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
// Filtros
using ProyectoIntegradorMvc461.Filters;

namespace ProyectoIntegradorMvc461.Controllers
{
    public class Usuario_EmpresaController : Controller
    {
        EstadoModel modelEstado;
        UsuarioModel modelUsuario;
        EmpresaModel modelEmpresa;
        Usuario_EmpresaModel modelUsuario_Empresa;

        private String UriApi;
        private readonly IConfiguration _configuration;
        MediaTypeWithQualityHeaderValue mediaheader;
        public Usuario_EmpresaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Usuario_EmpresaController()
        {
            this.modelEstado = new EstadoModel();
            this.modelEmpresa = new EmpresaModel();
            this.modelUsuario = new UsuarioModel();
            this.modelUsuario_Empresa = new Usuario_EmpresaModel();
            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }
        [AsyncTimeout(1000)]
        [AutorizaUsuario(IdOpcion: 8)]   // Filtro
        public async Task<ActionResult> Index()
        {
            List<Usuario_Empresa> LstListado = new List<Usuario_Empresa>();
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Usuario_Empresa";
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
                    LstListado = JsonConvert.DeserializeObject<List<Usuario_Empresa>>(_clientResponse);
                }
                //else { return null; }
            }
            //(IActionResult)
            return View(LstListado);  //(IActionResult)
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
            var id_usuario = Convert.ToInt32(Session["id_usuario"]);
            //List<Usuario_Empresa> LstUsuarioEmpresa = await this.modelUsuario_Empresa.GetUsuario_Empresas(id_usuario);

            ViewBag.ItemsEstado = ItemsEstado;
            ViewBag.ItemsUsuario = ItemsUsuario;
            ViewBag.ItemsEmpresa = ItemsEmpresa;
            Usuario_Empresa ObjEntidadNew = new Usuario_Empresa();
            ObjEntidadNew.id_usuario_empresa = 0;
            ObjEntidadNew.id_usuario = id_usuario;
            ObjEntidadNew.f_estado = 1;
            ObjEntidadNew.id_empresa = 0;
            // Variables Globales
            Session["id_empresa"] = 0;
            /*if (LstUsuarioEmpresa.Count > 0)
            {
                ObjEntidadNew.id_empresa = Convert.ToInt32(LstUsuarioEmpresa[0].id_empresa);
                Session["id_empresa"] = ObjEntidadNew.id_empresa;
            }*/

            return View(ObjEntidadNew);
        }

        // POST: Contacts/Create
        [HttpPost]
        public async Task<ActionResult> Crear(Usuario_Empresa c)
        {
            //Aqui Se le reasigna los valores a c
            //c.id_usuario = Convert.ToInt32(Session["id_usuario"]);
            //c.id_empresa = Convert.ToInt32(Session["id_empresa"]);

            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Usuario_Empresa";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PostAsJsonAsync(peticion, c);
                return RedirectToAction("Index");
            }
            //return View();
        }

        // GET: Contacts/Edit/5
        public async Task<ActionResult> Editar(int id)
        {
            // Para cargar Combos
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
            var id_usuario = Convert.ToInt32(Session["id_usuario"]);
            //List<Usuario_Empresa> LstUsuarioEmpresa = await this.modelUsuario_Empresa.GetUsuario_Empresas(id_usuario);

            ViewBag.ItemsEstado = ItemsEstado;
            ViewBag.ItemsUsuario = ItemsUsuario;
            ViewBag.ItemsEmpresa = ItemsEmpresa;

            Usuario_Empresa c = await modelUsuario_Empresa.GetUsuario_EmpresaByID(id);
            return View(c);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Editar(Usuario_Empresa c)
        {
            try
            {
                await modelUsuario_Empresa.EditUsuario_Empresa(c);
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
            await modelUsuario_Empresa.DeleteUsuario_Empresa(id);
            return RedirectToAction("Index");
        }
    }
}
