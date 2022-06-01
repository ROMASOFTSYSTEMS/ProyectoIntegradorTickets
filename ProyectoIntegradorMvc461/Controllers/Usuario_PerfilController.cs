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
    public class Usuario_PerfilController : Controller
    {
        EstadoModel modelEstado;
        UsuarioModel modelUsuario;
        PerfilModel modelPerfil;
        Usuario_PerfilModel modelUsuario_Perfil;
        
        private String UriApi;
        private readonly IConfiguration _configuration;
        MediaTypeWithQualityHeaderValue mediaheader;
        public Usuario_PerfilController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Usuario_PerfilController()
        {
            this.modelEstado = new EstadoModel();
            this.modelPerfil = new PerfilModel();
            this.modelUsuario = new UsuarioModel();
            this.modelUsuario_Perfil = new Usuario_PerfilModel();
            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }
        [AsyncTimeout(1000)]
        [AutorizaUsuario(IdOpcion: 9)]   // Filtro
        public async Task<ActionResult> Index()
        {
            List<Usuario_Perfil> LstListado = new List<Usuario_Perfil>();
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Usuario_Perfil";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    var _clientResponse = respuesta.Content.ReadAsStringAsync().Result;
                    //Deserializar el Api y Almacenar los datos
                    LstListado = JsonConvert.DeserializeObject<List<Usuario_Perfil>>(_clientResponse);
                }
            }
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
            #region Combo Perfil
            List<Perfil> LstPerfil = await this.modelPerfil.GetPerfil();
            List<SelectListItem> ItemsPerfil = LstPerfil.ConvertAll(d => {
                return new SelectListItem()
                {
                    Text = d.t_perfil.ToString(),
                    Value = d.id_perfil.ToString(),
                    Selected = false
                };
            });
            #endregion
            var id_usuario = Convert.ToInt32(Session["id_usuario"]);
            //List<Usuario_Perfil> LstUsuarioEmpresa = await this.modelUsuario_Perfil.GetUsuario_Perfils(id_usuario);

            ViewBag.ItemsEstado = ItemsEstado;
            ViewBag.ItemsUsuario = ItemsUsuario;
            ViewBag.ItemsPerfil = ItemsPerfil;
            Usuario_Perfil ObjEntidadNew = new Usuario_Perfil();
            ObjEntidadNew.id_usuario_perfil = 0;
            ObjEntidadNew.id_usuario = id_usuario;
            ObjEntidadNew.id_perfil = 0;
            ObjEntidadNew.f_estado = 1;
            // Variables Globales
            //Session["id_empresa"] = 0;
            return View(ObjEntidadNew);
        }

        // POST: Contacts/Create
        [HttpPost]
        public async Task<ActionResult> Crear(Usuario_Perfil c)
        {
            //Aqui Se le reasigna los valores a c
            //c.id_usuario = Convert.ToInt32(Session["id_usuario"]);
            //c.id_empresa = Convert.ToInt32(Session["id_empresa"]);

            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Usuario_Perfil";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PostAsJsonAsync(peticion, c);
                return RedirectToAction("Index");
            }
            //return View();
        }

        // manolo
        //// GET: Contacts/Edit/5
        public async Task<ActionResult> Editar(int id)
        {
            // Para cargar Combos
            #region Combo Estado
            List<Estado> cListEstado = await this.modelEstado.GetEstado();
            List<SelectListItem> ItemsEstado = cListEstado.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.t_estado.ToString(),
                    Value = d.id_estado.ToString(),
                    Selected = false
                };
            });
            #endregion
            #region Combo Usuario
            List<Usuario> LstUsuario = await this.modelUsuario.GetUsuario();
            List<SelectListItem> ItemsUsuario = LstUsuario.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.c_usuario.ToString(),
                    Value = d.id_usuario.ToString(),
                    Selected = false
                };
            });
            #endregion
            #region Combo Perfil
            List<Perfil> LstPerfil = await this.modelPerfil.GetPerfil();
            List<SelectListItem> ItemsPerfil = LstPerfil.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.t_perfil.ToString(),
                    Value = d.id_perfil.ToString(),
                    Selected = false
                };
            });
            #endregion
            var id_usuario = Convert.ToInt32(Session["id_usuario"]);
            Usuario_Perfil ObjUsuarioPerfil = await modelUsuario_Perfil.GetUsuario_PerfilByID(id);
            ViewBag.ItemsEstado = ItemsEstado;
            ViewBag.ItemsUsuario = ItemsUsuario;
            ViewBag.ItemsPerfil = ItemsPerfil;
            return View(ObjUsuarioPerfil);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Editar(Usuario_Perfil c)
        {
            try
            {
                await modelUsuario_Perfil.EditUsuario_Perfil(c);
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
            await modelUsuario_Perfil.DeleteUsuario_Perfil(id);
            return RedirectToAction("Index");
        }
    }
}
