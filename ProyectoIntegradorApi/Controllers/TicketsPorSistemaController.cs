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
    public class TicketsPorSistemaController : ControllerBase
    {
        private ITicketsPorSistemaRepositorio _TicketPorSistemaRepositorio;
        public TicketsPorSistemaController(ITicketsPorSistemaRepositorio repositorio)
        {
            this._TicketPorSistemaRepositorio = repositorio;
        }
        // GET: api/ticket/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Ticket>>> Get(int id)
        {
            try
            {
                List<Ticket> tickets = await _TicketPorSistemaRepositorio.GetListadoTicketsPorSistema(id);
                return tickets;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
