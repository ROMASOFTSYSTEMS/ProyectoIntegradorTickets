using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Usings
using System.Threading.Tasks;
using ProyectoIntegradorApi.Models;
using ProyectoIntegradorApi.Tickets;
using System.Collections.Generic;

namespace ProyectoIntegradorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsPorModuloController : ControllerBase
    {
        private ITicketsPorModuloRepositorio _TicketPorModuloRepositorio;
        public TicketsPorModuloController(ITicketsPorModuloRepositorio repositorio)
        {
            this._TicketPorModuloRepositorio = repositorio;
        }
        // GET: api/ticket/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Ticket>>> Get(int id)
        {
            try
            {
                List<Ticket> tickets = await _TicketPorModuloRepositorio.GetListadoTicketsPorModulo(id);
                return tickets;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
