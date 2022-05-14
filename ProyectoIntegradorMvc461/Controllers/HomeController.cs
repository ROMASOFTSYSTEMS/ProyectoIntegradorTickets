using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIntegradorMvc461.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Acerca De";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Contacto";

            return View();
        }
    }
}