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
    public class SistemaController : Controller
    {
        SistemaModel model;
        public SistemaController()
        {
            this.model = new SistemaModel();
        }

        // GET: Sistemas
        [AsyncTimeout(1000)]
        public async Task<ActionResult> Index()
        {
            List<Sistema> cList = await model.GetSistema();
            return View(cList);
        }

        // GET: Contacts/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Sistema c = await model.GetSistemaByID(id);
            return View(c);
        }

        // GET: Contacts/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public async Task<ActionResult> Create(Sistema c)
        {
            try
            {
                await model.AddSistema(c);
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
            Sistema c = await model.GetSistemaByID(id);
            return View(c);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Sistema c)
        {
            try
            {
                await model.EditSistema(c);
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
            await model.DeleteSistema(id);
            return RedirectToAction("Index");
        }
    }
}