using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Usings
using ProyectoIntegradorApi.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorApi.Models;
using System.Collections.Generic;
using ProyectoIntegradorApi.Tickets;
using ProyectoIntegradorApi.Repositorios;

namespace ProyectoIntegradorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketResolutorController : ControllerBase
    {
        private ITicketResolutorRepositorio _TicketRepositorio;
        public TicketResolutorController(ITicketResolutorRepositorio repositorio)
        {
            this._TicketRepositorio = repositorio;
        }

        #region PUT ACTUALIZA REGISTRO - MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/Ticket
        [HttpPut()]
        public async Task<bool> Put(Ticket entidad)
        {
            try
            {
                bool result = await _TicketRepositorio.GrabarAtencion(entidad);
                return result;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
