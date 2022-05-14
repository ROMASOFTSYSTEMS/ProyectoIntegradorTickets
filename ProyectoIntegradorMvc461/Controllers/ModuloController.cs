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
    public class ModuloController : Controller
    {
        ModuloModel model;
        public ModuloController()
        {
            this.model = new ModuloModel();
        }

        // GET: Modulos
        [AsyncTimeout(1000)]
        public async Task<ActionResult> Index()
        {
            List<Modulo> cList = await model.GetModulo();
            return View(cList);
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Modulo c = await model.GetModuloByID(id);
            return View(c);
        }

        // GET: Contacts/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public async Task<ActionResult> Create(Modulo c)
        {
            try
            {
                await model.AddModulo(c);
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
            Modulo c = await model.GetModuloByID(id);
            return View(c);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Modulo c)
        {
            try
            {
                await model.EditModulo(c);
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
            await model.DeleteModulo(id);
            return RedirectToAction("Index");
        }
    }
}