using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Usings
using System.Threading.Tasks;
using ProyectoIntegradorMvc461.Models;

namespace ProyectoIntegradorMvc461.Controllers
{
    public class EmpresaController : Controller
    {
        EmpresaModel model;
        public EmpresaController()
        {
            this.model = new EmpresaModel();
        }

        // GET: Empresas
        [AsyncTimeout(1000)]
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
            return View();
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