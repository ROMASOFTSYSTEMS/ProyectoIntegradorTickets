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
    public class Usuario_EmpresaController : Controller
    {
        Usuario_EmpresaModel model;
        EstadoModel modelEstado;
        public Usuario_EmpresaController()
        {
            this.model = new Usuario_EmpresaModel();
            this.modelEstado = new EstadoModel();
        }

        // GET: Usuario_Empresa
        [AsyncTimeout(1000)]
        [AutorizaUsuario(IdOpcion: 7)]   // Filtro 
        public async Task<ActionResult> Index()
        {
            List<Usuario_Empresa> cList = await model.GetUsuario_Empresa();
            return View(cList);
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Detalle(int id)
        {
            Usuario_Empresa c = await model.GetUsuario_EmpresaByID(id);
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
            Usuario_Empresa ObjEntidadNew = new Usuario_Empresa();
            ObjEntidadNew.id_usuario_empresa = 0;
            ObjEntidadNew.f_estado = 1;
            return View(ObjEntidadNew);
            //return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public async Task<ActionResult> Crear(Usuario_Empresa c)
        {
            try
            {
                await model.AddUsuario_Empresa(c);
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
            Usuario_Empresa c = await model.GetUsuario_EmpresaByID(id);
            return View(c);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Editar(Usuario_Empresa c)
        {
            try
            {
                await model.EditUsuario_Empresa(c);
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
            await model.DeleteUsuario_Empresa(id);
            return RedirectToAction("Index");
        }
    }
}