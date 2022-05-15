using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIntegradorMvc461.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult UnauthorizedOption(String opcion, String msjErrorException)
        {
            ViewBag.opcion = opcion;
            ViewBag.msjErrorException = msjErrorException;
            return View();
        }
    }
}