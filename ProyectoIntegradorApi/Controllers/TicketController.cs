using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Usings
using ProyectoIntegradorApi.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorApi.Models;
//using ProyectoIntegradorApi.DAL.Tickets;
using ProyectoIntegradorApi.Tickets;
using System.Collections.Generic;

namespace ProyectoIntegradorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        //private readonly ApplicationDbContext _DataBase;
        private ITicketRepositorio _TicketRepositorio;
        public TicketController(ITicketRepositorio repositorio)
        {
            this._TicketRepositorio = repositorio;
        }
        // GET: api/ticket
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Ticket>>> Get()
        {
            try
            {
                List<Ticket> tickets = await _TicketRepositorio.GetListadoTickets();
                return tickets;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/ticket/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ticket>> Get(int id)
        {
            try
            {
                Ticket ticket = await _TicketRepositorio.GetTicketId(id);
                return ticket;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ticket entidad)
        {
            if (entidad == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = await _TicketRepositorio.Grabar(entidad);
            //await _DataBase.AddAsync(entidad);
            //await _DataBase.SaveChangesAsync();
            return Ok("Ticket creado");
        }

        #region PUT ACTUALIZA REGISTRO - MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/Perfil
        [HttpPut()]     // "{id:int}"
        public async Task<IActionResult> Put([FromBody] Ticket entidad)
        {
            if (entidad == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = await _TicketRepositorio.Grabar(entidad);
            //await _DataBase.AddAsync(entidad);
            //await _DataBase.SaveChangesAsync();
            return Ok("Ticket Actualizado");
        }
        #endregion
        // DELETE: api/ticket/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _TicketRepositorio.Eliminar(id);
                if (!result)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

    }
}